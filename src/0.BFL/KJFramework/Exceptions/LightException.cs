using System;

namespace KJFramework.Exceptions
{
    /// <summary>
    ///     ʵ����IDisposable�ӿڵ��������쳣�ࡣ
    /// </summary>
    public class LightException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     ʵ����IDisposable�ӿڵ��������쳣�ࡣ
        /// </summary>
        public LightException()
        {
            
        }

        /// <summary>
        ///     ʵ����IDisposable�ӿڵ��������쳣�ࡣ
        /// </summary>
        /// <param name="message">��Ϣ����</param>
        public LightException(String message)
            : base(message)
        {

        }

        #endregion
    }
}