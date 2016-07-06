using System;
namespace KJFramework.EventArgs
{
    /// <summary>
    ///     ����Ϣ�¼�
    /// </summary>
    public class NewInfomationEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     ����Ϣ�¼�
        /// </summary>
        /// <param name="infomation">�ռ���������Ϣ</param>
        public NewInfomationEventArgs(string infomation)
        {
            Infomation = infomation;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     ��ȡ�ռ�������Ϣ
        /// </summary>
        public string Infomation { get; }

        #endregion
    }
}