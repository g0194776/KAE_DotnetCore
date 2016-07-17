namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     检查器为空异常
    /// </summary>
    public class CheckerHasNullException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     检查器为空异常
        /// </summary>
        public CheckerHasNullException() : base("检查器为空 !")
        {
        }

        #endregion

    }
}
