using System;
using System.Collections;

namespace KJFramework.EventArgs
{
    public delegate void DELEGATE_SERVICE_CHANGE(Object sender, ChangeServiceListEventArgs e);

    /// <summary>
    ///     更换服务列表事件
    /// </summary>
    public class ChangeServiceListEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     更换服务列表事件
        /// </summary>
        /// <param name="serverID" type="int">
        ///     <para>
        ///         服务器编号
        ///     </para>
        /// </param>
        /// <param name="newServiceList" type="System.Collections.ArrayList">
        ///     <para>
        ///         更换的新服务ID列表
        ///     </para>
        /// </param>
        public ChangeServiceListEventArgs(int serverID, ArrayList newServiceList)
        {
            ServerID = serverID;
            NewServiceList = newServiceList;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     服务器编号
        /// </summary>
        public int ServerID { get; }
        /// <summary>
        ///     更换的新服务ID列表
        /// </summary>
        public ArrayList NewServiceList { get; }

        #endregion

    }
}
