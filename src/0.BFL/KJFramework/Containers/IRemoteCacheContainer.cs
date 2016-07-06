using KJFramework.Proxy;

namespace KJFramework.Containers
{
    /// <summary>
    ///     Զ�̻�������Ԫ�ӿڣ��ṩ����صĻ�������
    /// </summary>
    /// <typeparam name="K">�������Key����</typeparam>
    /// <typeparam name="V">�����������</typeparam>
    public interface IRemoteCacheContainer<K, V> : ICacheContainer<K, V>
    {
        #region Members.

        /// <summary>
        ///     ��ȡԶ�̻��������
        /// </summary>
        IRemoteCacheProxy<K, V> Proxy { get; }

        #endregion
    }
}