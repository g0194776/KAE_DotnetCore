using System.Reflection;

namespace KJFramework.Configurations.Objects
{
    /// <summary>
    ///     获取字段的标记属性时的临时数据结构
    /// </summary>
    public class FieldWithAttribute<T>
        where T : System.Attribute
    {
        #region Members.

        /// <summary>
        ///     获取或设置字段信息
        /// </summary>
        public FieldInfo FieldInfo { get; set; }
        /// <summary>
        ///     获取或设置字段标记属性
        /// </summary>
        public T Attribute { get; set; }

        #endregion
    }
}