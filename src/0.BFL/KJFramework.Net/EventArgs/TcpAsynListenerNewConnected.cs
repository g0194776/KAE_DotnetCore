using System;
using System.Net.Sockets;
using KJFramework.Net.Listener;
namespace KJFramework.Net.EventArgs
{
    public delegate void DelegateTcpAsynListenerNewConnected<TListenerInfo>(Object sender, TcpAsynListenerNewConnected<TListenerInfo> e) where TListenerInfo : IPortListenerInfomation;
    /// <summary>
    ///     TCP异步端口监听器新连接到来事件
    ///  </summary>
    /// <typeparam name="TListenerInfo">监听器信息类型</typeparam>
    public class TcpAsynListenerNewConnected<TListenerInfo> : System.EventArgs
        where TListenerInfo : IPortListenerInfomation
    {
        #region Constructor.

        /// <summary>
        ///     TCP异步端口监听器新连接到来事件
        ///  </summary>
        /// <param name="socket">新连接的Socket</param>
        /// <param name="info">监听器信息</param>
        public TcpAsynListenerNewConnected(Socket socket, TListenerInfo info)
        {
            Socket = socket;
            Info = info;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取新连接的套接字
        /// </summary>
        public Socket Socket { get; }

        /// <summary>
        ///     获取监听器的监听器信息
        /// </summary>
        public TListenerInfo Info { get; }

        #endregion
    }
}