using System;

namespace KJFramework.Attribute
{
    /// <summary>
    ///     允许注入标签, 为今后的自动加载提供了必要的属性。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Class)]
    public class InjectionAttribute : System.Attribute
    {
        #region Constructor.

        /// <summary>
        ///     允许注入标签, 为今后的自动加载提供了必要的属性。
        /// </summary>
        /// <param name="name">匹配名称</param>
        public InjectionAttribute(string name)
        {
            Name = name;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取或设置注入的匹配名称
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}
