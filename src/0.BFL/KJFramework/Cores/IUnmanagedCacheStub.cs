using System;

namespace KJFramework.Cores
{
    /// <summary>
    ///     ���йܻ�����Ԫ�ӿڣ��ṩ����صĻ�������
    /// </summary>
    internal interface IUnmanagedCacheStub : ICacheStub<byte[]>
    {
        #region Members.

        /// <summary>
        ///     ��ȡ�ڴ���
        /// </summary>
        IntPtr Handle { get; }
        /// <summary>
        ///     ��ȡ��ǰ�ڲ��Ļ���ʹ����
        /// </summary>
        int CurrentSize { get; }
        /// <summary>
        ///     ��ȡ��ǰ������������
        /// </summary>
        int MaxSize { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     ������ǰ����
        /// </summary>
        void Discard();

        #endregion

    }
}