namespace KJFramework.Net
{
    /// <summary>
    ///     可重新连接的传输信道接口
    /// </summary>
    public interface IReconnectionTransportChannel : ITransportChannel
    {
        /// <summary>
        ///    重新连接
        /// </summary>
        /// <returns>返回重新连接后的状态</returns>
        bool Reconnect();
    }
}