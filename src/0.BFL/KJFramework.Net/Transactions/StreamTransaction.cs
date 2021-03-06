﻿using System;
using System.Collections.Generic;
using System.IO;
using KJFramework.Enums;
using KJFramework.Statistics;
using KJFramework.Tracing;

namespace KJFramework.Net.Transactions
{
    /// <summary>
    ///     流事物抽象父类，提供了相关的基本操作。
    /// </summary>
    /// <typeparam name="TStream">流类型</typeparam>
    public abstract class StreamTransaction<TStream> : IStreamTransaction<TStream>
        where TStream : Stream
    {
        #region Constructor.

        /// <summary>
        ///     流事物抽象父类，提供了相关的基本操作。
        /// </summary>
        /// <param name="stream">流</param>
        protected StreamTransaction(TStream stream) : this(stream, false)
        {
        }

        /// <summary>
        ///     流事物抽象父类，提供了相关的基本操作。
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="canAsync">异步标示</param>
        protected StreamTransaction(TStream stream, bool canAsync)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            Stream = stream;
            CanAsync = canAsync;
            if (CanAsync) ProcAsync();
            else Proc();
        }

        #endregion

        #region Members.

        protected bool _enable = true;
        protected Dictionary<StatisticTypes, IStatistic> _statistics = new Dictionary<StatisticTypes,IStatistic>();
        private static readonly ITracing _tracing = TracingManager.GetTracing(typeof (StreamTransaction<TStream>));

        /// <summary>
        ///     获取一个值，该值标示了当前流事物的状态
        /// </summary>
        public bool Enable => _enable;

        /// <summary>
        ///     获取或设置一个值，该值表示了当前事物是否可以异步执行
        /// </summary>
        public bool CanAsync { get; set; }

        /// <summary>
        ///     获取内部流
        /// </summary>
        public TStream Stream { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     内部执行
        /// </summary>
        protected void Proc()
        {
            try
            {
                InnerProc();
            }
            catch (System.Exception ex)
            {
                _tracing.Error(ex, null);
                EndWork();
            }
        }

        /// <summary>
        ///     停止工作
        /// </summary>
        public virtual void EndWork()
        {
            try
            {
                _enable = false;
                InnerEndWork();
            }
            catch (System.Exception e)
            {
                _tracing.Error(e, null);
            }
        }

        /// <summary>
        ///     内部执行
        /// </summary>
        protected abstract void InnerProc();
        /// <summary>
        ///     开始工作
        ///     <para>* 此方法在事物开始工作的时候将会被调用。</para>
        /// </summary>
        protected abstract void BeginWork();
        /// <summary>
        ///     停止工作
        ///     <para>* 此方法在事物异常或者结束工作的时候将会被调用。</para>
        /// </summary>
        protected abstract void InnerEndWork();

        /// <summary>
        ///     异步执行
        /// </summary>
        protected void ProcAsync()
        {
            Action action = Proc;
            action.BeginInvoke(action.EndInvoke, action);
        }

        #endregion

        #region Events.

        /// <summary>
        ///     断开事件
        /// </summary>
        public event EventHandler Disconnected;
        protected void DisconnectedHandler(System.EventArgs e)
        {
            EventHandler handler = Disconnected;
            if (handler != null) handler(this, e);
        }

        #endregion
    }
}
