using System;
using System.Runtime.InteropServices;

namespace KJFramework.Net.Helper
{
    /// <summary>
    ///     提供了对于固定信息的相关操作
    /// </summary>
    public static class NetHelper
    {
        #region Constructor.

        static NetHelper()
        {
            Initialize();
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public static void Initialize()
        {
            uint dummy = 0;
            KeepAliveValue = new byte[Marshal.SizeOf(dummy) * 3];
            BitConverter.GetBytes((uint)1).CopyTo(KeepAliveValue, 0);//是否启用Keep-Alive
            BitConverter.GetBytes((uint)5000).CopyTo(KeepAliveValue, Marshal.SizeOf(dummy));//多长时间开始第一次探测
            BitConverter.GetBytes((uint)5000).CopyTo(KeepAliveValue, Marshal.SizeOf(dummy) * 2);//探测时间间隔
        }

        #endregion

        #region Members.

        /// <summary>
        ///     TCP协议内置保持存活字节码
        /// </summary>
        public static byte[] KeepAliveValue;

        #endregion
    }
}
