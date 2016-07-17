namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     连接ID错误异常
    /// </summary>
    /// <remarks>
    ///     当连接ID小于0的时候触发该异常。
    /// </remarks>
    public class ConnectIdUnCorrectException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     连接ID错误异常
        /// </summary>
        /// <remarks>
        ///     当连接ID小于0的时候触发该异常。
        /// </remarks>
        public ConnectIdUnCorrectException() : base("连接ID错误 !")
        {
        }

        #endregion

    }
}
