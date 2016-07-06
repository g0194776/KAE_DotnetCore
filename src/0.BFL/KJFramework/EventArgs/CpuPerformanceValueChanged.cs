using System;
namespace KJFramework.EventArgs
{
    public delegate void DelegateCpuPerformanceValueChanged(Object sender, CpuPerformanceValueChangedEventArgs e);
    /// <summary>
    ///     CPU性能值更改事件
    /// </summary>
    public class CpuPerformanceValueChangedEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     CPU性能值更改事件
        /// </summary>
        /// <param name="cpuUsage">CPU性能值</param>
        public CpuPerformanceValueChangedEventArgs(double cpuUsage)
        {
            CpuUsage = cpuUsage;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取CPU使用率
        /// </summary>
        public double CpuUsage { get; }

        #endregion
    }
}