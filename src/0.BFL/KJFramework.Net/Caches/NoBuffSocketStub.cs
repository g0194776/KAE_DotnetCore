using System.Net.Sockets;
using KJFramework.Cores;
using KJFramework.Tracing;

namespace KJFramework.Net.Caches
{
    /// <summary>
    ///     套接字异步对象存根
    /// </summary>
    public class NoBuffSocketStub : IClearable
    {
        #region Constructor.

        /// <summary>
        ///     套接字IO对象数据存根
        /// </summary>
        public NoBuffSocketStub()
        {
            Target = new SocketAsyncEventArgs();
            Target.Completed += Completed;
        }

        #endregion

        #region Members.

        private static readonly ITracing _tracing = TracingManager.GetTracing(typeof (NoBuffSocketStub));

        /// <summary>
        ///     获取缓存目标
        /// </summary>
        public SocketAsyncEventArgs Target { get; }

        /// <summary>
        ///     获取或设置附属属性
        /// </summary>
        public object Tag { get; set; }

        #endregion

        #region Methods.

        public void Clear()
        {
            Tag = null;
            Target.AcceptSocket = null;
            Target.UserToken = null;
            Target.RemoteEndPoint = null;
            Target.SetBuffer(null, 0, 0);
            SocketHelper.Clear(Target);
        }

        #endregion

        #region Events

        void Completed(object sender, SocketAsyncEventArgs e)
        {
            IFixedCacheStub<NoBuffSocketStub> stub;
            switch (e.LastOperation)
            {
                    //send complated event.
                    case SocketAsyncOperation.Send:
                    #region Send Completed.

                    stub = (IFixedCacheStub<NoBuffSocketStub>) e.UserToken;
                    TcpTransportChannel channel = (TcpTransportChannel) stub.Tag;
                    //giveback it at first.
                    ChannelConst.NoBuffAsyncStubPool.Giveback(stub);
                    if (e.SocketError != SocketError.Success && channel.IsConnected)
                    {
                        _tracing.Warn(
                            string.Format(
                                "The target channel SendAsync status has incorrectly, so the framework decided to disconnect it.\r\nL: {0}\r\nR: {1}\r\nSocket-Error: {2}\r\nBytesTransferred: {3}\r\n",
                                channel.LocalEndPoint, 
                                channel.RemoteEndPoint, 
                                e.SocketError,
                                e.BytesTransferred));
                        channel.Disconnect();
                    }

                    #endregion
                    break;
                    //send complated event.
                    case SocketAsyncOperation.Receive:
                        throw new System.Exception("#We can't support NoBuffSocketStub to subscribe the event of Complete for Socket.ReadAsync.");
            }
        }

        #endregion
    }
}