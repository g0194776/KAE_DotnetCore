using System.Reflection;

namespace KJFramework.Configurations.Objects
{
    /// <summary>
    ///     字段类型与名称临时结构体
    /// </summary>
    public class FieldWithName
    {
        #region Members.

        /// <summary>
        ///     获取或设置字段类型
        /// </summary>
        public FieldInfo FieldInfo { get; set; }
        /// <summary>
        ///     获取或设置字段名称
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}