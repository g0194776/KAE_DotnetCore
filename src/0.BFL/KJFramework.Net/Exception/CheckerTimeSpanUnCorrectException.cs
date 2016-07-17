namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     检查器时间间隔设置不正确异常
    /// </summary>
    public class CheckerTimeSpanUnCorrectException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     检查器时间间隔设置不正确异常
        /// </summary>
        public CheckerTimeSpanUnCorrectException() : base("检查器时间间隔设置不正确 !")
        {
        }

        #endregion

    }
}
