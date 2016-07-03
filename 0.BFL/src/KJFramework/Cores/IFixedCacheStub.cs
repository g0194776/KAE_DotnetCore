namespace KJFramework.Cores
{
    /// <summary>
    ///     ��̬������Ԫ�ӿڣ��ṩ����صĻ�������
    /// </summary>
    /// <typeparam name="T">��������</typeparam>
    public interface IFixedCacheStub<out T>
    {
        #region Members.

        /// <summary>
        ///     ��ȡ�����ø�������
        /// </summary>
        object Tag { get; set; }
        /// <summary>
        ///     ��ȡ����
        /// </summary>
        T Cache { get; }
        /// <summary>
        ///     ��ȡ�������������
        /// </summary>
        ICacheLease Lease { get; }

        #endregion
    }
}