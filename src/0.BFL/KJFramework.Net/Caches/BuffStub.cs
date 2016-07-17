using KJFramework.Objects;

namespace KJFramework.Net.Caches
{
    /// <summary>
    ///    缓冲区存根基础类
    /// </summary>
    public class BuffStub : IClearable
    {
        #region Constructor.

        /// <summary>
        ///     缓冲区存根基础类
        /// </summary>
        public BuffStub()
        {
            Segment = ChannelConst.SegmentContainer.Rent();
            if (Segment == null) throw new System.Exception("[BuffSocketStub-Prealloc] #There has no enough MemorySegment can be used.");
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取或设置附属属性
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        ///     获取内部关联的内存数据片段
        /// </summary>
        public IMemorySegment Segment { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     清理资源
        /// </summary>
        public virtual void Clear()
        {
            Tag = null;
            Segment.UsedBytes = 0;
        }

        #endregion
    }
}