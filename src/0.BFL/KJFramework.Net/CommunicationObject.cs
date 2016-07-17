using System;
using System.Collections.Generic;
using KJFramework.Enums;
using KJFramework.Net.Enums;
using KJFramework.Statistics;

namespace KJFramework.Net
{
    /// <summary>
    ///     通信对象接口
    /// </summary>
    public abstract class CommunicationObject : ICommunicationObject
    {
        #region Implementation of IStatisticable<IStatistic>

        protected bool _enable;
        protected Dictionary<StatisticTypes, IStatistic> _statistics;
        protected CommunicationStates _communicationState;

        /// <summary>
        ///     获取或设置统计器
        /// </summary>
        public Dictionary<StatisticTypes, IStatistic> Statistics
        {
            get { return _statistics; }
            set { _statistics = value; }
        }

        #endregion

        #region Implementation of ICommunicationObject


        /// <summary>
        ///     获取或设置附属标记
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        ///     停止
        /// </summary>
        public abstract void Abort();

        /// <summary>
        ///     打开
        /// </summary>
        public abstract void Open();

        /// <summary>
        ///     关闭
        /// </summary>
        public abstract void Close();

        /// <summary>
        ///     异步打开
        /// </summary>
        /// <param name="callback">回调函数</param>
        /// <param name="state">状态对象</param>
        /// <returns>返回异步打开的状态</returns>
        public virtual IAsyncResult BeginOpen(AsyncCallback callback, object state)
        {
            Action action = Open;
            return action.BeginInvoke(callback, state);
        }

        /// <summary>
        ///     异步关闭
        /// </summary>
        /// <param name="callback">回调函数</param>
        /// <param name="state">状态对象</param>
        /// <returns>返回异步关闭的状态</returns>
        public virtual IAsyncResult BeginClose(AsyncCallback callback, object state)
        {
            Action action = Close;
            return action.BeginInvoke(callback, state);
        }

        /// <summary>
        ///     异步打开
        /// </summary>
        public virtual void EndOpen(IAsyncResult result)
        {
            if (result != null)
            {
                Action action = (Action) result.AsyncState;
                action.EndInvoke(result);
            }
        }

        /// <summary>
        ///     异步关闭
        /// </summary>
        public virtual void EndClose(IAsyncResult result)
        {
            if (result != null)
            {
                Action action = (Action)result.AsyncState;
                action.EndInvoke(result);
            }
        }

        /// <summary>
        ///     获取或设置一个值，该值表示了当前通信对象是否可用
        /// </summary>
        public bool Enable
        {
            get { return _enable; }
            set { _enable = value; }
        }

        /// <summary>
        ///     获取当前通信状态
        /// </summary>
        public CommunicationStates CommunicationState
        {
            get { return _communicationState; }
        }

        /// <summary>
        ///     关闭事件
        /// </summary>
        public event EventHandler Closed;
        protected void ClosedHandler(System.EventArgs e)
        {
            EventHandler closed = Closed;
            if (closed != null) closed(this, e);
        }

        /// <summary>
        ///     关闭中事件
        /// </summary>
        public event EventHandler Closing;
        protected void ClosingHandler(System.EventArgs e)
        {
            EventHandler closing = Closing;
            if (closing != null) closing(this, e);
        }

        /// <summary>
        ///     失败事件
        /// </summary>
        public event EventHandler Faulted;
        protected void FaultedHandler(System.EventArgs e)
        {
            EventHandler faulted = Faulted;
            if (faulted != null) faulted(this, e);
        }

        /// <summary>
        ///     打开后的通知事件
        /// </summary>
        public event EventHandler Opened;
        protected void OpenedHandler(System.EventArgs e)
        {
            EventHandler opened = Opened;
            if (opened != null) opened(this, e);
        }

        /// <summary>
        ///     打开中的通知事件
        /// </summary>
        public event EventHandler Opening;
        protected void OpeningHandler(System.EventArgs e)
        {
            EventHandler opening = Opening;
            if (opening != null) opening(this, e);
        }

        #endregion
    }
}