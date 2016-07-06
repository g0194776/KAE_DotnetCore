using System;
using System.Collections.Generic;
using System.Threading;
using KJFramework.Cores;
using KJFramework.EventArgs;
using KJFramework.Exceptions;

namespace KJFramework.Containers
{
    /// <summary>
    ///     缓存容器，提供了相关的基本操作
    /// </summary>
    /// <typeparam name="K">缓存对象Key类型</typeparam>
    /// <typeparam name="V">缓存对象类型</typeparam>
    internal class CacheContainer<K, V> : ICacheContainer<K, V>
    {
        #region Constructor.

        /// <summary>
        ///     缓存容器，提供了相关的基本操作
        /// </summary>
        /// <param name="category">分类名称</param>
        public CacheContainer(string category)
            : this(category, null)
        {
        }

        /// <summary>
        ///     缓存容器，提供了相关的基本操作
        /// </summary>
        /// <param name="category">分类名称</param>
        /// <param name="comparer">比较器 </param>
        /// <exception cref="ArgumentNullException">参数不空为能</exception>
        public CacheContainer(string category, IEqualityComparer<K> comparer)
        {
            if (string.IsNullOrEmpty(category)) throw new ArgumentNullException(nameof(category));
            Category = category;
            CreateTime = DateTime.Now;
            ExpireTime = DateTime.MaxValue;
            _caches = (comparer == null
                          ? new Dictionary<K, ICacheStub<V>>()
                          : new Dictionary<K, ICacheStub<V>>(comparer));
            //10s.
            Initialize();
        }

        #endregion

        #region Members.

        private Thread _thread;
        protected readonly object _lockObj = new object();
        protected Dictionary<K, ICacheStub<V>> _caches;

        /// <summary>
        ///     获取一个值，该值表示了当前的缓存是否已经处于死亡的状态
        /// </summary>
        public bool IsDead { get; protected set; }
        /// <summary>
        ///     获取生命周期创建的时间
        /// </summary>
        public DateTime CreateTime { get; }
        /// <summary>
        ///     获取超时时间
        /// </summary>
        public DateTime ExpireTime { get; protected set; }
        /// <summary>
        ///     获取当前缓存容器的分类名称
        /// </summary>
        public string Category { get; }
        /// <summary>
        ///     获取一个值，该值表示了当前的缓存容器是否为远程缓存的代理器
        /// </summary>
        public bool IsRemotable { get; protected internal set; }

        #endregion

        #region Methods.

        /// <summary>
        ///     初始化
        /// </summary>
        protected virtual void Initialize()
        {
            _thread = new Thread(delegate ()
            {
                while (!IsDead)
                {
                    //container has been daed.
                    DateTime now = DateTime.Now;
                    if (now >= ExpireTime)
                    {
                        Discard();
                        return;
                    }
                    lock (_lockObj)
                    {
                        IList<K> keys = new List<K>();
                        foreach (KeyValuePair<K, ICacheStub<V>> pair in _caches)
                            if (pair.Value.GetLease().IsDead) keys.Add(pair.Key);
                        //clear it.
                        if (keys.Count <= 0) return;
                        foreach (K key in keys)
                        {
                            ICacheStub<V> stub;
                            if (!_caches.TryGetValue(key, out stub)) continue;
                            _caches.Remove(key);
                            K tempKey = key;
                            ThreadPool.QueueUserWorkItem(delegate { CacheExpiredHandler(new ExpiredCacheEventArgs<K, V>(tempKey, ((IFixedCacheStub<V>)stub).Cache)); });
                        }
                    }
                    //10s.
                    Thread.Sleep(10000);
                }
            })
            { IsBackground = true };
            _thread.Start();
        }

        /// <summary>
        ///     将当前缓存的生命周期置为死亡状态
        /// </summary>
        /// <exception cref="Exception">当前缓存已经处于死亡状态</exception>
        public void Discard()
        {
            if (IsDead) throw new Exception("Cannot execute discard operation on a dead container.");
            IsDead = true;
            lock (_lockObj)
            {
                //discard all cache.
                foreach (ICacheStub<V> stub in _caches.Values)
                    stub.GetLease().Discard();
                RecycleResource();
            }
        }

