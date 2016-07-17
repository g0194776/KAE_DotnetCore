using KJFramework.Net.Transaction.Processors;

namespace KJFramework.Net.Transaction.Objects
{
    /// <summary>
    ///     处理器对象信息集合
    /// </summary>
    internal class ProcessorObject
    {
        #region Members.

        /// <summary>
        ///     获取或设置处理器
        /// </summary>
        public IMessageProcessor Processor { get; set; }

        #endregion
    }
}