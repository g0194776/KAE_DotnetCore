using System;
using System.Runtime.InteropServices;

namespace KJFramework.Cores
{
    /// <summary>
    ///     非托管缓存项，提供了相关的基本操作。
    /// </summary>
    internal class UnmanagedCacheItem : IUnmanagedCacheItem
    {
        #region Constructor.

        /// <summary>
        ///     非托管缓存项，提供了相关的基本操作。
        /// </summary>
        /// <param name="size">需要申请的内存大小</param>
        /// <exception cref="ArgumentException">非法的参数取值范围</exception>
        public UnmanagedCacheItem(int size)
        {
            MaxSize = size;
            if (size <= 0) throw new ArgumentException("Illegal unmanaged memory. #size: " + size);
            Handle = Marshal.AllocHGlobal(size);
        }

        /// <summary>
        ///     非托管缓存项，提供了相关的基本操作。
        /// </summary>
        /// <param name="ptr">内存句柄</param>
        /// <param name="size">需要申请的内存大小</param>
        /// <param name="useageSize">已使用长度</param>
        /// <exception cref="ArgumentException">参数错误</exception>
        public UnmanagedCacheItem(IntPtr ptr, int size, int useageSize)
        {
            if (ptr == IntPtr.Zero) throw new ArgumentException("Memory handle can not be zero.");
            MaxSize = size;
            UsageSize = useageSize == 0 ? -1 : useageSize;
            Handle = ptr;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取内存句柄
        /// </summary>
        public IntPtr Handle { get; protected set; } = IntPtr.Zero;
        /// <summary>
        ///     获取当前的使用大小
        /// </summary>
        public int UsageSize { get; protected set; } = -1;
        /// <summary>
        ///     获取当前的最大容量
        /// </summary>
        public int MaxSize { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     获取缓存内容
        /// </summary>
        /// <returns>返回缓存内容</returns>
        public byte[] GetValue()
        {
            byte[] data;
            //all of the data.
            if (UsageSize == -1)
            {
                data = new byte[MaxSize];
                Marshal.Copy(Handle, data, 0, MaxSize);
                return data;
            }
            data = new byte[UsageSize];
            Marshal.Copy(Handle, data, 0, UsageSize);
            return data;
        }

        /// <summary>
        ///     设置缓存内容
        /// </summary>
        /// <param name="obj">缓存对象</param>
        /// <exception cref="ArgumentException">参数取值范围错误</exception>
        /// <exception cref="ArgumentNullException">参数不空为能</exception>
        public void SetValue(byte[] obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (obj.Length > MaxSize) throw new ArgumentException("Out of range size. #size: " + obj.Length);
            UsageSize = obj.Length;
            Marshal.Copy(obj, 0, Handle, obj.Length);
        }

        /// <summary>
        ///     释放当前所持有的非托管缓存
        /// </summary>
        public void Free()
        {
            if (Handle == IntPtr.Zero) return;
            Marshal.FreeHGlobal(Handle);
            Handle = IntPtr.Zero;
        }

        #endregion
    }
}