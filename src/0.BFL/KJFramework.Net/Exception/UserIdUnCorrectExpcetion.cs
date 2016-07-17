namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     用户ID设置不正确异常
    /// </summary>
    /// <remarks>
    ///     当用户ID小于0时触发该异常。
    /// </remarks>
    public class UserIdUnCorrectExpcetion : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     用户ID设置不正确
        /// </summary>
        /// <remarks>
        ///     当用户ID小于0时触发该异常。
        /// </remarks>
        public UserIdUnCorrectExpcetion() : base("用户ID设置不正确 !")
        {
        }

        #endregion

    }
}
