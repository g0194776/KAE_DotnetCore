using System;
using KJFramework.Enums;

namespace KJFramework.EventArgs
{
    public delegate void DelegateWorkerProcessing(Object sender, WorkerProcessingEventArgs e);
    /// <summary>
    ///     工作者工作状态汇报事件
    /// </summary>
    public class WorkerProcessingEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     工作者工作状态汇报事件
        /// </summary>
        /// <param name="state">工作状态信息</param>
        public WorkerProcessingEventArgs(string state)
        {
            State = state;
        }

        /// <summary>
        ///     工作者工作状态汇报事件
        /// </summary>
        /// <param name="processingType">信息状态</param>
        public WorkerProcessingEventArgs(ProcessingTypes? processingType)
        {
            ProcessingType = processingType;
        }

        /// <summary>
        ///     工作者工作状态汇报事件
        /// </summary>
        /// <param name="state">工作状态信息</param>
        /// <param name="processingType">信息状态</param>
        public WorkerProcessingEventArgs(string state, ProcessingTypes? processingType)
        {
            State = state;
            ProcessingType = processingType;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取当前的工作状态信息
        /// </summary>
        public string State { get; }
        /// <summary>
        ///     获取信息状态
        /// </summary>
        public ProcessingTypes? ProcessingType { get; }

        #endregion

    }
}