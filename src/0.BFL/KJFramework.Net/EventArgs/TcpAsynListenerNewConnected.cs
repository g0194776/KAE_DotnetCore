using System;
using System.Net.Sockets;
using KJFramework.Net.Listener;
namespace KJFramework.Net.EventArgs
{
    public delegate void DelegateTcpAsynListenerNewConnected<TListenerInfo>(Object sender, TcpAsynListenerNewConnected<TListenerInfo> e) where TListenerInfo : IPortListenerInfomation;
    /// <summary>
    ///     TCP�첽�˿ڼ����������ӵ����¼�
    ///  </summary>
    /// <typeparam name="TListenerInfo">��������Ϣ����</typeparam>
    public class TcpAsynListenerNewConnected<TListenerInfo> : System.EventArgs
        where TListenerInfo : IPortListenerInfomation
    {
        #region Constructor.

        /// <summary>
        ///     TCP�첽�˿ڼ����������ӵ����¼�
        ///  </summary>
        /// <param name="socket">�����ӵ�Socket</param>
        /// <param name="info">��������Ϣ</param>
        public TcpAsynListenerNewConnected(Socket socket, TListenerInfo info)
        {
            Socket = socket;
            Info = info;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     ��ȡ�����ӵ��׽���
        /// </summary>
        public Socket Socket { get; }

        /// <summary>
        ///     ��ȡ�������ļ�������Ϣ
        /// </summary>
        public TListenerInfo Info { get; }

        #endregion
    }
}