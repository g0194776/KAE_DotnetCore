namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     传输消息创建器未找到异常
    /// </summary>
    public class TransmessionMessageBuilderNotFoundException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     传输消息创建器未找到异常
        /// </summary>
        public TransmessionMessageBuilderNotFoundException() : base("传输消息创建器未找到")
        {
        }

        #endregion

    }
}
