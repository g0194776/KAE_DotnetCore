using System;
using System.Net.Sockets;
using KJFramework.Cores;
using KJFramework.Net.Caches;
using KJFramework.Net.EventArgs;
using KJFramework.Net.Events;
using KJFramework.Tracing;

namespace KJFramework.Net.Receivers
{
    /// <summary>
    ///     �����Ļ���TCPЭ�����Ϣ���������ṩ����صĻ���������
    ///     <para>* �첽���ƻ��� .NET FRAMEWORK 3.5�е���Socket�첽ģ�͡�</para>
    /// </summary>
    public class TcpAsynDataRecevier
    {
        #region Constructor.

        /// <summary>
        ///     �����Ļ���TCPЭ�����Ϣ���������ṩ����صĻ���������
        ///             * �첽���ƻ��� .NET FRAMEWORK 3.5�е���Socket�첽ģ�͡�
        /// </summary>
        public TcpAsynDataRecevier()
        { }

        /// <summary>
        ///     �����Ļ���TCPЭ�����Ϣ���������ṩ����صĻ���������
        ///             * �첽���ƻ��� .NET FRAMEWORK 3.5�е���Socket�첽ģ�͡�
        /// </summary>
        /// <param name="socket">�׽���</param>
        public TcpAsynDataRecevier(Socket socket)
        {
            _socket = socket;
        }

        #endregion

        #region Members.

        private static readonly ITracing _tracing = TracingManager.GetTracing(typeof(TcpAsynDataRecevier));

        #endregion

        #region Methods.

        /// <summary>
        ///     ��ʼ��������
        /// </summary>
        private void StartReceive()
        {
            if (!_state) return;
            try
            {
                IFixedCacheStub<SocketBuffStub> stub = ChannelConst.BuffAsyncStubPool.Rent();
                if (stub == null) throw new System.Exception("#Cannot rent an async recv io-stub for socket recv async action.");
                SocketAsyncEventArgs e = stub.Cache.Target;
                //set callback var = receiver
                stub.Tag = this;
                e.AcceptSocket = _socket;
                e.UserToken = stub;
                bool result = e.AcceptSocket.ReceiveAsync(e);
                //Sync process data.
                if (!result) ProcessReceive(stub);
            }
            catch (System.Exception ex)
            {
                _tracing.Error(ex, null);
                Stop();
            }
        }

        /// <summary>
        ///     �������յ�����
        /// </summary>
        /// <param name="stub">���������Ĺ̶�������</param>
        internal void ProcessReceive(IFixedCacheStub<SocketBuffStub> stub)
        {
            if (stub.Cache.Target.BytesTransferred > 0 && stub.Cache.Target.SocketError == SocketError.Success)
            {
                //���ճɹ�
                try { ProcessData(stub, stub.Cache.Target.BytesTransferred); }
                catch (System.Exception ex) { _tracing.Error(ex, null); }
                finally { StartReceive(); }
            }
            else
            {
                //giveback current rented BuffSocketStub.
                ChannelConst.BuffAsyncStubPool.Giveback(stub);
                Stop();
            }
        }

        /// <summary>
        ///     ��������
        /// </summary>
        /// <param name="stub">���������Ĺ̶�������</param>
        /// <param name="bytesTransferred">���յ������ݳ���</param>
        private void ProcessData(IFixedCacheStub<SocketBuffStub> stub, int bytesTransferred)
        {
            ReceivedDataHandler(new SocketSegmentReceiveEventArgs(stub, bytesTransferred));
        }

        #endregion

        #region ITcpMessageRecevier Members

        private Socket _socket;

        /// <summary>
        ///     �û��׽���
        /// </summary>
        public Socket Socket
        {
            get { return _socket; }
            set { _socket = value; }
        }

        /// <summary>
        ///     ���յ������¼�
        /// </summary>
        public event EventHandler<SegmentReceiveEventArgs> ReceivedData;
        protected void ReceivedDataHandler(SegmentReceiveEventArgs e)
        {
            EventHandler<SegmentReceiveEventArgs> handler = ReceivedData;
            if (handler != null) handler(this, e);
        }

        #endregion

        #region IMessageRecevier<string,NetMessage> Members

        /// <summary>
        ///     �������Ͽ������¼�
        /// </summary>
        public event EventHandler<RecevierDisconnectedEventArgs> Disconnected;
        private void DisconnectedHandler(RecevierDisconnectedEventArgs e)
        {
            EventHandler<RecevierDisconnectedEventArgs> disconnected = Disconnected;
            if (disconnected != null) disconnected(this, e);
        }

        #endregion

        #region IListener<string> Members

        private bool _state;

        /// <summary>
        ///     ��ȡ�����õ�ǰ��״̬
        /// </summary>
        public bool State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        #endregion

        #region IMetadata<string> Members

        private int _key;

        /// <summary>
        ///     ��ȡ����������Լ�����ж����Ψһ��ʾ
        /// </summary>
        public int Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }

        #endregion

        #region IControlable Members

        /// <summary>
        ///     ��ʼִ��
        /// </summary>
        public void Start()
        {
            if (!_state)
            {
                if (_socket == null || !_socket.Connected)
                {
                    DisconnectedHandler(null);
                    return;
                }
                _key = _socket.GetHashCode();
                _state = true;
                StartReceive();
            }
        }

        /// <summary>
        ///     ִֹͣ��
        /// </summary>
        public void Stop()
        {
            if (_state)
            {
                try
                {
                    _socket.Shutdown(SocketShutdown.Both);
                    _socket.Dispose();
                }
                catch (System.Exception e) { _tracing.Error(e, null); }
                _socket = null;
                _state = false;
            }
            DisconnectedHandler(null);
        }

        #endregion
    }
}