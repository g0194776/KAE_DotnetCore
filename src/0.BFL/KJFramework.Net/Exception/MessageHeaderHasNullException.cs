namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     消息头为空异常。
    /// </summary>
    /// <remarks>
    ///     当消息头为null时，则触发该异常。
    /// </remarks>
    public class MessageHeaderHasNullException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     消息头为空异常。
        /// </summary>
        /// <remarks>
        ///     当消息头为null时，则触发该异常。
        /// </remarks>
        public MessageHeaderHasNullException() : base("消息头为空 !")
        {
        }

        #endregion

    }
}
