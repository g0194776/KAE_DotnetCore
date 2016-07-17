namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     服务器代理器为空异常
    /// </summary>
    public class ServerAgentHasNullException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     服务器代理器为空异常
        /// </summary>
        public ServerAgentHasNullException() : base("服务器代理器为空 ！")
        {
        }

        #endregion

    }
}
