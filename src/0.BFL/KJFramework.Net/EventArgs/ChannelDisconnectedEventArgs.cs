using System;

namespace KJFramework.Net.EventArgs
{
    public delegate void DELEGATE_CHANNEL_DISCONNECTED(Object sender, ChannelDisconnectedEventArgs e);
    /// <summary>
    ///     通道已经断开事件
    /// </summary>
    public class ChannelDisconnectedEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     通道已经断开事件
        /// </summary>
        /// <param name="Key">通道唯一标示类型</param>
        public ChannelDisconnectedEventArgs(int Key)
        {
            this.Key = Key;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     通道唯一标示
        /// </summary>
        public int Key { get; }

        #endregion
    }
}
