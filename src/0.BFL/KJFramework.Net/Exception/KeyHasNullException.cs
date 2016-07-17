namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     关键字为空异常
    /// </summary>
    public class KeyHasNullException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     关键字为空异常
        /// </summary>
        public KeyHasNullException()
            : base("关键字为null !")
        {

            #endregion
        }
    }
}
