namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     消息帮助器为空异常
    /// </summary>
    public class MessageHelperHasNullException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     消息帮助器为空异常
        /// </summary>
        public MessageHelperHasNullException() : base("消息帮助器未找到 !")
        {
        }

        #endregion

    }
}
