namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     ��Ϣ��ڵ�Ϊ���쳣
    /// </summary>
    public class MessageEntryHasNullException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     ��Ϣ��ڵ�Ϊ���쳣
        /// </summary>
        public MessageEntryHasNullException() : base("��Ϣ��ڵ㲻��Ϊ�� !")
        {

        }

        #endregion

    }
}