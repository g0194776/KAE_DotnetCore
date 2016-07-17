using System;

namespace KJFramework.Net.EventArgs
{
    public delegate void DELEGATE_USERHREAT_TIMEOUT<I>(Object sender, UserHreatTimeoutEventArgs<I> e);
    /// <summary>
    ///     用户心跳超时事件
    /// </summary>
    /// <remarks>
    ///     当用户未心跳事件超过了预定的间隔后将会触发该事件。
    /// </remarks>
    public class UserHreatTimeoutEventArgs<I> : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     用户心跳超时事件
        /// </summary>
        /// <param name="timeoutUser" type="T">
        ///     <para>
        ///         超时的用户
        ///     </para>
        /// </param>
        /// <remarks>
        ///     当用户未心跳事件超过了预定的间隔后将会触发该事件。
        /// </remarks>
        public UserHreatTimeoutEventArgs(I timeoutUser)
        {
            TimeoutUser = timeoutUser;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     超时的用户
        /// </summary>
        public I TimeoutUser { get; }

        #endregion
    }
}
