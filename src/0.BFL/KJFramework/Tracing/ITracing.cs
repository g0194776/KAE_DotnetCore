using System;
using KJFramework.Enums;

namespace KJFramework.Tracing
{
    /// <summary>
    ///     日志器接口
    /// </summary>
    public interface ITracing
    {
        #region Methods.

        void Info(string format, params object[] args);
        void Info(Exception ex, string format, params object[] args);
        void DebugInfo(string format, ConsoleColor color = ConsoleColor.Gray, params object[] args);
        void Warn(string format, params object[] args);
        void Warn(Exception ex, string format, params object[] args);
        void Error(Exception ex);
        void Error(string format, params object[] args);
        void Error(Exception ex, string format, params object[] args);
        void Critical(string format, params object[] args);
        void Critical(Exception ex, string format, params object[] args);
        void LogFileOnly(TracingLevel level, string format, params object[] args);
        void LogFileOnly(TracingLevel level, Exception error, string format, params object[] args);

        #endregion
    }
}
