namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     Ҫ���͵���ϢΪnull�쳣
    /// </summary>
    public class SendMessageHasNullException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     Ҫ���͵���ϢΪnull�쳣
        /// </summary>
        public SendMessageHasNullException() : base("Ҫ���͵���Ϣ����Ϊ�� !")
        {

        }

        #endregion

    }
}