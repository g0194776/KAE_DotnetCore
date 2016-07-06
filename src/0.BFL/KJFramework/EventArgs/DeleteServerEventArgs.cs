using System;

namespace KJFramework.EventArgs
{
    public delegate void DELEGATE_DELETE_SERVER(Object sender, DeleteServerEventArgs e) ;
    /// <summary>
    ///     删除服务器连接对象事件
    /// </summary>
    public class DeleteServerEventArgs: System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///      删除服务器连接对象事件
        /// </summary>
        /// <param name="serverID" type="int">
        ///     <para>
        ///         服务器编号
        ///     </para>
        /// </param>
        public DeleteServerEventArgs(int serverID)
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
