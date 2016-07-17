using System;
using System.Net.Sockets;

namespace KJFramework.Net.EventArgs
{
    public delegate void DELEGATE_UDPLISTENER_STARTED(Object sender, UdpListenerStartedEventArgs e);
    /// <summary>
    ///     UDP端口监听器开始监听事件
    /// </summary>
    public class UdpListenerStartedEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     UDP端口监听器开始监听事件
        /// </summary>
        /// <param name="client">监听中的UDP客户端</param>
        public UdpListenerStartedEventArgs(UdpClient client)
        {
            Client = client;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     连接上的UDP客户端
        /// </summary>
        public UdpClient Client { get; }

        #endregion
    }
}
