using System;

namespace KJFramework.Net.EventArgs
{
    public delegate void DELEGATE_IOCP_PORTLISTENER_DISCONNECTED<TListener>(Object sender, IocpPortListenerDisconnectedEventArgs<TListener> e);
    /// <summary>
    ///     端口监听器断开事件（遵循完成端口模型的端口监听器）
    /// </summary>
    public class IocpPortListenerDisconnectedEventArgs<TListener> : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     端口监听器断开事件（遵循完成端口模型的端口监听器）
        /// </summary>
        public IocpPortListenerDisconnectedEventArgs(TListener listener)
        {
            Listener = listener;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     断开连接的端口监听器
        /// </summary>
        public TListener Listener { get; }

        #endregion
    }
}
