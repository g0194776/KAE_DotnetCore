using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace KJFramework.Net.Configurations
{
    /// <summary>
    ///    KJFramework网络底层内部配置项集合
    /// </summary>
    internal sealed class ChannelInternalConfigSettings
    {
        #region Members.

        /// <summary>
        ///    获取或设置基于老版本缓冲区的总体大小
        /// </summary>
        public int RecvBufferSize { get; set; }
        /// <summary>
        ///     获取或设置SocketAsyncEventArgs缓存的数量
        /// </summary>
        public int BuffStubPoolSize { get; set; }
        /// <summary>
        ///     获取或设置基于命名管道的缓冲池大小
        /// </summary>
        public int NamedPipeBuffStubPoolSize { get; set; }
        /// <summary>
        ///     获取或设置发送不关联任何BUFF的缓冲对象个数
        /// </summary>
        public int NoBuffStubPoolSize { get; set; }
        /// <summary>
        ///     获取或设置最大消息长度
        /// </summary>
        public int MaxMessageDataLength { get; set; }
        /// <summary>
        ///     获取或设置内存缓冲区中每一个内存分片的大小
        /// </summary>
        public int SegmentSize { get; set; }

        #endregion

        #region Methods.

        /// <summary>
        ///     尝试从一个全局配置对象中解析出当前的配置节信息
        /// </summary>
        /// <param name="configuration">全局的配置对象</param>
        /// <param name="settings">如果解析成功，则返回解析后的对象</param>
        /// <returns>返回一个是否解析成功的标识</returns>
        public static bool TryParse(IConfiguration configuration, out ChannelInternalConfigSettings settings)
        {
            settings = null;
            if (configuration["sys:KJFramework.Net.Channels"] == null) return false;
            settings = JsonConvert.DeserializeObject<ChannelInternalConfigSettings>(configuration["sys:KJFramework.Net.Channels"]);
            return true;
        }

        #endregion
    }
}