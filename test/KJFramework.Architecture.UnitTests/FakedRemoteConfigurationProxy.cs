using System;
using KJFramework.EventArgs;
using KJFramework.Proxy;

namespace KJFramework.Architecture.UnitTests
{
    public class FakedRemoteConfigurationProxy : IRemoteConfigurationProxy
    {
        public event EventHandler<LightSingleArgEventArgs<Tuple<string, string>>> ConfigurationUpdated;

        public string GetField(string role, string field, Action<string> callback = null)
        {
            throw new NotImplementedException();
        }

        public string GetField(string role, string field, bool useCache = true)
        {
            throw new NotImplementedException();
        }

        public string GetPartialConfig(string configKey)
        {
            switch (configKey.ToLower())
            {
                case "kjframework.net":
                    return "{\"BufferSize\": \"10240\",\"BufferPoolSize\": \"4096\",\"MessageHeaderLength\": \"80\",\"MessageHeaderFlag\": \"#KJMS\",\"MessageHeaderFlagLength\": \"5\",\"MessageHeaderEndFlag\": \"€\",\"MessageHeaderEndFlagLength\": \"1\",\"MessageDealerFolder\": \".\\dealers\\\",\"MessageHookFolder\": \".\\hooks\\\",\"SpyFolder\": \".\\spys\\\",\"BasicSessionStringTemplate\": \"BASE-KEY\",\"UserHreatCheckTimeSpan\": \"10000\",\"UserHreatTimeout\": \"15000\",\"UserHreatAlertCount\": \"3\",\"FSHreatCheckTimeSpan\": \"10000\",\"FSHreatTimeout\": \"15000\",\"FSHreatAlertCount\": \"3\",\"SessionExpireCheckTimeSpan\": \"5000\",\"DefaultConnectionPoolConnectCount\": \"1024\",\"PredominantCpuUsage\": \"10\",\"PredominantMemoryUsage\": \"150\",\"DefaultChannelGroupLayer\": \"3\",\"DefaultDecleardSize\": \"20\"}";
                case "kjframework.net.channels":
                    return "{\"RecvBufferSize\": \"20480\",\"BuffStubPoolSize\": \"100000\",\"NoBuffStubPoolSize\": \"100000\",\"MaxMessageDataLength\": \"194560\",\"SegmentSize\": \"5120\",\"SegmentBuffer\": \"10240000\",\"NamedPipeBuffStubPoolSize\": \"1000\"}";
                case "kjframework.net.transaction":
                    return "{\"TransactionTimeout\": \"00:00:30\",\"TransactionCheckInterval\": \"30\",\"MinimumConnectionCount\": \"1\",\"MaximumConnectionCount\": \"5\",\"ConnectionLoadBalanceStrategy\": \"Sequential\"}";
            }
            return null;
        }

        public void UpdateConfiguration(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}