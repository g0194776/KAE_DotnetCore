using System;
namespace KJFramework.Net.EventArgs
{
    public delegate void DelegateUpdateProcessing(Object sender, UpdateProcessingEventArgs e);
    /// <summary>
    ///     ����״̬�¼�
    /// </summary>
    public class UpdateProcessingEventArgs : System.EventArgs
    {
        #region Contsructor.

        /// <summary>
        ///     ����״̬�¼�
        /// </summary>
        /// <param name="state">��ǰ���µ�״̬</param>
        public UpdateProcessingEventArgs(string state)
        {
            State = state;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     ��ȡ��ǰ���µ�״̬
        /// </summary>
        public String State { get; }

        #endregion
    }
}