namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     消息接收器为空异常
    /// </summary>
    public class MessageRecevierHasNullException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     消息接收器为空异常
        /// </summary>
        public MessageRecevierHasNullException() : base("消息接收器为空 !")
        {
        }

        #endregion

    }
}
