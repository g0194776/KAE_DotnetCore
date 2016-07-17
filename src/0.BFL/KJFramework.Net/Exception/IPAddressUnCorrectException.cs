namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     IP地址错误异常
    /// </summary>
    public class IPAddressUnCorrectException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     IP地址错误异常
        /// </summary>
        public IPAddressUnCorrectException() : base("IP地址错误 !")
        {
        }

        #endregion

    }
}
