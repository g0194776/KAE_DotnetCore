namespace KJFramework.Exceptions
{
    /// <summary>
    ///     文件未找到异常
    /// </summary>
    public class FileNotFoundException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     文件未找到异常
        /// </summary>
        public FileNotFoundException() : base("文件未找到 !")
        {
        }

        #endregion
    }
}