using System;
using KJFramework.Net.Enums;
using KJFramework.Statistics;

namespace KJFramework.Net
{
    /// <summary>
    ///     通信对象接口
    /// </summary>
    public interface ICommunicationObject : IStatisticable<IStatistic>
    {
        #region Members.

        /// <summary>
        ///     获取或设置一个值，该值表示了当前通信对象是否可用
        /// </summary>
        bool Enable { get; set; }

        /// <summary>
        ///     获取或设置附属标记
        /// </summary>
        object Tag { get; set; }

        /// <summary>
        ///     获取当前通信状态
        /// </summary>
        CommunicationStates CommunicationState { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     停止
        /// </summary>
        void Abort();

        /// <summary>
        ///     打开
        /// </summary>
        void Open();

        /// <summary>
        ///     关闭
        /// </summary>
        void Close();

        /// <summary>
        ///     异步打开
        /// </summary>
        /// <param name="callback">回调函数</param>
        /// <param name="state">状态对象</param>
        /// <returns>返回异步打开的状态</returns>
        IAsyncResult BeginOpen(AsyncCallback callback, Object state);

        /// <summary>
        ///     异步关闭
        /// </summary>
        /// <param name="callback">回调函数</param>
        /// <param name="state">状态对象</param>
        /// <returns>返回异步关闭的状态</returns>
        IAsyncResult BeginClose(AsyncCallback callback, Object state);

        /// <summary>
        ///     异步打开
        /// </summary>
        void EndOpen(IAsyncResult result);

        /// <summary>
        ///     异步关闭
        /// </summary>
        void EndClose(IAsyncResult result);

        #endregion

        #region Events.

        /// <summary>
        ///     关闭事件
        /// </summary>
        event EventHandler Closed;

        /// <summary>
        ///     关闭中事件
        /// </summary>
        event EventHandler Closing;

        /// <summary>
        ///     失败事件
        /// </summary>
        event EventHandler Faulted;

        /// <summary>
        ///     打开后的通知事件
        /// </summary>
        event EventHandler Opened;

        /// <summary>
        ///     打开中的通知事件
        /// </summary>
        event EventHandler Opening;

        #endregion

    }
}