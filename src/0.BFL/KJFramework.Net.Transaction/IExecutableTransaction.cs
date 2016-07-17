using System;

namespace KJFramework.Net.Transaction
{
    /// <summary>
    ///     可执行事务元接口，提供了相关的基本操作
    /// </summary>
    public interface IExecutableTransaction : ITransaction
    {
        #region Members.

        /// <summary>
        ///     获取一个值，该值标示了当前事务是否已经操作完成
        /// </summary>
        bool Finished { get; }

        #endregion

        #region Methods.

        /// <summary>
        ///     提交事务
        /// </summary>
        void Commit();

        /// <summary>
        ///     回滚事务
        /// </summary>
        void Rollback();

        #endregion

        #region Events.

        /// <summary>
        ///     事务已完成事件
        /// </summary>
        event EventHandler Completed;

        #endregion

    }
}