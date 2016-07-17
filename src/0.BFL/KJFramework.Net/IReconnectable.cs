namespace KJFramework.Net
{
    /// <summary>
    ///     ӵ���������ӹ��ܵ�Ԫ�ӿڣ��ṩ����صĻ���������
    /// </summary>
    public interface IReconnectable
    {
        #region Members.

        /// <summary>
        ///     ��ȡ�������ӵ��ܹ�����
        /// </summary>
        int RetryCount { get; }

        /// <summary>
        ///     ��ȡ�����������Դ���
        /// </summary>
        int RetryIndex { get; set; }

        #endregion

        #region Methods.

        /// <summary>
        ///     ��������
        /// </summary>
        bool Retry();

        #endregion
    }
}