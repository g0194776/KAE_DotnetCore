namespace KJFramework.Indexers
{
    /// <summary>
    ///     缓存索引器，提供了相关的基本属性结构
    /// </summary>
    internal class CacheIndexer : ICacheIndexer
    {
        #region Members.

        /// <summary>
        ///     获取索引器开始的偏移量
        /// </summary>
        public int BeginOffset { get; protected internal set; }
        /// <summary>
        ///     获取当前缓存数据段大小
        /// </summary>
        public int SegmentSize { get; protected internal set; }
        /// <summary>
        ///     获取缓存缓冲区
        /// </summary>
        public byte[] CacheBuffer { get; protected internal set; }

        #endregion
    }
}