using KJFramework.Indexers;

namespace KJFramework.Cores
{
    /// <summary>
    ///     �ڴ�λ�����Ԫ�ӿڣ��ṩ����صĻ�������
    /// </summary>
    internal interface ISegmentCacheStub : ICacheStub<byte[]>
    {
        #region Members.

        /// <summary>
        ///     ��ȡһ��ֵ����ֵ��ʾ�˵�ǰ�Ļ����Ƿ��Ѿ���ʹ��
        /// </summary>
        bool IsUsed { get; }
        /// <summary>
        ///     ��ȡ����������
        /// </summary>
        ICacheIndexer Indexer { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     ��ʼ��
        /// </summary>
        void Initialize();

        #endregion
    }
}