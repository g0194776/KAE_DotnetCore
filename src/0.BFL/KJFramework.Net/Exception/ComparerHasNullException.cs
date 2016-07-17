namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     比较器为空异常
    /// </summary>
    public class ComparerHasNullException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     比较器为空异常
        /// </summary>
        public ComparerHasNullException() : base("比较器为空 !")
        {
        }

        #endregion

    }
}
