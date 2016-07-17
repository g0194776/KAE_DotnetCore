namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     服务器网络流未设置
    /// </summary>
    public class ServerStreamHasNullException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     服务器网络流未设置
        /// </summary>
        public ServerStreamHasNullException() : base("服务器网络流未设置 !")
        {
        }

        #endregion

    }
}
