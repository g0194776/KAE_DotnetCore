using System;
using System.Net.Sockets;

namespace KJFramework.Net
{
    /// <summary>
    ///     套接字帮助器
    /// </summary>
    internal static class SocketHelper
    {
        #region Constructor

        /// <summary>
        ///     套接字帮助器
        /// </summary>
        static SocketHelper()
        {
        }

        #endregion

        #region Membes

        private static readonly Action<SocketAsyncEventArgs> _clearMethod;

        #endregion

        #region Methods

        /// <summary>
        ///     清理一个SocketAsyncEventArgs内部资源
        /// </summary>
        /// <param name="args">SocketAsyncEventArgs</param>
        public static void Clear(SocketAsyncEventArgs args)
        {
        }

        #endregion
    }
}