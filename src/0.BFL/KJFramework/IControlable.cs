namespace KJFramework
{
    /// <summary>
    ///     可操作对象接口
    /// </summary>
    public interface IControlable
    {
        #region Methods.

        /// <summary>
        ///      开始执行
        /// </summary>
        void Start();

        /// <summary>
        ///    停止执行
        /// </summary>
        void Stop();

        #endregion

    }
}