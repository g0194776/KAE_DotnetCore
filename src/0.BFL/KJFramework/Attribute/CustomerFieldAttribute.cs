using System;

namespace KJFramework.Attribute
{
    /// <summary>
    ///     自定义配置节属性字段标签属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CustomerFieldAttribute : System.Attribute
    {
        #region Constructor.

        /// <summary>
        ///     自定义配置节标签属性
        /// </summary>
        /// <param name="name">配置节名称</param>
        public CustomerFieldAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     自定义配置节标签属性
        /// </summary>
        /// <param name="name">配置节名称</param>
        /// <param name="defaultValue">默认值</param>
        public CustomerFieldAttribute(string name, object defaultValue)
        {
            Name = name;
            DefaultValue = defaultValue;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取自定义配置节名称
        /// </summary>
        public string Name { get; }
        /// <summary>
        ///     获取默认值
        /// </summary>
        public object DefaultValue { get; }
        /// <summary>
        ///     获取或设置当前字段是否为一个集合的标示
        /// </summary>
        public bool IsList { get; set; }
        /// <summary>
        ///     获取或设置当前内部元素的类型
        ///            *　仅当IsList == true的时候有效。
        /// </summary>
        public Type ElementType { get; set; }
        /// <summary>
        ///     获取或设置当前内部元素的配置项名称
        ///            *　仅当IsList == true的时候有效。
        /// </summary>
        public string ElementName { get; set; }

        #endregion
    }
}