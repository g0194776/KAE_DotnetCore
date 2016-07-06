using System;
using KJFramework.Cores;
using KJFramework.EventArgs;
using KJFramework.Proxy;

namespace KJFramework.Containers
{
    /// <summary>
    ///     远程缓存容器，提供了相关的基本操作
    /// </summary>
    /// <typeparam name="K">缓存对象Key类型</typeparam>
    /// <typeparam name="V">缓存对象类型</typeparam>
    internal class RemoteCacheContainer<K, V> : IRemoteCacheContainer<K, V>
    {
        #region Constructor.

        /// <summary>
        ///     远程缓存容器，提供了相关的基本操作
        /// </summary>
        /// <param name="category">分类名称</param>
        /// <param name="proxy">远程缓存代理器</param>
        /// <exception cref="ArgumentNullException">参数不空为能</exception>
        public RemoteCacheContainer(string category, IRemoteCacheProxy<K, V> proxy)
        {
            if (string.IsNullOrEmpty(category)) throw new ArgumentNullException(nameof(category));
            if (proxy == null) throw new ArgumentNullException(nameof(proxy));
            _innerContainer = new CacheContainer<K, V>(category);
            _innerContainer.CacheExpired += CacheExpired;
            _proxy = proxy;
            _proxy.LocalContainer = _innerContainer;
        }

        #endregion

        #region Members.

        protected readonly IRemoteCacheProxy<K, V> _proxy;
        protected readonly ICacheContainer<K, V> _innerContainer;

        /// <summary>
        ///     获取一个值，该值表示了当前的缓存是否已经处于死亡的状态
        /// </summary>
        public bool IsDead => _innerContainer.IsDead;
        /// <summary>
        ///     获取生命周期创建的时间
        /// </summary>
        public DateTime CreateTime => _innerContainer.CreateTime;
        /// <summary>
        ///     获取超时时间
        /// </summary>
        public DateTime ExpireTime => _innerContainer.ExpireTime;
        /// <summary>
        ///     获取当前缓存容器的分类名称
        /// </summary>
        public string Category => _innerContainer.Category;
        /// <summary>
        ///     获取一个值，该值表示了当前的缓存容器是否为远程缓存的代理器
        /// </summary>
        public bool IsRemotable => true;
        /// <summary>
        ///     获取远程缓存代理器
        /// </summary>
        public IRemoteCacheProxy<K, V> Proxy => _proxy;

        #endregion

        #region Methods.

        /// <summary>
        ///     将当前缓存的生命周期置为死亡状态
        /// </summary>
        public void Discard()
        {
            _proxy.Discard();
            _innerContainer.Discard();
        }

        /// <summary>
        ///     将当前租期续约一段时间
        /// </summary>
        /// <param name="timeSpan">续约时间</param>
        /// <returns>返回续约后的到期时间</returns>
        /// <exception cref="System.Exception">更新失败</exception>
        public DateTime Renew(TimeSpan timeSpan)
        {
            return _innerContainer.Renew(timeSpan);
        }

        /// <summary>
        ///     查询具有指定key的缓存是否已经存在
        /// </summary>
        /// <param name="key">缓存对象Key</param>
        /// <returns>返回是否存在的状态</returns>
        public bool IsExists(K key)
        {
            //local cache first.
            return _innerContainer.IsExists(key) || _proxy.IsExists(key);
        }

        /// <summary>
        ///     移除一个具有指定key的缓存对象
        /// </summary>
        /// <param name="key">缓存对象Key</param>
        /// <returns>返回删除后的状态</returns>
        public bool Remove(K key)
        {
            _proxy.Remove(key);
            return _innerContainer.Remove(key);
        }

        /// <summary>
        ///     添加一个新的缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">要缓存对的象</param>
        /// <returns>返回缓存对象</returns>
        public IReadonlyCacheStub<V> Add(K key, V obj)
        {
            return Add(key, obj, DateTime.MaxValue);
        }

        /// <summary>
        ///     添加一个新的缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">要缓存对的象</param>
        /// <param name="timeSpan">续租时间</param>
        /// <returns>返回缓存对象</returns>
        public IReadonlyCacheStub<V> Add(K key, V obj, TimeSpan timeSpan)
        {
            return Add(key, obj, DateTime.Now.Add(timeSpan));
        }

        /// <summary>
        ///     添加一个新的缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">要缓存对的象</param>
        /// <param name="expireTime">过期时间</param>
        /// <returns>返回缓存对象</returns>
        public IReadonlyCacheStub<V> Add(K key, V obj, DateTime expireTime)
        {
            _proxy.Add(key, obj, expireTime);
            return _innerContainer.Add(key, obj, expireTime);
        }

        /// <summary>
        ///     获取一个具有指定key的缓存对象
        /// </summary>
        /// <param name="key">缓存对象Key</param>
        /// <returns>返回缓存对象</returns>
        public IReadonlyCacheStub<V> Get(K key)
        {
            //local cache first.
            return _innerContainer.Get(key) ?? _proxy.Get(key);
        }

        /// <summary>
        ///     查询具有指定key的缓存是否已经存在
        /// </summary>
        /// <param name="key">缓存对象Key</param>
        /// <returns>返回是否存在的状态</returns>
        public bool LocalIsExists(K key)
        {
            return _innerContainer.IsExists(key);
        }

        /// <summary>
        ///     移除一个具有指定key的缓存对象
        /// </summary>
        /// <param name="key">缓存对象Key</param>
        public void LocalRemove(K key)
        {
            _innerContainer.Remove(key);
        }

        /// <summary>
        ///     获取一个具有指定key的缓存对象
        /// </summary>
        /// <param name="key">缓存对象Key</param>
        /// <returns>返回缓存对象</returns>
        public IReadonlyCacheStub<V> LocalGet(K key)
        {
            return _innerContainer.Get(key);
        }

        /// <summary>
        ///     添加一个新的缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">要缓存对的象</param>
        /// <returns>返回缓存对象</returns>
        public IReadonlyCacheStub<V> LocalAdd(K key, V obj)
        {
            return LocalAdd(key, obj, DateTime.MaxValue);
        }

        /// <summary>
        ///     添加一个新的缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">要缓存对的象</param>
        /// <param name="timeSpan">续租时间</param>
        /// <returns>返回缓存对象</returns>
        public IReadonlyCacheStub<V> LocalAdd(K key, V obj, TimeSpan timeSpan)
        {
            return LocalAdd(key, obj, DateTime.Now.Add(timeSpan));
        }

        /// <summary>
        ///     添加一个新的缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">要缓存对的象</param>
        /// <param name="expireTime">过期时间</param>
        /// <returns>返回缓存对象</returns>
        public IReadonlyCacheStub<V> LocalAdd(K key, V obj, DateTime expireTime)
        {
            return _innerContainer.Add(key, obj, expireTime);
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