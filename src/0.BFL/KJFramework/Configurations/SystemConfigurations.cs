using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace KJFramework.Configurations
{
    /// <summary>
    ///     KJFramework系统配置信息
    /// </summary>
    internal static class SystemConfigurations
    {
        #region Constructor.

        static SystemConfigurations()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            IReadOnlyDictionary<string, string> defaultConfig = new Dictionary<string, string>
            {
                ["IO:Tracing:Level"] = "0",
                ["IO:Tracing:Provider"] = "file",
                ["IO:Tracing:Datasource"] = ".",
            };
            builder.AddInMemoryCollection(defaultConfig);
            Configuration = builder.Build();
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取或设置KJFramework系统中的核心配置信息
        /// </summary>
        public static IConfiguration Configuration { get; set; }

        #endregion
    }
}