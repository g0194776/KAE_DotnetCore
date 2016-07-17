namespace KJFramework.Net.Listener
{
    /// <summary>
    ///     端口监听器详细信息基类，提供了相关的基本信息。
    /// </summary>
    public class BasicPortListenerInfomation : IPortListenerInfomation
    {
        #region Members.

        /// <summary>
        ///     获取或设置监听器唯一ID
        ///         * 可以使用Listener.GetHashCode()获得
        /// </summary>
        public int ListenerID { get; set; }

        /// <summary>
        ///     获取或设置监听器分组ID
        /// </summary>
        public int ItemID { get; set; }

        /// <summary>
        ///     获取或设置监听器服务ID
        /// </summary>
        public int ServiceID { get; set; }

        /// <summary>
        ///     获取或设置附属属性
        /// </summary>
        public object Tag { get; set; }

        #endregion
    }
}
