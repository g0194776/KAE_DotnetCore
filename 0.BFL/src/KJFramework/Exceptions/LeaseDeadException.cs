namespace KJFramework.Exceptions
{
    /// <summary>
    ///     租约已过期异常
    /// </summary>
    public class LeaseDeadException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     租约已过期异常
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        public LeaseDeadException(string message) : base(message)
        {
        }

        /// <summary>
        ///     租约已过期异常
        /// </summary>
        public LeaseDeadException()
        {
        }

        #endregion
    }
}