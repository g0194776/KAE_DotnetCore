
namespace KJFramework.Net.Listener
{
    /// <summary>
    ///     端口监听器元接口, 提供了相关的基本操作。
    /// </summary>
    public interface IPortListener : IListener<int>
    {
        #region Members.

        /// <summary>
        ///     监听的端口
        /// </summary>
        int Port { get; set; }

        #endregion

        #region Methods.

        /// <summary>
        ///     监听
        /// </summary>
        void Listen();

        #endregion
    }
}
