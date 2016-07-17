using System;
using KJFramework.EventArgs;

namespace KJFramework.Net
{
    /// <summary>
    ///     Э��ͨ��Ԫ�ӿڣ��ṩ����صĻ���������
    /// </summary>
    public interface IProtocolChannel : IServiceChannel
    {
        #region Methods.

        /// <summary>
        ///     ����Э����Ϣ
        /// </summary>
        /// <typeparam name="TMessage">Э����Ϣ����</typeparam>
        /// <returns>����Э����Ϣ</returns>
        TMessage CreateProtocolMessage<TMessage>();

        #endregion

        #region Events.

        /// <summary>
        ///     �����¼�
        /// </summary>
        event EventHandler<LightMultiArgEventArgs<Object>> Requested;

        /// <summary>
        ///     �����¼�
        /// </summary>
        event EventHandler<LightMultiArgEventArgs<Object>> Responsed;

        #endregion
    }
}