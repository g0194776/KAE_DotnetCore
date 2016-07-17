using System;
using KJFramework.Net.Channel;

namespace KJFramework.Net
{
    /// <summary>
    ///     ����ͨ��Ԫ�ӿڣ��ṩ����صĻ�������
    /// </summary>
    public interface IServiceChannel : IChannel<BasicChannelInfomation>, ICommunicationObject
    {
        #region Members.

        /// <summary>
        ///     ��ȡ����ʱ��
        /// </summary>
        DateTime CreateTime { get; }

        /// <summary>
        ///     ��ȡͨ��Ψһ��ʾ
        /// </summary>
        Guid Key { get; }

        #endregion
    }
}