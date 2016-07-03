using KJFramework.Enums;

namespace KJFramework.Statistics
{
    /// <summary>
    ///     ͳ��Ԫ�ӿڣ��ṩ����صĻ���������
    /// </summary>
    public interface IStatistic
    {
        #region Members.

        /// <summary>
        ///     ��ȡͳ������
        /// </summary>
        StatisticTypes StatisticType { get; }
        /// <summary>
        ///     ��ȡ�����ÿ��ñ�ʾ
        /// </summary>
        bool IsEnable { get; set; }

        #endregion

        #region Methods.

        /// <summary>
        ///     ��ʼ��
        /// </summary>
        /// <param name="element">ͳ������</param>
        /// <typeparam name="T">ͳ������</typeparam>
        void Initialize<T>(T element);
        /// <summary>
        ///     �ر�ͳ��
        /// </summary>
        void Close();

        #endregion
    }
}