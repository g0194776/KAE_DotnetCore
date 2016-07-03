using KJFramework.Enums;

namespace KJFramework.Results
{
    /// <summary>
    ///     ִ�н���ӿ�
    /// </summary>
    /// <typeparam name="T">����ֵ����</typeparam>
    public interface IExecuteResult<out T>
    {
        #region Members.

        /// <summary>
        ///     ��ȡִ�н����״̬
        /// </summary>
        ExecuteResults State { get; }
        /// <summary>
        ///     ��ȡ�ڲ�ϵͳ�Ĵ�����
        /// </summary>
        byte ErrorId { get; }
        /// <summary>
        ///     ��ȡ������Ϣ
        /// </summary>
        string Error { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     ��ȡ�ڲ��������ĵ��ý������
        /// </summary>
        /// <typeparam name="T">���ý�����������</typeparam>
        /// <returns>���ص��ý��</returns>
        T GetResult();

        #endregion
    }
}