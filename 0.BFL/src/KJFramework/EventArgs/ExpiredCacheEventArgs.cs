namespace KJFramework.EventArgs
{
    /// <summary>
    ///     �����ѹ����¼�
    /// </summary>
    /// <typeparam name="K">�������Key����</typeparam>
    /// <typeparam name="V">�����������</typeparam>
    public class ExpiredCacheEventArgs<K, V> : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     �����ѹ����¼�
        /// </summary>
        /// <param name="key">�������Key</param>
        /// <param name="obj">�������</param>
        public ExpiredCacheEventArgs(K key, V obj)
        {
            Key = key;
            Obj = obj;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     �������Key
        /// </summary>
        public K Key { get; }

        /// <summary>
        ///     �������
        /// </summary>
        public V Obj { get; }

        #endregion
    }
}