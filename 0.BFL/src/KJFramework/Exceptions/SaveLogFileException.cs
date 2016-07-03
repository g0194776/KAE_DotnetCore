namespace KJFramework.Exceptions
{
    /// <summary>
    ///     保存日志文件失败异常
    /// </summary>
    public class SaveLogFileException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     保存日志文件失败异常
        /// </summary>
        public SaveLogFileException() : base("保存日志文件失败 !")
        {
        }

        #endregion
    }
}
