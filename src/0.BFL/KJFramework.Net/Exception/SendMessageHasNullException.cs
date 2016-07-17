namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     要发送的消息为null异常
    /// </summary>
    public class SendMessageHasNullException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     要发送的消息为null异常
        /// </summary>
        public SendMessageHasNullException() : base("要发送的消息不能为空 !")
        {

        }

        #endregion

    }
}