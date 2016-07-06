using System;
using KJFramework.Enums;

namespace KJFramework.EventArgs
{
    public delegate void DelegateWorkerProcessing(Object sender, WorkerProcessingEventArgs e);
    /// <summary>
    ///     �����߹���״̬�㱨�¼�
    /// </summary>
    public class WorkerProcessingEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     �����߹���״̬�㱨�¼�
        /// </summary>
        /// <param name="state">����״̬��Ϣ</param>
        public WorkerProcessingEventArgs(string state)
        {
            State = state;
        }

        /// <summary>
        ///     �����߹���״̬�㱨�¼�
        /// </summary>
        /// <param name="processingType">��Ϣ״̬</param>
        public WorkerProcessingEventArgs(ProcessingTypes? processingType)
        {
            ProcessingType = processingType;
        }

        /// <summary>
        ///     �����߹���״̬�㱨�¼�
        /// </summary>
        /// <param name="state">����״̬��Ϣ</param>
        /// <param name="processingType">��Ϣ״̬</param>
        public WorkerProcessingEventArgs(string state, ProcessingTypes? processingType)
        {
            State = state;
            ProcessingType = processingType;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     ��ȡ��ǰ�Ĺ���״̬��Ϣ
        /// </summary>
        public string State { get; }
        /// <summary>
        ///     ��ȡ��Ϣ״̬
        /// </summary>
        public ProcessingTypes? ProcessingType { get; }

        #endregion

    }
}