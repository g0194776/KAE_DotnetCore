using System;
using System.Collections.Generic;
using KJFramework.Configurations.Settings;
using KJFramework.Proxy;
using Microsoft.Extensions.Configuration;

namespace KJFramework.Configurations
{
    /// <summary>
    ///     KJFramework系统配置信息
    /// </summary>
    public static class SystemConfigurations
    {
        #region Members.

        /// <summary>
        ///     获取或设置KJFramework系统中的核心配置信息
        /// </summary>
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        ///     初始化
        /// </summary>
        public static void Initialize(string role, RemoteConfigurationSetting configSetting, IRemoteConfigurationProxy proxy)
        {
            if(string.IsNullOrEmpty(role)) throw new ArgumentNullException(nameof(role));
            if(proxy == null) throw new ArgumentNullException(nameof(proxy));
            Dictionary<string, string> configurations = new Dictionary<string, string>();
            string[] sysConfigKeys =  { "KJFramework.Net", "KJFramework.Net.Channels", "KJFramework.Net.Transaction"/*, "KJFramework.Data.Synchronization"*/ };
            foreach (string sysConfigKey in sysConfigKeys)
            {
                /*KJFramework.Net*/
                string configKey = (configSetting.HasCustomizedKey(sysConfigKey) ? string.Format("{0}.{1}", role, sysConfigKey) : sysConfigKey);
                string configSection = proxy.GetPartialConfig(configKey);
                if (string.IsNullOrEmpty(configSection)) throw new KeyNotFoundException(string.Format("#Sadly, we cannot found \"{0}\" keyword in remote configuration node.", configKey));
                configurations.Add(string.Format("sys:{0}", sysConfigKey), configSection);
            }
            IConfigurationBuilder builder = new ConfigurationBuilder();
            configurations.Add("IO:Tracing:Level", "0");
            configurations.Add("IO:Tracing:Provider", "file");
            configurations.Add("IO:Tracing:Datasource", ".");
            builder.AddInMemoryCollection(configurations);
            Configuration = builder.Build();
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public static void InitializeOnlyForLocal()
        {
            Dictionary<string, string> configurations = new Dictionary<string, string>();
            IConfigurationBuilder builder = new ConfigurationBuilder();
            configurations.Add("IO:Tracing:Level", "0");
            configurations.Add("IO:Tracing:Provider", "file");
            configurations.Add("IO:Tracing:Datasource", ".");
            builder.AddInMemoryCollection(configurations);
            Configuration = builder.Build();
        }

        #endregion
    }
}