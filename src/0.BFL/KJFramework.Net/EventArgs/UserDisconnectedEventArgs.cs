using System;

namespace KJFramework.Net.EventArgs
{
    public delegate void DELEGATE_USERDISCONNECTED<I>(Object sender, UserDisconnectedEventArgs<I> e);
    /// <summary>
    ///     用户断开连接事件
    /// </summary>
    /// <remarks>
    ///     当用户失去与现有的服务器连接后，触发该事件。
    /// </remarks>
    public class UserDisconnectedEventArgs<I> : System.EventArgs
    {
        #region Construtcor.

        /// <summary>
        ///     用户断开连接事件
        /// </summary>
        /// <param name="user" type="T">
        ///     <para>
        ///         用户对象
        ///     </para>
        /// </param>
        public UserDisconnectedEventArgs(I user)
        {
            User = user;
        }

        #endregion

        #region Members.

        public I User { get; }

        #endregion
    }
}
