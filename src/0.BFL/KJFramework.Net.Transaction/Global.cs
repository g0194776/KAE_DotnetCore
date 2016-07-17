using System;
using KJFramework.Configurations;
using KJFramework.Net.Transaction.Configurations;
using KJFramework.Net.Transaction.Enums;

namespace KJFramework.Net.Transaction
{
    /// <summary>
    ///     全局配置项
    /// </summary>
    public static class Global
    {
        #region Constructor.

        static Global()
        {
            SettingConfiguration settings;
            if (!SettingConfiguration.TryParse(SystemConfigurations.Configuration, out settings))
            {
                settings = new SettingConfiguration();
                settings.TransactionTimeout = TimeSpan.Parse("00:00:30");
                settings.TransactionCheckInterval = 30000;
                settings.MaximumConnectionCount = 3;
                settings.MinimumConnectionCount = 1;
                settings.ConnectionLoadBalanceStrategy = ConnectionLoadBalanceStrategies.Sequential;
            }
            _settings = settings;
        }

        #endregion

        #region Members.

        private static SettingConfiguration _settings;

        /// <summary>
        ///     全局的事务超时时间
        /// </summary>
        public static readonly TimeSpan TransactionTimeout = _settings.TransactionTimeout;

        /// <summary>
        ///     全局的事务超时检查时间间隔
        ///     <para>* 单位: 秒</para>
        /// </summary>
        public static readonly int TransactionCheckInterval = _settings.TransactionCheckInterval;

        /// <summary>
        ///    最大连接数(在相同的远程终结点地址情况下)
        /// </summary>
        public static readonly int MaximumConnectionCount = _settings.MaximumConnectionCount;

        /// <summary>
        ///    最小连接数(在相同的远程终结点地址情况下)
        /// </summary>
        public static readonly int MinimumConnectionCount = _settings.MinimumConnectionCount;

        /// <summary>
        ///    并行网络连接的分发策略
        /// </summary>
        public static readonly ConnectionLoadBalanceStrategies ConnectionLoadBalanceStrategy =_settings.ConnectionLoadBalanceStrategy;

        #endregion
    }
}