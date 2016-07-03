using System;

namespace KJFramework.EventArgs
{
    public delegate void DELEGATE_SERVERHREAT(Object sender, ServerHreatEventArgs e);
    /// <summary>
    ///     服务器心跳事件
    /// </summary>
    public class ServerHreatEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     服务器心跳事件
        /// </summary>
        /// <param name="serverID" type="int">
        ///     <para>
        ///         服务器编号
        ///     </para>
        /// </param>
        public ServerHreatEventArgs(int serverID)
        {
            ServerID = serverID;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     服务器编号
        /// </summary>
        public int ServerID { get; }

        #endregion
    }
}
