using System.Reflection;

namespace KJFramework.Configurations.Objects
{
    /// <summary>
    ///     ����������������ʱ�ṹ��
    /// </summary>
    public class PropertyWithName
    {
        #region Members.

        /// <summary>
        ///     ��ȡ��������������
        /// </summary>
        public PropertyInfo PropertyInfo { get; set; }
        /// <summary>
        ///     ��ȡ��������������
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}