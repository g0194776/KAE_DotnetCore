using System;
using KJFramework.EventArgs;
using KJFramework.Net.Events;

namespace KJFramework.Net
{
    /// <summary>
    ///     �����������ŵ�Ԫ�ӿڣ��ṩ����صĻ�������
    /// </summary>
    public interface IRawTransportChannel : ITransportChannel
    {
        #region Members.

        /// <summary>
        ///     ��ȡ�����õ�ǰԪ�����ŵ��Ƿ�֧����Ƭ�εķ�ʽ��������������
        /// </summary>
        bool SupportSegment { get; set; }

        #endregion

        #region Events.

        /// <summary>
        ///     ���յ������¼�
        /// </summary>
        event EventHandler<LightSingleArgEventArgs<byte[]>> ReceivedData;

        /// <summary>
        ///     ���յ�����Ƭ���¼�
        /// </summary>
        event EventHandler<SegmentReceiveEventArgs> ReceivedDataSegment;

        #endregion
    }
}