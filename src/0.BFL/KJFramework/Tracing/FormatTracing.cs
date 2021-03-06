using System;
using KJFramework.Enums;

namespace KJFramework.Tracing
{
    internal class FormatTracing : NullTracing
    {
        #region Constructor.

        public FormatTracing(string logger)
        {
            if(string.IsNullOrEmpty(logger)) throw new ArgumentNullException(nameof(logger));
            _logger = logger;
        }

        #endregion

        #region Members.

        private readonly string _logger;

        #endregion

        #region Methods.

        protected override void Trace(TracingLevel level, Exception error, string format, object[] args, ConsoleColor color = ConsoleColor.Gray)
        {
            try
            {
                string message = ((args == null ||args.Length == 0) ? format : string.Format(format ?? string.Empty, args));
                #region Output message to Console.

                switch (level)
                {
                    case TracingLevel.Debug:
                        Console.ForegroundColor = color;
                        Console.WriteLine(message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case TracingLevel.Warn:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case TracingLevel.Error:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case TracingLevel.Crtitical:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }

                #endregion
                if (level >= TracingSettings.Level)
                {
                    TracingManager.AddTraceItem(new TraceItem(_logger, level, error, message));
                    if (TracingManager.NotificationHandler != null) TracingManager.NotificationHandler.Handle(level, error, message, _logger);
                }
            }
            catch
            {
                // mute everything...
            }
        }

        protected override void TraceFileOnly(TracingLevel level, string format, params object[] args)
        {
            try
            {
                if (level >= TracingSettings.Level)
                {
                    string message = string.Empty;
                    try
                    {
                        message = args.Length == 0 ? format : string.Format(format ?? string.Empty, args);
                        TracingManager.AddTraceItem(new TraceItem(_logger, level, null, message));
                    }
                    catch (System.Exception ex)
                    {
                        if (level < TracingLevel.Warn)
                            level = TracingLevel.Warn;
                        message = string.Concat("tracing formatting error: [", args.Length, "] ", format ?? string.Empty);
                        TracingManager.AddTraceItem(new TraceItem(_logger, level, ex, message));
                    }
                }
            }
            catch
            {
                // mute everything...
            }
        }

        protected override void TraceFileOnly(TracingLevel level, System.Exception error, string format, params object[] args)
        {
            try
            {
                if (level >= TracingSettings.Level)
                {
                    string message = string.Empty;
                    try
                    {
                        message = args.Length == 0 ? format : string.Format(format ?? string.Empty, args);
                    }
                    catch (System.Exception ex)
                    {
                        if (level < TracingLevel.Warn)
                            level = TracingLevel.Warn;
                        if (error == null)
                            error = ex;
                        message = string.Concat("tracing formatting error: [", args.Length, "] ", format ?? string.Empty);
                    }
                    TracingManager.AddTraceItem(new TraceItem(_logger, level, error, message));
                }
            }
            catch
            {
                // mute everything...
            }
        }

        #endregion
    }
}