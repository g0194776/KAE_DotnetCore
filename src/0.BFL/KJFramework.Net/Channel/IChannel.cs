namespace KJFramework.Net.Channel
{
    /// <summary>
    ///     ͨ��Ԫ�ӿڣ��ṩ����صĻ�������
    /// </summary>
    /// <typeparam name="TInfomation">ͨ����Ϣ����</typeparam>
    public interface IChannel<TInfomation>
        where TInfomation : BasicChannelInfomation, new()
    {
        #region Members.

        /// <summary>
        ///     ��ȡ�����õ�ǰͨ����Ϣ
        /// </summary>
        TInfomation ChannelInfo { get; set; }

        #endregion

    }
}