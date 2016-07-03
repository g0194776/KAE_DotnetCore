using System;
namespace KJFramework.EventArgs
{
    public delegate void DelegateMemoryPerformanceValueChanged(Object sender, MemoryPerformanceValueChangedEventArgs e);
    /// <summary>
    ///     内存性能值更改事件
    /// </summary>
    public class MemoryPerformanceValueChangedEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     内存性能值更改事件
        /// </summary>
        /// <param name="memoryUsage">内存性能值</param>
        public MemoryPerformanceValueChangedEventArgs(double memoryUsage)
        {
            MemoryUsage = memoryUsage;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取CPU使用率
        /// </summary>
        public double MemoryUsage { get; }

        #endregion

    }
}