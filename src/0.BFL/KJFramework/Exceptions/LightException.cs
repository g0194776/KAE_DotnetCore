using System;

namespace KJFramework.Exceptions
{
    /// <summary>
    ///     实现了IDisposable接口的轻量级异常类。
    /// </summary>
    public class LightException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     实现了IDisposable接口的轻量级异常类。
        /// </summary>
        public LightException()
        {
            
        }

        /// <summary>
        ///     实现了IDisposable接口的轻量级异常类。
        /// </summary>
        /// <param name="message">消息内容</param>
        public LightException(String message)
            : base(message)
        {

        }

        #endregion
    }
}