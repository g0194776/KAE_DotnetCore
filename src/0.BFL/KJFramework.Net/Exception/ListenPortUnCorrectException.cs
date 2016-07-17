namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     监听端口非法异常
    /// </summary>
    /// <remarks>
    ///     当监听的端口小于等于0 时，触发该异常
    /// </remarks>
    public class ListenPortUnCorrectException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     监听端口非法异常
        /// </summary>
        /// <remarks>
        ///     当监听的端口小于等于0 时，触发该异常
        /// </remarks>
        public ListenPortUnCorrectException() : base("监听端口非法 !")
        {
        }

        #endregion

    }
}
