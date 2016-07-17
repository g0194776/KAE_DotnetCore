using System;
using KJFramework.Attribute;
using KJFramework.Net.Transaction.Enums;
using Microsoft.Extensions.Configuration;

namespace KJFramework.Net.Transaction.Configurations
{
    /// <summary>
    ///     相关配置项 
    /// </summary>
    public sealed class SettingConfiguration
    {
        #region Members.

        /// <summary>
        ///     事务超时时间
        /// </summary>
        [CustomerField("TransactionTimeout")]
        public TimeSpan TransactionTimeout { get; set; }

        /// <summary>
        ///    事务超时检查时间间隔
        /// </summary>
        [CustomerField("TransactionCheckInterval")]
        public int TransactionCheckInterval { get; set; }

        /// <summary>
        ///    最小连接数(在相同的远程终结点地址情况下)
        /// </summary>
        [CustomerField("MinimumConnectionCount")]
        public int MinimumConnectionCount { get; set; }

        /// <summary>
        ///    最大连接数(在相同的远程终结点地址情况下)
        /// </summary>
        [CustomerField("MaximumConnectionCount")]
        public int MaximumConnectionCount { get; set; }

        /// <summary>
        ///    并行网络连接的分发策略
        /// </summary>
        [CustomerField("ConnectionLoadBalanceStrategy")]
        public ConnectionLoadBalanceStrategies ConnectionLoadBalanceStrategy { get; set; }

        #endregion

        #region Methods.

        /// <summary>
        ///     尝试从一个全局配置对象中解析出当前的配置节信息
        /// </summary>
        /// <param name="configuration">全局的配置对象</param>
        /// <param name="settings">如果解析成功，则返回解析后的对象</param>
        /// <returns>返回一个是否解析成功的标识</returns>
        public static bool TryParse(IConfiguration configuration, out SettingConfiguration settings)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}