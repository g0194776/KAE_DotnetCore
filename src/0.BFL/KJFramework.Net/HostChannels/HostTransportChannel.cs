using System;
using System.Collections.Generic;
using KJFramework.Enums;
using KJFramework.EventArgs;
using KJFramework.Statistics;

namespace KJFramework.Net.HostChannels
{
    /// <summary>
    ///     宿主信道接口
    /// </summary>
    public abstract class HostTransportChannel : IHostTransportChannel
    {
        #region Constructor.

        /// <summary>
        ///     宿主信道接口
        /// </summary>
        protected HostTransportChannel()
        {
            Id = Guid.NewGuid();
        }

        #endregion

        #region Members.

        protected Dictionary<StatisticTypes, IStatistic> _statistics;
        /// <summary>
        ///     获取或设置附属标记
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        ///     获取信道唯一编号
        /// </summary>
        public Guid Id { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     注册当前宿主信道
        /// </summary>
        /// <returns>返回注册后的状态</returns>
        public abstract bool Regist();

        /// <summary>
        ///     注销当前宿主信道
        /// </summary>
        /// <returns>·返回注销后的状态</returns>
        public abstract bool UnRegist();

        #endregion

        #region Events.

        /// <summary>
        ///     通信信道被创建的事件
        /// </summary>
        public event EventHandler<LightSingleArgEventArgs<ITransportChannel>> ChannelCreated;
        protected void ChannelCreatedHandler(LightSingleArgEventArgs<ITransportChannel> e)
        {
            EventHandler<LightSingleArgEventArgs<ITransportChannel>> created = ChannelCreated;
            if (created != null) created(this, e);
        }

        /// <summary>
        ///     通信信道断开后的事件
        /// </summary>
        public event EventHandler<LightSingleArgEventArgs<ITransportChannel>> ChannelDisconnected;
        protected void ChannelDisconnectedHandler(LightSingleArgEventArgs<ITransportChannel> e)
        {
            EventHandler<LightSingleArgEventArgs<ITransportChannel>> handler = ChannelDisconnected;
            if (handler != null) handler(this, e);
        }

        #endregion
    }
}