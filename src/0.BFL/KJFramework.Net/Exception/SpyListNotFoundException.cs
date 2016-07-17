namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     拦截器列表未找到异常
    /// </summary>
    public class SpyListNotFoundException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     拦截器列表未找到异常
        /// </summary>
        public SpyListNotFoundException() : base("拦截器列表未找到 !")
        {
        }

        #endregion

    }
}
