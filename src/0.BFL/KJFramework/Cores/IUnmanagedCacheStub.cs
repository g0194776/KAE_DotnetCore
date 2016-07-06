using System;

namespace KJFramework.Cores
{
    /// <summary>
    ///     非托管缓存存根元接口，提供了相关的基本操作
    /// </summary>
    internal interface IUnmanagedCacheStub : ICacheStub<byte[]>
    {
        #region Members.

        /// <summary>
        ///     获取内存句柄
        /// </summary>
        IntPtr Handle { get; }
        /// <summary>
        ///     获取当前内部的缓存使用量
        /// </summary>
        int CurrentSize { get; }
        /// <summary>
        ///     获取当前缓存的最大容量
        /// </summary>
        int MaxSize { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     放弃当前缓存
        /// </summary>
        void Discard();

        #endregion

    }
}