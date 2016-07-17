using KJFramework.Attribute;

namespace KJFramework.Net.Configurations
{
    /// <summary>
    ///     通信信道模型相关配置节
    /// </summary>
    [CustomerSection("KJFramework")]
    public class ChannelModelSettingConfigSection
    {
        #region Members.

        /// <summary>
        ///   KJFramework.Net.Channels配置项
        /// </summary>
        [CustomerField("KJFramework.Net.Channels")] public SettingConfiguration Settings;

        #endregion

    }
}