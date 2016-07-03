using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using KJFramework.Enums;

namespace KJFramework.Tracing 
{
    /// <summary>
    ///     信息记录管理器
    /// </summary>
    public static class TracingManager
    {
        #region Constructor.

        static TracingManager()
        {
            Thread proc = new Thread(TraceItemWatcher);
            proc.IsBackground = true;
            proc.Name = "TracingManager::TraceItemWatcher";
            proc.Start();
            LoadProvider();
        }

        #endregion

        #region Members.

        private const int Capacity = 10000;
        private static ITracingProvider _provider;
        /// <summary>
        ///     获取或设置全局日志通知器
        /// </summary>
        public static ITracingNotificationHandler NotificationHandler { get; set; }
        private static readonly Queue<TraceItem> _items = new Queue<TraceItem>(Capacity);

        #endregion

        #region Methods.

        private static void LoadProvider()
        {
            switch (TracingSettings.Provider.ToLower())
            {
                case "file": _provider = new FileTracingProvider(TracingSettings.Datasource); break;
                case "con": _provider = new StdErrTracingProvider(); break;
                //case "db": _provider = new DbTracingProvider(TracingSettings.Datasource); break;
                default: _provider = null; break;
            }
        }

        public static ITracing GetTracing(Type type)
        {
            return GetTracing(type.FullName);
        }

        public static ITracing GetTracing(string logger)
        {
            return new FormatTracing(logger);
        }

        internal static void AddTraceItem(TraceItem item)
        {
            lock (_items)
            {
                while (_items.Count >= Capacity) _items.Dequeue();
                _items.Enqueue(item);
            }
        }

        private static void TraceItemWatcher()
        {
            string pid;
            string pname;

            Process p = Process.GetCurrentProcess();
            pid = p.Id.ToString();
            pname = p.ProcessName;

            while (true)
            {
                Thread.Sleep(1000);
                try
                {
                    TraceItem[] items;
                    lock (_items)
                    {
                        if (_items.Count < 1)
                            continue;
                        items = _items.ToArray();
                        _items.Clear();
                    }

                    try
                    {
                        for (int i = 0; i < items.Length; ++i)
                            if (items[i].Level == TracingLevel.Crtitical)
                                WriteEventLog(string.Concat(
                                        pid, items[i].Timestamp.ToString(" @ yyyy-MM-dd HH:mm:ss.fff "),
                                        items[i].Logger, Environment.NewLine, Environment.NewLine,
                                        items[i].Message, Environment.NewLine, Environment.NewLine,
                                        items[i].Error == null ? string.Empty : items[i].Error.ToString()
                                ), true);
                    }
                    catch (Exception ex) { Trace.WriteLine(ex); }

                    ITracingProvider provider = _provider;
                    if (provider != null) provider.Write(pid, pname, Environment.GetEnvironmentVariable("COMPUTERNAME"), items);
                }
                catch (Exception ex) { WriteEventLog(ex.ToString(), true); }
            }
        }

        private static string _eventSource = Process.GetCurrentProcess().ProcessName;
        internal static void WriteEventLog(string message, bool error)
        {
            
        }

        #endregion
    }
}
