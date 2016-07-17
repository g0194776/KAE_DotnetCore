namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     探测端口出现错误异常
    /// </summary>
    public class DirectPortUnCorrectException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     探测端口出现错误异常
        /// </summary>
        public DirectPortUnCorrectException() : base("探测端口出现错误 !")
        {
        }

        #endregion

    }
}
