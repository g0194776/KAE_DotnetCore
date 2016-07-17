namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     消息未找到异常
    /// </summary>
    /// <remarks>
    ///     当使用的消息对象为null时，触发该异常
    /// </remarks>
    public class NetMessageHasNullException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     消息未找到异常
        /// </summary>
        /// <remarks>
        ///     当使用的消息对象为null时，触发该异常
        /// </remarks>
        public NetMessageHasNullException() : base("消息不能为null !")
        {
        }

        #endregion

    }
}
