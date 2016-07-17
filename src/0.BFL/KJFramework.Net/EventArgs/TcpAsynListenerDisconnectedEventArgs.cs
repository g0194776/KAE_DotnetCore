using System;
using KJFramework.Net.Listener;
namespace KJFramework.Net.EventArgs
{
    public delegate void DelegateTcpAsynListenerDisconnected<TListenerInfo>(Object sender, TcpAsynListenerDisconnectedEventArgs<TListenerInfo> e)
        where TListenerInfo : IPortListenerInfomation;
    /// <summary>
    ///     TCP异步套接字监听器断开事件
    /// </summary>
    public class TcpAsynListenerDisconnectedEventArgs<TListenerInfo> : System.EventArgs
        where TListenerInfo : IPortListenerInfomation
    {
        #region Constructor.

        /// <summary>
        ///     TCP异步套接字监听器断开事件
        /// </summary>
        public TcpAsynListenerDisconnectedEventArgs(TListenerInfo[] listenerInfo)
        {
            ListenerInfo = listenerInfo;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     监听器信息集合
        /// </summary>
        public TListenerInfo[] ListenerInfo { get; }

        #endregion
    }
}