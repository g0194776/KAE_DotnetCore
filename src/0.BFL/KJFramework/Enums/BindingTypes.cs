namespace KJFramework.Enums
{
    /// <summary>
    ///     通信绑定类型
    /// </summary>
    public enum BindingTypes
    {
        /// <summary>
        ///     TCP
        /// </summary>
        Tcp,
        /// <summary>
        ///     UDP
        /// </summary>
        Udp,
        /// <summary>
        ///     HTTP
        /// </summary>
        Http,
        /// <summary>
        ///     HTTPS
        /// </summary>
        Https,
        /// <summary>
        ///     消息队列
        /// </summary>
        MessageQueue,
        /// <summary>
        ///     进程内通信
        /// </summary>
        Ipc
    }
}