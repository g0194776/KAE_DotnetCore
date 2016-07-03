using System;

namespace KJFramework.Cores
{
    /// <summary>
    ///     ���йܻ�����Ԫ�ӿڣ��ṩ����صĻ���������
    /// </summary>
    public interface IUnmanagedCacheItem : ICacheItem<byte[]>
    {
        #region Members.

        /// <summary>
        ///     ��ȡ�ڴ���
        /// </summary>
        IntPtr Handle { get; }
        /// <summary>
        ///     ��ȡ��ǰ��ʹ�ô�С
        /// </summary>
        int UsageSize { get; }
        /// <summary>
        ///     ��ȡ��ǰ���������
        /// </summary>
        int MaxSize { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     �ͷŵ�ǰ�����еķ��йܻ���
        /// </summary>
        void Free();

        #endregion
    }
}