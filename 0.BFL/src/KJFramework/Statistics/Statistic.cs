using KJFramework.Enums;

namespace KJFramework.Statistics
{
    /// <summary>
    ///     统计器抽象类，提供了相关的基本操作。
    /// </summary>
    public abstract class Statistic : IStatistic
    {
        #region Constructor.

        /// <summary>
        ///     统计器抽象类，提供了相关的基本操作。
        /// </summary>
        protected Statistic()
        {
            IsEnable = true;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取统计类型
        /// </summary>
        public StatisticTypes StatisticType { get; }

        /// <summary>
        ///     获取或设置可用标示
        /// </summary>
        public bool IsEnable { get; set; }

        #endregion

        #region Methods.

        /// <summary>
        ///     初始化
        /// </summary>
        /// <param name="element">统计类型</param>
        /// <typeparam name="T">统计类型</typeparam>
        public abstract void Initialize<T>(T element);

        /// <summary>
        ///     关闭统计
        /// </summary>
        public abstract void Close();

        #endregion
    }
}