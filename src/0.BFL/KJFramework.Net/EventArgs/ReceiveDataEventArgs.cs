namespace KJFramework.Net.EventArgs
{
    /// <summary>
    ///     �����������¼�
    /// </summary>
    public class ReceiveDataEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     �����������¼�
        /// </summary>
        /// <param name="data">�µ�����</param>
        public ReceiveDataEventArgs(byte[] data)
        {
            Data = data;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     ��ȡ���յ�����
        /// </summary>
        public byte[] Data { get; }

        #endregion
    }
}