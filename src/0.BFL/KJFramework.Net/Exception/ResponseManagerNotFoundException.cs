namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     消息响应器未找到异常
    /// </summary>
    public class ResponseManagerNotFoundException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     消息响应器未找到异常
        /// </summary>
        public ResponseManagerNotFoundException() : base("消息响应器未找到 !")
        {
        }

        #endregion

    }
}
