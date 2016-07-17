namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     UDP消息响应器未找到异常
    /// </summary>
    public class UdpResponseManagerNotFoundException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     UDP消息响应器未找到异常
        /// </summary>
        public UdpResponseManagerNotFoundException() : base("UDP消息响应器未找到 !")
        {
        }

        #endregion

    }
}
