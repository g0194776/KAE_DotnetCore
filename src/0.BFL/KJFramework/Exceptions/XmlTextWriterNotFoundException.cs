namespace KJFramework.Exceptions
{
    /// <summary>
    ///     内置XML写入对象未找到异常
    /// </summary>
    public class XmlTextWriterNotFoundException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     内置XML写入对象未找到异常
        /// </summary>
        public XmlTextWriterNotFoundException() : base("内置XML写入对象未找到 !")
        {
        }

        #endregion
    }
}
