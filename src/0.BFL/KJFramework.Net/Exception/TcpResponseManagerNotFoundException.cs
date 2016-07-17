namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     TCP消息响应管理器未找到异常
    /// </summary>
    /// <remarks>
    ///     当TCP消息响应管理器 = null时，触发该异常。
    /// </remarks>
    public class TcpResponseManagerNotFoundException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     TCP消息响应管理器未找到异常
        /// </summary>
        /// <remarks>
        ///     当TCP消息响应管理器 = null时，触发该异常。
        /// </remarks>
        public TcpResponseManagerNotFoundException()
            : base("TCP消息响应管理器未找到 !")
        {
        }

        #endregion

    }
}
