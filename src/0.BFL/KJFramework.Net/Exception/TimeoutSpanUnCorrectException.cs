namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     超时器超时间隔不正确
    /// </summary>
    /// <remarks>
    ///     当超时间隔小于0的时候触发该异常。
    /// </remarks>
    public class TimeoutSpanUnCorrectException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     超时器超时间隔不正确
        /// </summary>
        /// <remarks>
        ///     当超时间隔小于0的时候触发该异常。
        /// </remarks>
        public TimeoutSpanUnCorrectException() : base("超时器超时间隔不正确 !")
        {
        }

        #endregion

    }
}
