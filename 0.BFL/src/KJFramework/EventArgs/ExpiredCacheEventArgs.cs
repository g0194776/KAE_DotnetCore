namespace KJFramework.EventArgs
{
    /// <summary>
    ///     缓存已过期事件
    /// </summary>
    /// <typeparam name="K">缓存对象Key类型</typeparam>
    /// <typeparam name="V">缓存对象类型</typeparam>
    public class ExpiredCacheEventArgs<K, V> : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     缓存已过期事件
        /// </summary>
        /// <param name="key">缓存对象Key</param>
        /// <param name="obj">缓存对象</param>
        public ExpiredCacheEventArgs(K key, V obj)
        {
            Key = key;
            Obj = obj;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     缓存对象Key
        /// </summary>
        public K Key { get; }

        /// <summary>
        ///     缓存对象
        /// </summary>
        public V Obj { get; }

        #endregion
    }
}