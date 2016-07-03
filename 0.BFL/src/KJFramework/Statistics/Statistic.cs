using KJFramework.Enums;

namespace KJFramework.Statistics
{
    /// <summary>
    ///     ͳ���������࣬�ṩ����صĻ���������
    /// </summary>
    public abstract class Statistic : IStatistic
    {
        #region Constructor.

        /// <summary>
        ///     ͳ���������࣬�ṩ����صĻ���������
        /// </summary>
        protected Statistic()
        {
            IsEnable = true;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     ��ȡͳ������
        /// </summary>
        public StatisticTypes StatisticType { get; }

        /// <summary>
        ///     ��ȡ�����ÿ��ñ�ʾ
        /// </summary>
        public bool IsEnable { get; set; }

        #endregion

        #region Methods.

        /// <summary>
        ///     ��ʼ��
        /// </summary>
        /// <param name="element">ͳ������</param>
        /// <typeparam name="T">ͳ������</typeparam>
        public abstract void Initialize<T>(T element);

        /// <summary>
        ///     �ر�ͳ��
        /// </summary>
        public abstract void Close();

        #endregion
    }
}