        /// <summary>
        ///     将当前租期续约一段时间
        /// </summary>
        /// <param name="timeSpan">续约时间</param>
        /// <returns>返回续约后的到期时间</returns>
        /// <exception cref="Exception">当前缓存已经处于死亡状态</exception>
        public DateTime Renew(TimeSpan timeSpan)
        {
            if (IsDead) throw new Exception("Cannot execute renew operation on a dead container.");
            ExpireTime = (ExpireTime == DateTime.MaxValue ? DateTime.Now.Add(timeSpan) : ExpireTime.Add(timeSpan));
            lock (_lockObj)
            {
                //renew all.
                foreach (ICacheStub<V> stub in _caches.Values)
                    stub.GetLease().Renew(timeSpan);
                return ExpireTime;
            }
        }

        /// <summary>
        ///     回收资源
        /// </summary>
        protected virtual void RecycleResource()
        {
            _caches = null;
        }

        /// <summary>
        ///     查询具有指定key的缓存是否已经存在
        /// </summary>
        /// <param name="key">缓存对象Key</param>
        /// <returns>返回是否存在的状态</returns>
        /// <exception cref="LeaseDeadException">当前缓存已经处于死亡状态</exception>
        public bool IsExists(K key)
        {
            if (IsDead) throw new LeaseDeadException("Cannot execute isexists operation on a dead container.");
            lock (_lockObj) return _caches.ContainsKey(key);
        }

        /// <summary>
        ///     移除一个具有指定key的缓存对象
        /// </summary>
        /// <param name="key">缓存对象Key</param>
        /// <returns>返回删除后的状态</returns>
        /// <exception cref="LeaseDeadException">当前缓存已经处于死亡状态</exception>
        public bool Remove(K key)
        {
            if (IsDead) throw new LeaseDeadException("Cannot execute remove operation on a dead container.");
            lock (_lockObj)
            {
                _caches.Remove(key);
                return true;
            }
        }

        /// <summary>
        ///     添加一个新的缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">要缓存对的象</param>
        /// <returns>返回缓存对象</returns>
        /// <exception cref="LeaseDeadException">当前缓存已经处于死亡状态</exception>
        public IReadonlyCacheStub<V> Add(K key, V obj)
        {
            if (IsDead) throw new LeaseDeadException("Cannot execute add operation on a dead container.");
            return Add(key, obj, DateTime.MaxValue);
        }

        /// <summary>
        ///     添加一个新的缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">要缓存对的象</param>
        /// <param name="timeSpan">续租时间</param>
        /// <returns>返回缓存对象</returns>
        /// <exception cref="LeaseDeadException">当前缓存已经处于死亡状态</exception>
        public IReadonlyCacheStub<V> Add(K key, V obj, TimeSpan timeSpan)
        {
            if (IsDead) throw new LeaseDeadException("Cannot execute add operation on a dead container.");
            return Add(key, obj, DateTime.Now.Add(timeSpan));
        }

        /// <summary>
        ///     添加一个新的缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">要缓存对的象</param>
        /// <param name="expireTime">过期时间</param>
        /// <returns>返回缓存对象</returns>
        /// <exception cref="LeaseDeadException">当前缓存已经处于死亡状态</exception>
        public IReadonlyCacheStub<V> Add(K key, V obj, DateTime expireTime)
        {
            if (IsDead) throw new LeaseDeadException("Cannot execute add operation on a dead container.");
            ICacheStub<V> stub = new CacheStub<V>(expireTime) { Cache = new CacheItem<V>() };
            stub.Cache.SetValue(obj);
            lock (_lockObj)
            {
                ICacheStub<V> tmpStub;
                if (!_caches.TryGetValue(key, out tmpStub)) _caches.Add(key, stub);
                return (IReadonlyCacheStub<V>)stub;
            }
        }

        /// <summary>
        ///     获取一个具有指定key的缓存对象
        /// </summary>
        /// <param name="key">缓存对象Key</param>
        /// <returns>返回缓存对象</returns>
        /// <exception cref="LeaseDeadException">当前缓存已经处于死亡状态</exception>
        public IReadonlyCacheStub<V> Get(K key)
        {
            if (IsDead) throw new LeaseDeadException("Cannot execute get operation on a dead container.");
            lock (_lockObj)
            {
                ICacheStub<V> stub;
                if (_caches.TryGetValue(key, out stub))
                    return (IReadonlyCacheStub<V>)stub;
                return null;
            }
        }

        #endregion

        #region Events.

        /// <summary>
        ///     缓存过期事件
        /// </summary>
        public event EventHandler<ExpiredCacheEventArgs<K, V>> CacheExpired;
        protected void CacheExpiredHandler(ExpiredCacheEventArgs<K, V> e)
        {
            EventHandler<ExpiredCacheEventArgs<K, V>> handler = CacheExpired;
            if (handler != null) handler(this, e);
        }

        #endregion
    }
}