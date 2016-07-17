namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     接收缓冲大小不正确异常
    /// </summary>
    public class RecevieBufferSizeUnCorrectException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     接收缓冲大小不正确异常
        /// </summary>
        public RecevieBufferSizeUnCorrectException() : base("接收缓冲大小不正确 !")
        {
        }

        #endregion

    }
}
