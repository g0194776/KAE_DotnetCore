using System;
using KJFramework.Net.Listener;
namespace KJFramework.Net.EventArgs
{
    public delegate void DelegateTcpAsynListenerDisconnected<TListenerInfo>(Object sender, TcpAsynListenerDisconnectedEventArgs<TListenerInfo> e)
        where TListenerInfo : IPortListenerInfomation;
    /// <summary>
    ///     TCP�첽�׽��ּ������Ͽ��¼�
    /// </summary>
    public class TcpAsynListenerDisconnectedEventArgs<TListenerInfo> : System.EventArgs
        where TListenerInfo : IPortListenerInfomation
    {
        #region Constructor.

        /// <summary>
        ///     TCP�첽�׽��ּ������Ͽ��¼�
        /// </summary>
        public TcpAsynListenerDisconnectedEventArgs(TListenerInfo[] listenerInfo)
        {
            ListenerInfo = listenerInfo;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     ��������Ϣ����
        /// </summary>
        public TListenerInfo[] ListenerInfo { get; }

        #endregion
    }
}