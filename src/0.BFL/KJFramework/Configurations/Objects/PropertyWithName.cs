using System.Reflection;

namespace KJFramework.Configurations.Objects
{
    /// <summary>
    ///     属性类型与名称临时结构体
    /// </summary>
    public class PropertyWithName
    {
        #region Members.

        /// <summary>
        ///     获取或设置属性类型
        /// </summary>
        public PropertyInfo PropertyInfo { get; set; }
        /// <summary>
        ///     获取或设置属性名称
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}