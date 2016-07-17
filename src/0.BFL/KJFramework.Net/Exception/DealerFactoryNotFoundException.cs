namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     未找到消息处理工厂异常
    /// </summary>
    /// <remarks>
    ///     当消息处理工厂 == null时, 触发该异常
    /// </remarks>
    public class DealerFactoryNotFoundException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     未找到消息处理工厂异常
        /// </summary>
        /// <remarks>
        ///     当消息处理工厂 == null时, 触发该异常
        /// </remarks>
        public DealerFactoryNotFoundException() : base("未找到消息处理工厂 !")
        {
        }

        #endregion

    }
}
