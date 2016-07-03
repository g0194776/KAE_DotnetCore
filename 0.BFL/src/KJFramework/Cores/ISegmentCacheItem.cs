namespace KJFramework.Cores
{
    /// <summary>
    ///     �ڴ�λ�����Ԫ�ӿڣ��ṩ����صĻ�������
    /// </summary>
    public interface ISegmentCacheItem : ICacheItem<byte[]>
    {
        #region Members.

        /// <summary>
        ///     ��ȡһ��ֵ����ֵ��ʾ�˵�ǰ�Ļ����Ƿ��Ѿ���ʹ��
        /// </summary>
        bool IsUsed { get; }
        /// <summary>
        ///     ��ȡ��ǰ��ʹ�ô�С
        /// </summary>
        int UsageSize { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     ��ʼ��
        /// </summary>
        void Initialize();
        /// <summary>
        ///     ���û�������
        /// </summary>
        /// <param name="obj">�������</param>
        /// <param name="usedSize">ʹ�ô�С</param>
        void SetValue(byte[] obj, int usedSize);

        #endregion
    }
}