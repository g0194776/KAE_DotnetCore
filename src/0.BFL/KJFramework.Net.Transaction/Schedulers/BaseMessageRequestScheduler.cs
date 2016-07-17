using System;
using System.Collections.Generic;
using System.Diagnostics;
using KJFramework.EventArgs;
using KJFramework.Net.Identities;
using KJFramework.Net.Transaction.Agent;
using KJFramework.Net.Transaction.Messages;
using KJFramework.Net.Transaction.Objects;
using KJFramework.Net.Transaction.Processors;
using KJFramework.Tracing;

namespace KJFramework.Net.Transaction.Schedulers
{
    /// <summary>
    ///     请求分发器，提供了相关的基本操作
    /// </summary>
    public class BaseMessageRequestScheduler: IRequestScheduler<BaseMessage>
    {
        #region Constructor.

        /// <summary>
        ///     请求分发器，提供了相关的基本操作
        /// </summary>
        public BaseMessageRequestScheduler()
        {
            _perfCategroy = string.Format("DynamicPerf::{0}", Process.GetCurrentProcess().ProcessName);
        }

        #endregion

        #region Members.

        private readonly object _lockObj = new object();
        private readonly object _processorLockObj = new object();
        private static readonly ITracing _tracing = TracingManager.GetTracing(typeof(BaseMessageRequestScheduler));
        private readonly IList<IConnectionAgent> _agents = new List<IConnectionAgent>();
        private readonly Dictionary<Protocols, ProcessorObject> _processors = new Dictionary<Protocols, ProcessorObject>();
        private readonly string _perfCategroy;

        #endregion

        #region Implementation of IRequestScheduler

        /// <summary>
        ///     注册一个连接代理器
        /// </summary>
        /// <param name="agent">连接代理器</param>
        /// <exception cref="ArgumentNullException">参数不能为空</exception>
        public void Regist(IServerConnectionAgent<BaseMessage> agent)
        {
            if (agent == null) throw new ArgumentNullException(nameof(agent));
            lock (_lockObj) _agents.Add(agent);
            agent.Disconnected += Disconnected;
            agent.NewTransaction += NewTransaction;
        }

        /// <summary>
        ///     注册一个消息处理器
        /// </summary>
        /// <param name="protocol">消息处理协议</param>
        /// <param name="processor">处理器</param>
        /// <exception cref="ArgumentNullException">参数不能为空</exception>
        public IRequestScheduler<BaseMessage> Regist(Protocols protocol, IMessageProcessor processor)
        {
            if (processor == null) throw new ArgumentNullException(nameof(processor));
            ProcessorObject p;
            lock (_processorLockObj)
            {
                if (_processors.TryGetValue(protocol, out p)) return this;
                p = new ProcessorObject {Processor = processor};
                _processors.Add(protocol, p);
                return this;
            }
        }

        #endregion

        #region Events

        void NewTransaction(object sender, LightSingleArgEventArgs<IMessageTransaction<BaseMessage>> e)
        {
            ProcessorObject obj;
            BusinessMessageTransaction transaction = (BusinessMessageTransaction)e.Target;
            MessageIdentity identity = transaction.Request.MessageIdentity;
            if (!_processors.TryGetValue(new Protocols { ProtocolId = identity.ProtocolId, ServiceId = identity.ServiceId, DetailsId = identity.DetailsId }, out obj))
            {
                _tracing.Error("#Schedule message failed, because cannot find processor. #P:{0}, S{1}, D{2}", identity.ProtocolId, identity.ServiceId, identity.DetailsId);
                return;
            }
            try
            {
                obj.Processor.Process(transaction);
            }
            catch (System.Exception ex) { _tracing.Error(ex, null);  }
        }

        void Disconnected(object sender, System.EventArgs e)
        {
            IServerConnectionAgent<BaseMessage> agent = (IServerConnectionAgent<BaseMessage>)sender;
            agent.Disconnected -= Disconnected;
            agent.NewTransaction -= NewTransaction;
            lock (_lockObj) _agents.Remove(agent);
        }

        #endregion
    }
}