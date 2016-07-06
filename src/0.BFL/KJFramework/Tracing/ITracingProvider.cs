namespace KJFramework.Tracing 
{
    /// <summary>
    ///     信息记录提供器接口
    /// </summary>
    public interface ITracingProvider
    {
        #region Methods.

        /// <summary>
        ///     记录一条信息
        /// </summary>
        /// <param name="pid">当前进程的编号</param>
        /// <param name="pname">名称</param>
        /// <param name="machine">主机信息</param>
        /// <param name="items">详细的记项录列表</param>
        void Write(string pid, string pname, string machine, TraceItem[] items);

        #endregion
    }
}
