using System;

namespace KJFramework.Attribute
{
    /// <summary>
    ///     自定义配置节标签属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomerSectionAttribute : System.Attribute
    {
        #region Constructor.

        /// <summary>
        ///     自定义配置节标签属性
        /// </summary>
        /// <param name="name">配置节名称</param>
        public CustomerSectionAttribute(string name)
        {
            Name = name;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取自定义配置节名称
        /// </summary>
        public string Name { get; }
        /// <summary>
        ///     获取或设置一个值，该值标示了当前的配置节是否从远程获取
        /// </summary>
        public bool RemoteConfig { get; set; }

        #endregion
    }
}