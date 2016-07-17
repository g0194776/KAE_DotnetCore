using System;
using System.Collections.Generic;
using KJFramework.Enums;
using KJFramework.Statistics;

namespace KJFramework.Net.Transactions.Processors
{
    /// <summary>
    ///     ���ﴦ���������࣬�ṩ����صĲ�����
    /// </summary>
    /// <typeparam name="TIn">��������</typeparam>
    /// <typeparam name="TOut">�������</typeparam>
    public abstract class TransactionProcessor<TIn, TOut> : ITransactionProcessor<TIn, TOut>
    {
        #region Members.

        /// <summary>
        /// ��ȡ������ͳ����
        /// </summary>
        public Dictionary<StatisticTypes, IStatistic> Statistics { get; set; }

        #endregion

        #region Methods.

        /// <summary>
        ///     ����
        /// </summary>
        /// <param name="obj">����</param>
        /// <returns>���ؽ��</returns>
        public abstract List<TOut> Process(TIn obj);

        #endregion
    }
}