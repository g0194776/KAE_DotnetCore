using System.Reflection;

namespace KJFramework.Configurations.Objects
{
    /// <summary>
    ///     ��ȡ�ֶεı������ʱ����ʱ���ݽṹ
    /// </summary>
    public class FieldWithAttribute<T>
        where T : System.Attribute
    {
        #region Members.

        /// <summary>
        ///     ��ȡ�������ֶ���Ϣ
        /// </summary>
        public FieldInfo FieldInfo { get; set; }
        /// <summary>
        ///     ��ȡ�������ֶα������
        /// </summary>
        public T Attribute { get; set; }

        #endregion
    }
}