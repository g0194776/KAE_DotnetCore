using System;
using System.IO;
using System.Text;
using KJFramework.ApplicationEngine.Eums;
using KJFramework.EventArgs;
using KJFramework.Net.Identities;
using KJFramework.Net.Transaction.Objects;
using KJFramework.Net.Uri;
using KJFramework.Tracing;
using org.apache.zookeeper;
using Uri = KJFramework.Net.Uri.Uri;

namespace KJFramework.ApplicationEngine.Proxies
{
    /// <summary>
    ///     远程协议注册器
    /// </summary>
    internal sealed class ZooKeeperProtocolRegister : IRemotingProtocolRegister
    {
        #region Constructor.

        /// <summary>
        ///     远程协议注册器
        /// </summary>
        /// <param name="connectionStr">远程ZooKeeper服务器的连接字符串</param>
        /// <param name="sessionTimeout">ZooKeeper的会话超时时间</param>
        public ZooKeeperProtocolRegister(string connectionStr, TimeSpan sessionTimeout)
        {
            if (string.IsNullOrEmpty(connectionStr)) throw new ArgumentNullException(nameof(connectionStr));
            _client = new ZooKeeper(connectionStr, (int) sessionTimeout.TotalMilliseconds, null);
        }

        #endregion

        #region Members.

        private string _basePath;
        private string _protocolPath;
        private readonly ZooKeeper _client;
        private static readonly ITracing _tracing = TracingManager.GetTracing(typeof (ZooKeeperProtocolRegister));

        #endregion

        #region Methods.

        /// <summary>
        ///     初始化
        /// </summary>
        public void Initialize(string hostName, TcpUri basicCommunicationAddress)
        {
            _basePath = SystemWorker.ConfigurationProxy.GetField("kae-system", "ZooKeeperBasePath", false);
            if (_client.existsAsync(_basePath, false).Result == null)
            {
                try { _client.createAsync(_basePath, null, ZooDefs.Ids.OPEN_ACL_UNSAFE, CreateMode.PERSISTENT).Wait(); }
                catch (Exception) { }
            }
            //hosting node.
            string hostingPath = Path.Combine(_basePath, "hosting");
            hostingPath = hostingPath.Replace("\\", "/");
            if (_client.existsAsync(hostingPath, false).Result == null)
            {
                try { _client.createAsync(hostingPath, null, ZooDefs.Ids.OPEN_ACL_UNSAFE, CreateMode.PERSISTENT).Wait(); }
                catch (Exception) { }
            }
            //protocols node.
           _protocolPath = Path.Combine(_basePath, "protocols");
           _protocolPath = _protocolPath.Replace("\\", "/");
           if (_client.existsAsync(_protocolPath, false).Result == null)
            {
                try { _client.createAsync(_protocolPath, null, ZooDefs.Ids.OPEN_ACL_UNSAFE, CreateMode.PERSISTENT).Wait(); }
                catch (Exception) { }
            }
            //create resource node.
            string resourcePath = Path.Combine(_basePath, "hosting/", hostName);
            resourcePath = resourcePath.Replace("\\", "/");
            if (_client.existsAsync(resourcePath, false).Result == null)
            {
                try { _client.createAsync(resourcePath, Encoding.UTF8.GetBytes(basicCommunicationAddress.ToString()), ZooDefs.Ids.OPEN_ACL_UNSAFE, CreateMode.EPHEMERAL).Wait(); }
                catch (Exception) { }
            }
        }

        /// <summary>
        ///     将一个业务的通信协议与远程可访问地址注册到服务器上
        /// </summary>
        /// <param name="identity">业务协议编号</param>
        /// <param name="protocolTypes">通信协议类型</param>
        /// <param name="level">KAE应用等级</param>
        /// <param name="resourceUri">远程可访问的资源地址</param>
        /// <param name="kppUniqueId">KPP全局唯一编号</param>
        public void Register(MessageIdentity identity, ProtocolTypes protocolTypes, ApplicationLevel level, Uri resourceUri, Guid kppUniqueId)
        {
            if(resourceUri == null) throw new ArgumentNullException(nameof(resourceUri));
            string path = string.Format("{0}/{1}-{2}-{3}-{4}", _protocolPath, identity.ProtocolId, identity.ServiceId, identity.DetailsId, level);
            AddPath(path, CreateMode.PERSISTENT);
            path += string.Format("/{0};{1}", resourceUri.Address, kppUniqueId);
            AddPath(path, CreateMode.PERSISTENT);
        }

        /// <summary>
        ///    根据一组参数获取相应的远程目标资源
        /// </summary>
        /// <param name="level">应用等级</param>
        /// <param name="protocol">通信协议</param>
        /// <param name="protocolTypes">协议类型</param>
        /// <returns>返回远程目标可访问资源</returns>
        public IProtocolResource GetProtocolResource(Protocols protocol, ProtocolTypes protocolTypes, ApplicationLevel level)
        {
            string path = string.Format("{0}/{1}-{2}-{3}-{4}-{5}", _protocolPath, protocol.ProtocolId, protocol.ServiceId, protocol.DetailsId, protocolTypes, level);
            IProtocolResource resource = new ProtocolResource(_client, path, protocol, protocolTypes, level);
            resource.ChildrenChanged += delegate(object sender, System.EventArgs args) { OnChildrenChanged(new LightSingleArgEventArgs<IProtocolResource>((IProtocolResource) sender));};
            return resource;
        }

        private void AddPath(string path, CreateMode mode)
        {
            if (_client.existsAsync(path, false).Result != null) return;
            try { _client.createAsync(path, null, ZooDefs.Ids.OPEN_ACL_UNSAFE, mode).Wait(); }
            catch (KeeperException.NodeExistsException) { }
        }

        #endregion

        #region Events.

        /// <summary>
        ///    远程资源列表变更事件
        /// </summary>
        public event EventHandler<LightSingleArgEventArgs<IProtocolResource>> ChildrenChanged;

        private void OnChildrenChanged(LightSingleArgEventArgs<IProtocolResource> e)
        {
            EventHandler<LightSingleArgEventArgs<IProtocolResource>> handler = ChildrenChanged;
            if (handler != null) handler(this, e);
        }

        #endregion
    }
}