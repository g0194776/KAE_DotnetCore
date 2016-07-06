using System;
namespace KJFramework.EventArgs
{
    public delegate void DelegateCpuPerformanceValueChanged(Object sender, CpuPerformanceValueChangedEventArgs e);
    /// <summary>
    ///     CPU����ֵ�����¼�
    /// </summary>
    public class CpuPerformanceValueChangedEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     CPU����ֵ�����¼�
        /// </summary>
        /// <param name="cpuUsage">CPU����ֵ</param>
        public CpuPerformanceValueChangedEventArgs(double cpuUsage)
        {
            CpuUsage = cpuUsage;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     ��ȡCPUʹ����
        /// </summary>
        public double CpuUsage { get; }

        #endregion
    }
}