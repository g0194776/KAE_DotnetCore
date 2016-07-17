namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     消息分配器为空异常
    /// </summary>
    public class MessageDispatcherHasNullException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     消息分配器为空异常
        /// </summary>
        public MessageDispatcherHasNullException() : base("消息分配器为空 !")
        {
        }

        #endregion

    }
}
