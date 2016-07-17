using System;

namespace KJFramework.Net.Channel
{
    /// <summary>
    ///     基础的通道信息, 提供了相关的通道信息结构
    /// </summary>
    public class BasicChannelInfomation
    {
        #region Members.

        /// <summary>
        ///     获取或设置对方服务端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        ///     获取通道的创建时间
        /// </summary>
        public DateTime CreateTime => DateTime.Now;

        #endregion
    }
}
