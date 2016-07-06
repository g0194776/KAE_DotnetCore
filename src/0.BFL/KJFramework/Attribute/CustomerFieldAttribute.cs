using System;

namespace KJFramework.Attribute
{
    /// <summary>
    ///     �Զ������ý������ֶα�ǩ����
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CustomerFieldAttribute : System.Attribute
    {
        #region Constructor.

        /// <summary>
        ///     �Զ������ýڱ�ǩ����
        /// </summary>
        /// <param name="name">���ý�����</param>
        public CustomerFieldAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     �Զ������ýڱ�ǩ����
        /// </summary>
        /// <param name="name">���ý�����</param>
        /// <param name="defaultValue">Ĭ��ֵ</param>
        public CustomerFieldAttribute(string name, object defaultValue)
        {
            Name = name;
            DefaultValue = defaultValue;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     ��ȡ�Զ������ý�����
        /// </summary>
        public string Name { get; }
        /// <summary>
        ///     ��ȡĬ��ֵ
        /// </summary>
        public object DefaultValue { get; }
        /// <summary>
        ///     ��ȡ�����õ�ǰ�ֶ��Ƿ�Ϊһ�����ϵı�ʾ
        /// </summary>
        public bool IsList { get; set; }
        /// <summary>
        ///     ��ȡ�����õ�ǰ�ڲ�Ԫ�ص�����
        ///            *������IsList == true��ʱ����Ч��
        /// </summary>
        public Type ElementType { get; set; }
        /// <summary>
        ///     ��ȡ�����õ�ǰ�ڲ�Ԫ�ص�����������
        ///            *������IsList == true��ʱ����Ч��
        /// </summary>
        public string ElementName { get; set; }

        #endregion
    }
}