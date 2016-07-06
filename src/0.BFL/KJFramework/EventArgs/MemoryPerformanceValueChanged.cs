using System;
namespace KJFramework.EventArgs
{
    public delegate void DelegateMemoryPerformanceValueChanged(Object sender, MemoryPerformanceValueChangedEventArgs e);
    /// <summary>
    ///     �ڴ�����ֵ�����¼�
    /// </summary>
    public class MemoryPerformanceValueChangedEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     �ڴ�����ֵ�����¼�
        /// </summary>
        /// <param name="memoryUsage">�ڴ�����ֵ</param>
        public MemoryPerformanceValueChangedEventArgs(double memoryUsage)
        {
            MemoryUsage = memoryUsage;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     ��ȡCPUʹ����
        /// </summary>
        public double MemoryUsage { get; }

        #endregion

    }
}