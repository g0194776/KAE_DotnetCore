using System;
using KJFramework.Enums;

namespace KJFramework.Tracing
{
    /// <summary>
    ///     记录项
    /// </summary>
    public sealed class TraceItem
    {
        #region Constructor.

        /// <summary>
        ///     记录项
        /// </summary>
        public TraceItem(string logger, TracingLevel level, Exception error, string message)
        {
            Timestamp = DateTime.UtcNow;
            Logger = logger;
            Level = level;
            Error = error;
            Message = message;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取时间戳
        /// </summary>
        public DateTime Timestamp { get; }
        /// <summary>
        ///     获取记录器名称
        /// </summary>
        public string Logger { get; }
        /// <summary>
        ///     获取记录信息的日志等级
        /// </summary>
        public TracingLevel Level { get; }
        /// <summary>
        ///     获取错误信息
        /// </summary>
        public Exception Error { get; }
        /// <summary>
        ///     获取记录的消息内容
        /// </summary>
        public string Message { get; }

        #endregion
    }
}