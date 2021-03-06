﻿namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     端口设置错误
    /// </summary>
    /// <remarks>
    ///     当设置的端口小于等于0时，触发该异常
    /// </remarks>
    public class PortUnCorrectException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     端口设置错误
        /// </summary>
        /// <remarks>
        ///     当设置的端口小于等于0时，触发该异常
        /// </remarks>
        public PortUnCorrectException() : base("端口设置错误 !")
        {
        }

        #endregion

    }
}
