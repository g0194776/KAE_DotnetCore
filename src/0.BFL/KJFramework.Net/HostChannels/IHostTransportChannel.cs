using System;
using KJFramework.EventArgs;

namespace KJFramework.Net.HostChannels
{
    /// <summary>
    ///     宿主信道接口
    /// </summary>
    public interface IHostTransportChannel
    {
        #region Members.

        /// <summary>
        ///     获取或设置附属标记
        /// </summary>
        object Tag { get; set; }

        /// <summary>
        ///     获取信道唯一编号
        /// </summary>
        Guid Id { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     注册当前宿主信道
        /// </summary>
        /// <returns>返回注册后的状态</returns>
        bool Regist();

        /// <summary>
        ///     注销当前宿主信道
        /// </summary>
        /// <returns>·返回注销后的状态</returns>
        bool UnRegist();

        #endregion

        #region Events.

        /// <summary>
        ///     通信信道被创建的事件
        /// </summary>
        event EventHandler<LightSingleArgEventArgs<ITransportChannel>> ChannelCreated;

        /// <summary>
        ///     通信信道断开后的事件
        /// </summary>
        event EventHandler<LightSingleArgEventArgs<ITransportChannel>> ChannelDisconnected;

        #endregion
    }
}