using System;
using KJFramework.Indexers;

namespace KJFramework.Cores
{
    /// <summary>
    ///     内存段缓存项，提供了相关的基本操作
    /// </summary>
    internal class SegmentCacheItem : ISegmentCacheItem
    {
        #region Constructor.

        /// <summary>
        ///     内存段缓存项，提供了相关的基本操作
        /// </summary>
        /// <param name="indexer">缓存索引器</param>
        /// <exception cref="ArgumentNullException">参数不空为能</exception>
        public SegmentCacheItem(ICacheIndexer indexer)
        {
            if (indexer == null) throw new ArgumentNullException(nameof(indexer));
            _indexer = indexer;
        }

        #endregion

        #region Members.

        protected readonly ICacheIndexer _indexer;
        /// <summary>
        ///     获取一个值，该值表示了当前的缓存是否已经被使用
        /// </summary>
        public bool IsUsed { get; protected set; }
        /// <summary>
        ///     获取当前的使用大小
        /// </summary>
        public int UsageSize { get; protected set; } = -1;

        #endregion

        #region Methods.

        /// <summary>
        ///     获取缓存内容
        /// </summary>
        /// <returns>返回缓存内容</returns>
        public byte[] GetValue()
        {
            byte[] data;
            //all of the data.
            if (UsageSize == -1)
            {
                data = new byte[_indexer.SegmentSize];
                Buffer.BlockCopy(_indexer.CacheBuffer, _indexer.BeginOffset, data, 0, _indexer.SegmentSize);
                return data;
            }
            data = new byte[UsageSize];
            Buffer.BlockCopy(_indexer.CacheBuffer, _indexer.BeginOffset, data, 0, UsageSize);
            return data;
        }

        /// <summary>
        ///     设置缓存内容
        /// </summary>
        /// <param name="obj">缓存对象</param>
        public void SetValue(byte[] obj) => SetValue(obj, obj.Length);

        /// <summary>
        ///     初始化
        /// </summary>
        public void Initialize()
        {
            IsUsed = false;
            byte[] data = new byte[_indexer.SegmentSize];
            Buffer.BlockCopy(data, 0, _indexer.CacheBuffer, _indexer.BeginOffset, data.Length);
        }

        /// <summary>
        ///     设置缓存内容
        /// </summary>
        /// <param name="obj">缓存对象</param>
        /// <param name="usedSize">使用大小</param>
        /// <exception cref="ArgumentException">参数超围范出</exception>
        /// <exception cref="ArgumentNullException">参数不空为能</exception>
        public void SetValue(byte[] obj, int usedSize)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (obj.Length > _indexer.SegmentSize) throw new ArgumentException("Out of range size. #size: " + obj.Length);
            IsUsed = true;
            UsageSize = usedSize;
            Buffer.BlockCopy(obj, 0, _indexer.CacheBuffer, _indexer.BeginOffset, usedSize);
        }

        #endregion
    }
}