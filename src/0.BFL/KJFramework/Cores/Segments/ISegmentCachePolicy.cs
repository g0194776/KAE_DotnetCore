using System.Collections.Generic;
using KJFramework.Exceptions;

namespace KJFramework.Cores.Segments
{
    /// <summary>
    ///     分片缓存策略接口
    /// </summary>
    public interface ISegmentCachePolicy
    {
        #region Members.

        /// <summary>
        ///     获取片段分布等级
        /// </summary>
        int SegmentLevel { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     设置一个片段分布策略
        ///     <para>* 此方法将会把剩余的片段百分比全都分给当前的大小</para>
        /// </summary>
        /// <param name="size">片段大小</param>
        /// <exception cref="OutOfRangeException">超出预定的范围</exception>
        void Set(int size);
        /// <summary>
        ///     设置一个片段分布策略
        /// </summary>
        /// <param name="size">片段大小</param>
        /// <param name="percent">占用总体内存的百分比</param>
        /// <exception cref="OutOfRangeException">超出预定的范围</exception>
        void Set(int size, decimal percent);
        /// <summary>
        ///     获取所有的片段分布
        /// </summary>
        /// <returns>返回片段分布集合</returns>
        List<SegmentSizePair> Get();

        #endregion
    }
}