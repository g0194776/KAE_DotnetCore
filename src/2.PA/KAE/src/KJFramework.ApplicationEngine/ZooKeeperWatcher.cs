using System;
using System.Threading.Tasks;
using org.apache.zookeeper;

namespace KJFramework.ApplicationEngine
{
    /// <summary>
    ///    ZooKeeper所使用的通知观察器
    /// </summary>
    public class ZooKeeperWatcher : Watcher
    {
        #region Constructor.

        /// <summary>
        ///    ZooKeeper所使用的通知观察器
        /// </summary>
        public ZooKeeperWatcher(Action<WatchedEvent> callback)
        {
            if(callback == null) throw new ArgumentNullException(nameof(callback));
            _callback = callback;
        }

        #endregion

        #region Members.

        private readonly Action<WatchedEvent> _callback;

        #endregion

        #region Methods.

        /// <summary>
        /// Processes the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns/>
        public override Task process(WatchedEvent @event)
        {
            _callback(@event);
            return null;
        }

        #endregion
    }
}