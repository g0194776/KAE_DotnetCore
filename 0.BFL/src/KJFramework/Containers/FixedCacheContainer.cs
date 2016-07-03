using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using KJFramework.Cores;
using KJFramework.Tracing;

namespace KJFramework.Containers
{
    /// <summary>
    ///     固态的缓存容器，提供了相关的基本操作
    /// </summary>
    /// <typeparam name="T">缓存对象类型</typeparam>
    internal class FixedCacheContainer<T> : IFixedCacheContainer<T>
        where T : IClearable, new()
    {
        #region Constructor.

        /// <summary>
        ///     固态的缓存容器，提供了相关的基本操作
        /// </summary>
        /// <param name="capacity">最大容量</param>
        /// <exception cref="ArgumentException">错误的参数取值范围</exception>
        public FixedCacheContainer(int capacity)
        {
            if (capacity <= 0) throw new ArgumentException("Illegal capacity!");
            _remainingCount = _capacity = capacity;
            _caches = new Stack<ICacheStub<T>>();
            //initialize.
            for (int i = 0; i < _capacity; i++)
            {
                ICacheStub<T> stub = new CacheStub<T> { Fixed = true };
                ((CacheStub<T>)stub).Id = i;
                stub.Cache = new CacheItem<T>();
                stub.Cache.SetValue(new T());
                _caches.Push(stub);
            }
        }

        #endregion

        #region Members.

        private readonly int _capacity;
        private long _remainingCount;
        private readonly object _lockObj = new object();
        private readonly Stack<ICacheStub<T>> _caches;
        private static readonly ITracing _tracing = TracingManager.GetTracing(typeof (FixedCacheContainer<T>));
        private static readonly string _perfCounterCategory = "#FIX-Cache Container. - " + Process.GetCurrentProcess().ProcessName;

        /// <summary>
        ///     获取当前容器的最大容量
        /// </summary>
        public int Capacity => _capacity;

        #endregion

        #region Methods.

        /// <summary>
        ///     租借一个缓存
        /// </summary>
        /// <returns>返回一个新的缓存</returns>
        public IFixedCacheStub<T> Rent()
        {
            lock (_lockObj)
            {
                if (_caches.Count == 0) return null;
                ICacheStub<T> cache = _caches.Pop();
                Interlocked.Decrement(ref _remainingCount);
                return (IFixedCacheStub<T>)cache;
            }
        }

        /// <summary>
        ///     归还一个缓存
        /// </summary>
        /// <param name="cache">缓存</param>
        /// <exception cref="Exception">归还缓存失败，因为目标缓存容器已经满了</exception>
        public void Giveback(IFixedCacheStub<T> cache)
        {
            if (cache == null) throw new ArgumentNullException(nameof(cache));
            lock (_lockObj)
            {
                if (Interlocked.Read(ref _remainingCount) >= _capacity) throw new Exception("Can not giveback a cache, because target caches count has been full.");
                cache.Cache.Clear();
                cache.Tag = null;
                _caches.Push((ICacheStub<T>)cache);
                Interlocked.Increment(ref _remainingCount);
            }
        }

        /// <summary>
        ///    构造内部性能计数器
        /// </summary>
        /// <param name="name">性能计数器名称</param>
        public void BuildPerformanceCounter(string name)
        {
        }

        /// <summary>
        ///    获取内部容器所包含的真实元素个数
        /// </summary>
        /// <returns>内部容器所包含的真实元素个数</returns>
        internal int GetCount() => _caches.Count;

        #endregion 
    }
}