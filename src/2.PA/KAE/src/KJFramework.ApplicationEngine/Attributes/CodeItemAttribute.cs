using System;

namespace KJFramework.ApplicationEngine.Attributes
{
    /// <summary>
    ///     代码项属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CodeItemAttribute : System.Attribute
    {
        #region Members.

        /// <summary>
        ///     获取相关名称
        /// </summary>
        public string ItemName { get; }

        #endregion

        #region Constructor.

        /// <summary>
        ///     代码项属性
        /// </summary>
        public CodeItemAttribute(string itemName)
        {
            if (string.IsNullOrEmpty(itemName)) throw new ArgumentNullException(nameof(itemName));
            ItemName = itemName;
        }

        #endregion
    }
}