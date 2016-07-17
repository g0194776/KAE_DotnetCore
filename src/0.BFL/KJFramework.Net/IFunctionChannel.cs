using System;

namespace KJFramework.Net
{
    /// <summary>
    ///     ����ͨ��Ԫ�ӿڣ��ṩ����صĻ�������
    /// </summary>
    public interface IFunctionChannel
    {
        #region Members.

        /// <summary>
        ///     ��ȡΨһ��ʶ
        /// </summary>
        Guid Key { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     ����ָ�����󣬲����ش����Ľ��
        /// </summary>
        /// <param name="obj">����Ķ���</param>
        /// <param name="isSuccess">�Ƿ���ɹ��ı�ʾ</param>
        /// <returns>�ش����Ľ��</returns>
        object Process(object obj, out bool isSuccess);

        #endregion

    }

    /// <summary>
    ///     ����ͨ��Ԫ�ӿڣ��ṩ����صĻ�������
    /// </summary>
    /// <typeparam name="T">����Ķ�������</typeparam>
    public interface IFunctionChannel<T>
    {
        #region Members.

        /// <summary>
        ///     ��ȡΨһ��ʶ
        /// </summary>
        Guid Key { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     ����ָ�����󣬲����ش����Ľ��
        /// </summary>
        /// <param name="obj">����Ķ���</param>
        /// <param name="isSuccess">�Ƿ���ɹ��ı�ʾ</param>
        /// <returns>�ش����Ľ��</returns>
        T Process(T obj, out bool isSuccess);

        #endregion

    }
}