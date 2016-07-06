using System;
using System.Collections.Generic;
using System.Threading;
using KJFramework.Configurations;
using KJFramework.Enums;

namespace KJFramework.Tracing
{
    /// <summary>
    ///     日志记录设置
    /// </summary>
    public static class TracingSettings
    {
        #region Members.

        private static int _version;
        private static Action _handler;
        private static string _provider;
        private static string _dataSource;
        private static TracingLevel? _level;

        /// <summary>
        ///     获取或设置日志记录等级
        /// </summary>
        /// <exception cref="KeyNotFoundException">按照指定的路径无法获取到相关配置信息</exception>
        public static TracingLevel Level
        {
            get
            {
                if (_level == null)
                {
                    string tmpConfig = SystemConfigurations.Configuration["IO:Tracing:Level"];
                    if(string.IsNullOrEmpty(tmpConfig)) throw new KeyNotFoundException("#There wasn't any key could be found with path: IO:Tracing:Level");
                    _level = (TracingLevel)Enum.Parse(typeof(TracingLevel), tmpConfig);
                }
                return (TracingLevel)_level;
            }
            set { _level = value; }
        }

        /// <summary>
        ///     获取或设置日志记录器
        /// </summary>
        /// <exception cref="KeyNotFoundException">按照指定的路径无法获取到相关配置信息</exception>
        public static string Provider
        {
            get
            {
                if (string.IsNullOrEmpty(_provider))
                {
                    string tmpConfig = SystemConfigurations.Configuration["IO:Tracing:Provider"];
                    if (string.IsNullOrEmpty(tmpConfig)) throw new KeyNotFoundException("#There wasn't any key could be found with path: IO:Tracing:Provider");
                    _provider = tmpConfig;
                }
                return _provider;
            }
            set { _provider = value; }
        }

        /// <summary>
        ///     获取或设置日志记录源
        /// </summary>
        /// <exception cref="KeyNotFoundException">按照指定的路径无法获取到相关配置信息</exception>
        public static string Datasource
        {
            get
            {
                if (string.IsNullOrEmpty(_dataSource))
                {
                    string tmpConfig = SystemConfigurations.Configuration["IO:Tracing:Datasource"];
                    if (string.IsNullOrEmpty(tmpConfig)) throw new KeyNotFoundException("#There wasn't any key could be found with path: IO:Tracing:Datasource");
                    _dataSource = tmpConfig;
                }
                return _dataSource;
            }
            set { _dataSource = value; }
        }

        #endregion

        #region Methods.

        internal static void WatchProviderChange(Action handler)
        {
            _handler = handler;
        }

        private static void OnTracingProviderChanged(int version, string section, string name)
        {
            if (Interlocked.Exchange(ref _version, version) != version)
                _handler();
        }

        #endregion
    }
}
