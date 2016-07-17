namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     服务器远程终端错误异常
    /// </summary>
    public class ServerIPEndPointUnCorrectException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     服务器远程终端错误异常
        /// </summary>
        public ServerIPEndPointUnCorrectException() : base("服务器远程终端错误 !")
        {
        }

        #endregion

    }
}
