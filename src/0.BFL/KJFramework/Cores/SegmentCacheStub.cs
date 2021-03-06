﻿using System;
using System.Diagnostics;
using KJFramework.Indexers;

namespace KJFramework.Cores
{
    /// <summary>
    ///     内存段缓存存根，提供了相关的基本操作
    /// </summary>
    [DebuggerDisplay("#Size: {Indexer.SegmentSize}, #BeginOffset: {Indexer.BeginOffset}")]
    internal class SegmentCacheStub : ISegmentCacheStub
    {
        #region Constructor.

        /// <summary>
        ///     内存段缓存存根，提供了相关的基本操作
        /// </summary>
        /// <param name="indexer">缓存索引器</param>
        /// <exception cref="ArgumentNullException">参数不能为空</exception>
        public SegmentCacheStub(ICacheIndexer indexer) : this(indexer, DateTime.MaxValue)
        { }

        /// <summary>
        ///     内存段缓存存根，提供了相关的基本操作
        /// </summary>
        /// <param name="indexer">缓存索引器</param>
        /// <param name="expireTime">过期时间</param>
        /// <exception cref="ArgumentNullException">参数不能为空</exception>
        public SegmentCacheStub(ICacheIndexer indexer, DateTime expireTime)
        {
            if (indexer == null) throw new ArgumentNullException(nameof(indexer));
            _indexer = indexer;
            _lease = new CacheLease(expireTime);
            _innerItem = new SegmentCacheItem(indexer);
            Fixed = true;
        }

        #endregion

        #region Members.

        protected readonly ICacheLease _lease;
        protected ISegmentCacheItem _innerItem;
        protected readonly ICacheIndexer _indexer;

        /// <summary>
        ///     获取当前缓存存根的内部编号
        /// </summary>
        public int Id { get; internal set; }
        /// <summary>
        ///     获取或设置一个值，该值表示了当前缓存存根是否表示为一种固态的缓存状态
        /// </summary>
        public bool Fixed { get; set; }
        /// <summary>
        ///     获取或设置缓存项
        /// </summary>
        public ICacheItem<byte[]> Cache
        {
            get { return _innerItem; }
            set { _innerItem = (ISegmentCacheItem) value; }
        }
        /// <summary>
        ///     获取一个值，该值表示了当前的缓存是否已经被使用
        /// </summary>
        public bool IsUsed => _innerItem.IsUsed;
        /// <summary>
        ///     获取缓存索引器
        /// </summary>
        public ICacheIndexer Indexer => _indexer;


        #endregion

        #region Methods.

        /// <summary>
        ///     获取缓存生命周期
        /// </summary>
        /// <returns></returns>
        public ICacheLease GetLease() => _lease;

        /// <summary>
        ///     初始化
        /// </summary>
        public void Initialize() => _innerItem.Initialize();

        #endregion
    }
}