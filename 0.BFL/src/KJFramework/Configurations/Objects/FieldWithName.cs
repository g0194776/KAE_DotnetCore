using System.Reflection;

namespace KJFramework.Configurations.Objects
{
    /// <summary>
    ///     �ֶ�������������ʱ�ṹ��
    /// </summary>
    public class FieldWithName
    {
        #region Members.

        /// <summary>
        ///     ��ȡ�������ֶ�����
        /// </summary>
        public FieldInfo FieldInfo { get; set; }
        /// <summary>
        ///     ��ȡ�������ֶ�����
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}