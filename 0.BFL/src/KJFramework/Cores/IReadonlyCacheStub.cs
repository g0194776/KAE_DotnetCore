namespace KJFramework.Cores
{
    /// <summary>
    ///     ֻ��������Ԫ�ӿڣ��ṩ����صĻ�������
    /// </summary>
    /// <typeparam name="T">��������</typeparam>
    public interface IReadonlyCacheStub<out T>
    {
        #region Members.

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