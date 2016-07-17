namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     连接池数目上限错误异常
    /// </summary>
    public class ConnectionTotalCountUnCorrectException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     连接池数目上限错误异常
        /// </summary>
        public ConnectionTotalCountUnCorrectException() : base("连接池数目上限设置不正确 !")
        {
        }

        #endregion

    }
}
