namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     队列未找到
    /// </summary>
    public class QueueNotFoundException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     队列未找到
        /// </summary>
        public QueueNotFoundException() : base("队列未找到 !")
        {

        }

        #endregion

    }
}
