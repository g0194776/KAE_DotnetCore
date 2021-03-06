﻿using KJFramework.Net.Transaction.Contexts;
using KJFramework.Net.Transaction.Messages;
using KJFramework.Tracing;
using System;
using KJFramework.Net.Identities;

namespace KJFramework.Net.Transaction
{
    /// <summary>
    ///     基础业务消息事务，提供了相关的基本操作
    /// </summary>
    public class BusinessMessageTransaction : MessageTransaction<BaseMessage>
    {
        #region Constructor.

        /// <summary>
        ///     基础业务消息事务，提供了相关的基本操作
        /// </summary>
        public BusinessMessageTransaction()
        {
        }

        /// <summary>
        ///     基础业务消息事务，提供了相关的基本操作
        /// </summary>
        /// <param name="channel">消息通信信道</param>
        public BusinessMessageTransaction(IMessageTransportChannel<BaseMessage> channel)
            : base(channel)
        {
        }

        /// <summary>
        ///     基础业务消息事务，提供了相关的基本操作
        /// </summary>
        /// <param name="lease">事务生命租期租约</param>
        /// <param name="channel">消息通信信道</param>
        public BusinessMessageTransaction(ILease lease, IMessageTransportChannel<BaseMessage> channel)
            : base(lease, channel)
        {
        }

        #endregion
        
        #region Members.

        protected static readonly ITracing _tracing = TracingManager.GetTracing(typeof(BusinessMessageTransaction));
        /// <summary>
        ///     获取或设置相关上下文
        /// </summary>
        public BusinessTransactionContext Context { get; set; }
        /// <summary>
        ///     获取或设置请求消息
        /// </summary>
        public override BaseMessage Request
        {
            get
            {
                return base.Request;
            }
            set
            {
                //calc REQ time.
                RequestTime = DateTime.Now;
                base.Request = value;
            }
        }

        #endregion

        #region Overrides of MessageTransaction<BaseMessage>

        /// <summary>
        ///     发送一个应答消息
        /// </summary>
        /// <param name="response">要发送的应答消息</param>
        public override void SetResponse(BaseMessage response)
        {
            //calc RSP time.
            ResponseTime = DateTime.Now;
            base.SetResponse(response);
        }

        /// <summary>
        ///     发送一个请求消息
        /// </summary>
        /// <param name="message">请求消息</param>
        public override void SendRequest(BaseMessage message)
        {
            if (message == null) return;
            if (_fixedMsgIdentity) message.MessageIdentity = _msgIdentity;
            message.TransactionIdentity = Identity;
            message.TransactionIdentity.IsRequest = true;
            message.ExpireTime = _lease.ExpireTime;
            message.KPPUniqueId = KPPUniqueId;
            _request = message;
            if (!_channel.IsConnected)
            {
                _tracing.Warn("Cannot send a response message to {0}, because target msg channel has been disconnected.", _channel.RemoteEndPoint);
                TransactionManager.Remove(Identity);
                FailedHandler(null);
                return;
            }
            try
            {
                int sendCount;
                //send failed.
                if ((sendCount = _channel.Send(message)) < 0)
                {
                    TransactionManager.Remove(Identity);
                    _channel.Disconnect();
                    FailedHandler(null);
                    return;
                }
                //calc REQ time.
                RequestTime = DateTime.Now;
                _tracing.Info("SendCount: {0}\r\nL: {1}\r\nR: {2}\r\n{3}", sendCount, _channel.LocalEndPoint, _channel.RemoteEndPoint, message.ToString());
            }
            catch
            {
                TransactionManager.Remove(Identity);
                _channel.Disconnect();
                FailedHandler(null);
            }
        }

        /// <summary>
        ///     发送一个响应消息
        /// </summary>
        /// <param name="message">响应消息</param>
        public override void SendResponse(BaseMessage message)
        {
            SendResponse(message, true);
        }

        /// <summary>
        ///     发送一个响应消息
        /// </summary>
        /// <param name="message">响应消息</param>
        /// <param name="autoTransactionIdentity">一个标示，指示了当前是否在应答消息中加入请求消息的事务唯一标示 </param>
        public void SendResponse(BaseMessage message, bool autoTransactionIdentity)
        {
            _response = message;
            if (message == null || Identity.IsOneway) return;
            if(_request.TransactionIdentity != null)
            {
                message.TransactionIdentity = Identity;
                message.TransactionIdentity.IsRequest = false;
            }
            //Automatically calculate the RSP message's protocol.
            MessageIdentity messageIdentity = _request.MessageIdentity;
            messageIdentity.DetailsId += 1;
            message.MessageIdentity = messageIdentity;
            if (!_channel.IsConnected)
            {
                _tracing.Warn("Cannot send a response message to {0}, because target msg channel has been disconnected.", _channel.RemoteEndPoint);
                return;
            }
            try
            {
                int sendCount = _channel.Send(message);
                if (sendCount == 0)
                {
                    _tracing.Warn(
                        "#Cannot send binary data to remote endpoint, serialized data maybe is null. \r\n#Ref protocol P: {0}, S: {1}, D: {2}\r\n#Ref Instant Message: \r\n{3}",
                        message.MessageIdentity.ProtocolId, 
                        message.MessageIdentity.ServiceId,
                        message.MessageIdentity.DetailsId,
                        message);
                    return;
                }
                //send failed.
                if (sendCount < 0)
                {
                    _channel.Disconnect();
                    FailedHandler(null);
                    return;
                }
                //calc RSP time.
                ResponseTime = DateTime.Now;
                _tracing.Info("SendCount: {0}\r\nL: {1}\r\nR: {2}\r\n{3}", sendCount, _channel.LocalEndPoint, _channel.RemoteEndPoint, message.ToString());
            }
            catch
            {
                _channel.Disconnect();
                FailedHandler(null);
            }
        }

        #endregion
    }
}