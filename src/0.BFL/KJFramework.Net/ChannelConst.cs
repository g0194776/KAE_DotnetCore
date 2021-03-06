﻿using System;
using KJFramework.Configurations;
using KJFramework.Containers;
using KJFramework.Net.Caches;
using KJFramework.Net.Configurations;

namespace KJFramework.Net
{
    /// <summary>
    ///   KJFramework网络底层配置
    /// </summary>
    public static class ChannelConst
    {
        /// <summary>
        ///    获取或设置基于老版本缓冲区的总体大小
        /// </summary>
        public static int RecvBufferSize;
        /// <summary>
        ///     获取或设置SocketAsyncEventArgs缓存的数量
        /// </summary>
        public static int BuffStubPoolSize;
        /// <summary>
        ///     获取或设置基于命名管道的缓冲池大小
        /// </summary>
        public static int NamedPipeBuffStubPoolSize;
        /// <summary>
        ///     获取或设置发送不关联任何BUFF的缓冲对象个数
        /// </summary>
        public static int NoBuffStubPoolSize;
        /// <summary>
        ///     获取或设置最大消息长度
        /// </summary>
        public static int MaxMessageDataLength;
        /// <summary>
        ///     获取或设置内存缓冲区中每一个内存分片的大小
        /// </summary>
        public static int SegmentSize;


        //最终计算好的总共内存缓冲区大小
        private static int _memoryChunkSize;
        private static bool _initialized;
        internal static IMemoryChunkCacheContainer SegmentContainer;
        internal static ICacheTenant Tenant;
        internal static IFixedCacheContainer<SocketBuffStub> BuffAsyncStubPool;
        internal static IFixedCacheContainer<BuffStub> NamedPipeBuffPool;
        internal static IFixedCacheContainer<NoBuffSocketStub> NoBuffAsyncStubPool;

        #region Methods

        /// <summary>
        ///     初始化KJFramework全局的底层网络缓冲区
        /// </summary>
        public static void Initialize()
        {
            ChannelInternalConfigSettings settings;
            if (!ChannelInternalConfigSettings.TryParse(SystemConfigurations.Configuration, out settings))
            {
                settings = new ChannelInternalConfigSettings();
                settings.RecvBufferSize = 4096;
                settings.BuffStubPoolSize = 200000;
                settings.NamedPipeBuffStubPoolSize = 200000;
                settings.NoBuffStubPoolSize = 200000;
                settings.MaxMessageDataLength = 5120;
                settings.SegmentSize = 5120;
            }
            Initialize(settings);
        }

        /// <summary>
        ///     按照一个配置集来初始化KJFramework全局的底层网络缓冲区
        /// </summary>
        internal static void Initialize(ChannelInternalConfigSettings settings)
        {
            if (_initialized) return;
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            //initializes global value.
            RecvBufferSize = settings.RecvBufferSize;
            BuffStubPoolSize = settings.BuffStubPoolSize;
            NamedPipeBuffStubPoolSize = settings.NamedPipeBuffStubPoolSize;
            NoBuffStubPoolSize = settings.NoBuffStubPoolSize;
            MaxMessageDataLength = settings.MaxMessageDataLength;
            SegmentSize = settings.SegmentSize;
            _memoryChunkSize = SegmentSize*(BuffStubPoolSize + NamedPipeBuffStubPoolSize);
            SegmentContainer = new MemoryChunkCacheContainer(SegmentSize, _memoryChunkSize);
            Tenant = new CacheTenant();
            BuffAsyncStubPool = Tenant.Rent<SocketBuffStub>("Pool::BuffSocketIOStub", BuffStubPoolSize);
            NamedPipeBuffPool = Tenant.Rent<BuffStub>("Pool::NamedPipeIOStub", NamedPipeBuffStubPoolSize);
            NoBuffAsyncStubPool = Tenant.Rent<NoBuffSocketStub>("Pool::NoBuffSocketIOStub", NoBuffStubPoolSize);
            _initialized = true;
        }

        #endregion
    }
}