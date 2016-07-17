namespace KJFramework.Net.EventArgs
{
    /// <summary>
    ///     接收新数据事件
    /// </summary>
    public class ReceiveDataEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     接收新数据事件
        /// </summary>
        /// <param name="data">新的数据</param>
        public ReceiveDataEventArgs(byte[] data)
        {
            Data = data;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取接收的数据
        /// </summary>
        public byte[] Data { get; }

        #endregion
    }
}