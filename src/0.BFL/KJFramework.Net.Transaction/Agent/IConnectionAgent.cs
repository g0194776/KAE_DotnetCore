﻿using System;

namespace KJFramework.Net.Transaction.Agent
{
    /// <summary>
    ///     连接代理器，提供了相关的基本操作
    /// </summary>
    public interface IConnectionAgent
    {
        #region Members.

        /// <summary>
        ///     获取或设置附属属性
        /// </summary>
        object Tag { get; set; }

        #endregion

        #region Methods.

        /// <summary>
        ///     主动关闭连接代理器
        ///     * 主动关闭的行为将会关闭内部的通信信道连接
        /// </summary>
        void Close();

        #endregion

        #region Events.

        /// <summary>
        ///     断开事件
        /// </summary>
        event EventHandler Disconnected;

        #endregion

    }
}