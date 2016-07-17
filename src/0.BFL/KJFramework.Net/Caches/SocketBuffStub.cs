using System;
using System.Collections.Generic;
using System.Net.Sockets;
using KJFramework.Cores;
using KJFramework.Net.Receivers;
using KJFramework.Tracing;

namespace KJFramework.Net.Caches
{
    /// <summary>
    ///     �׽����첽������
    ///     <para>* �����ʹ���������һ���ڴ滺����</para>
    /// </summary>
    public class SocketBuffStub : BuffStub
    {
        #region Constructor.

        /// <summary>
        ///     �׽���IO�������ݴ��
        /// </summary>
        public SocketBuffStub()
        {
            Target = new SocketAsyncEventArgs();
            Target.BufferList = new List<ArraySegment<byte>> {Segment.Segment};
            Target.Completed += Completed;
        }

        #endregion

        #region Members.

        private static readonly ITracing _tracing = TracingManager.GetTracing(typeof(SocketBuffStub));

        /// <summary>
        ///     ��ȡ����Ŀ��
        /// </summary>
        public SocketAsyncEventArgs Target { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     ������Դ
        /// </summary>
        public override void Clear()
        {
            Target.AcceptSocket = null;
            Target.UserToken = null;
            Target.RemoteEndPoint = null;
            SocketHelper.Clear(Target);
            base.Clear();
        }

        #endregion

        #region Events

        void Completed(object sender, SocketAsyncEventArgs e)
        {
            IFixedCacheStub<SocketBuffStub> stub;
            switch (e.LastOperation)
            {
                    //send complated event.
                    case SocketAsyncOperation.Send:
                    #region Send Completed.

                    stub = (IFixedCacheStub<SocketBuffStub>)e.UserToken;
                    TcpTransportChannel channel = (TcpTransportChannel) stub.Tag;
                    if (e.SocketError != SocketError.Success && channel.IsConnected)
                    {
                        _tracing.Warn(
                            string.Format(
                                "The target channel SendAsync status has incorrectly, so the framework decided to disconnect it.\r\nL: {0}\r\nR: {1}\r\nSocket-Error: {2}\r\nBytesTransferred: {3}\r\n",
                                channel.LocalEndPoint, 
                                channel.RemoteEndPoint, 
                                e.SocketError,
                                e.BytesTransferred));
                        //giveback it at first.
                        ChannelConst.BuffAsyncStubPool.Giveback(stub);
                        channel.Disconnect();
                    }

                    #endregion
                    break;
                    //send complated event.
                    case SocketAsyncOperation.Receive:
                    #region Recv Completed.

                    stub = (IFixedCacheStub<SocketBuffStub>)e.UserToken;
                    TcpAsynDataRecevier recevier = (TcpAsynDataRecevier)stub.Tag;
                    try { recevier.ProcessReceive(stub); }
                    catch (System.Exception ex) { _tracing.Error(ex, null); }

                    #endregion
                    break;
            }
        }

        #endregion
    }
}