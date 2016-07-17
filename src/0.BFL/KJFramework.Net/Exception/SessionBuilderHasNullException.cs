namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     会话构造器为空异常
    /// </summary>
    public class SessionBuilderHasNullException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     会话构造器为空异常
        /// </summary>
        public SessionBuilderHasNullException() : base("会话构造器不能为空 !")
        {
        }

        #endregion

    }
}
