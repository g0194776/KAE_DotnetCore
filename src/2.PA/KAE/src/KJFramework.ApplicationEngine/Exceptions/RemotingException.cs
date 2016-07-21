namespace KJFramework.ApplicationEngine.Exceptions
{
    /// <summary>
    ///     通信失败异常
    /// </summary>
    public class RemotingException : System.Exception
    {
        #region Constructor.

        /// <summary>
        /// 用指定的错误消息初始化 <see cref="T:System.Exception"/> 类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        public RemotingException(string message) : base(message)
        {
        }

        /// <summary>
        /// 初始化 <see cref="T:System.Exception"/> 类的新实例。
        /// </summary>
        public RemotingException()
        {
        }

        #endregion
    }
}