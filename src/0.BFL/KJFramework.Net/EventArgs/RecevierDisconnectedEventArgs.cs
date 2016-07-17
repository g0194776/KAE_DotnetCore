using System;
namespace KJFramework.Net.EventArgs
{
    /// <summary>
    ///     接收器断开连接事件
    /// </summary>
    public class RecevierDisconnectedEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     接收器断开连接事件
        /// </summary>
        /// <param name="key">唯一标识</param>
        public RecevierDisconnectedEventArgs(String key)
        {
            Key = key;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取或设置唯一标识
        /// </summary>
        public String Key { get; }

        #endregion
    }
}