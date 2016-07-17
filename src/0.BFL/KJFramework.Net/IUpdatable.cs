using KJFramework.Net.EventArgs;

namespace KJFramework.Net
{
    /// <summary>
    ///     支持更新的元接口，提供了一个程序更新的相关基本操作。
    /// </summary>
    public interface IUpdatable
    {
        #region Methods.

        /// <summary>
        ///     执行更新操作
        /// </summary>
        bool Update();

        /// <summary>
        ///     执行更新操作
        /// </summary>
        /// <param name="url">
        ///     代表了版本的网络文件地址
        ///            * 该文件一般为XML格式。
        /// </param>
        bool Update(string url);

        #endregion

        #region Events.

        /// <summary>
        ///     更新状态事件
        /// </summary>
        event DelegateUpdateProcessing UpdateProcessing;

        #endregion
    }
}