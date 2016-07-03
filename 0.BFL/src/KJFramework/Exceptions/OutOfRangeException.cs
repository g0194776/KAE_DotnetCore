namespace KJFramework.Exceptions
{
    /// <summary>
    ///     超出范围异常
    /// </summary>
    public class OutOfRangeException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     指定参数超出了范围
        /// </summary>
        /// <param name="message">错误信息</param>
        public OutOfRangeException(string message)
            : base(message)
        {

        }

        #endregion
    }
}