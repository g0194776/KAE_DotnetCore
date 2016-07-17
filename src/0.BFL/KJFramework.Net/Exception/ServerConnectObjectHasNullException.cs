namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     服务器连接对象为空异常
    /// </summary>
    public class ServerConnectObjectHasNullException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     服务器连接对象为空异常
        /// </summary>
        public ServerConnectObjectHasNullException() : base("服务器连接对象不能为空 !")
        {
        }

        #endregion

    }
}
