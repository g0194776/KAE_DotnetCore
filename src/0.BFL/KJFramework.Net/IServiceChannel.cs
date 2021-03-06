using System;
using KJFramework.Net.Channel;

namespace KJFramework.Net
{
    /// <summary>
    ///     服务通道元接口，提供了相关的基本操作
    /// </summary>
    public interface IServiceChannel : IChannel<BasicChannelInfomation>, ICommunicationObject
    {
        #region Members.

        /// <summary>
        ///     获取创建时间
        /// </summary>
        DateTime CreateTime { get; }

        /// <summary>
        ///     获取通道唯一标示
        /// </summary>
        Guid Key { get; }

        #endregion
    }
}