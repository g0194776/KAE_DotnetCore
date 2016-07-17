using System;

namespace KJFramework.Net.EventArgs
{
    public delegate void DELEGATE_SESSION_EXPIRE<I>(Object sender, SessionExpiredEventArgs<I> e);
    /// <summary>
    ///     会话过期事件
    /// </summary>
    /// <remarks>
    ///     当会话队列中某个会话对象超时过期后，触发该事件。
    /// </remarks>
    public class SessionExpiredEventArgs<I> : System.EventArgs
    {
        #region Constructro.

        /// <summary>
        ///     会话过期事件
        /// </summary>
        /// <param name="expireSession" type="T">
        ///     <para>
        ///         过期的会话对象
        ///     </para>
        /// </param>
        /// <remarks>
        ///     当会话队列中某个会话对象超时过期后，触发该事件。
        /// </remarks>
        public SessionExpiredEventArgs(I expireSession)
        {
            ExpireSession = expireSession;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     过期的会话对象
        /// </summary>
        public I ExpireSession { get; }

        #endregion
    }
}
