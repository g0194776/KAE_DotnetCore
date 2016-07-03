using System;

namespace KJFramework.Attribute
{
    /// <summary>
    ///     �Զ������ýڱ�ǩ����
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomerSectionAttribute : System.Attribute
    {
        #region Constructor.

        /// <summary>
        ///     �Զ������ýڱ�ǩ����
        /// </summary>
        /// <param name="name">���ý�����</param>
        public CustomerSectionAttribute(string name)
        {
            Name = name;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     ��ȡ�Զ������ý�����
        /// </summary>
        public string Name { get; }
        /// <summary>
        ///     ��ȡ������һ��ֵ����ֵ��ʾ�˵�ǰ�����ý��Ƿ��Զ�̻�ȡ
        /// </summary>
        public bool RemoteConfig { get; set; }

        #endregion
    }
}