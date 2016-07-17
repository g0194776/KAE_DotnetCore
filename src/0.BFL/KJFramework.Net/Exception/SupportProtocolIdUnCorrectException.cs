namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     协议类型不正确异常
    /// </summary>
    public class SupportProtocolIdUnCorrectException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     协议类型不正确异常
        /// </summary>
        public SupportProtocolIdUnCorrectException() : base("协议ID类型不正确")
        {
        }

        #endregion

    }
}
