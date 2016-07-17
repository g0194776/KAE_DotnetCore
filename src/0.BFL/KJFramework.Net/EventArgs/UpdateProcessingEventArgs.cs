using System;
namespace KJFramework.Net.EventArgs
{
    public delegate void DelegateUpdateProcessing(Object sender, UpdateProcessingEventArgs e);
    /// <summary>
    ///     更新状态事件
    /// </summary>
    public class UpdateProcessingEventArgs : System.EventArgs
    {
        #region Contsructor.

        /// <summary>
        ///     更新状态事件
        /// </summary>
        /// <param name="state">当前更新的状态</param>
        public UpdateProcessingEventArgs(string state)
        {
            State = state;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取当前更新的状态
        /// </summary>
        public String State { get; }

        #endregion
    }
}