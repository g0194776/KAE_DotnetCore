using System.Net.Sockets;

namespace KJFramework.Net
{
    /// <summary>
    ///     ����TCPЭ��Ĵ���ͨ��Ԫ�ӿڣ��ṩ����صĻ���������
    /// </summary>
    internal interface ITcpTransportChannel : ITransportChannel
    {
        #region Members.

        /// <summary>
        ///     ��ȡ��ǰTCPЭ�鴫��ͨ����Ψһ��ֵ
        /// </summary>
        int ChannelKey { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     ��ȡ�ڲ������׽���
        /// </summary>
        /// <returns>�����ڲ������׽���</returns>
        Socket GetStream();

        #endregion
    }
}