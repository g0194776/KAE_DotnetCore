namespace KJFramework.Net.Exception
{
    /// <summary>
    ///     观察规则为空异常
    /// </summary>
    public class ObserverRuleHasNullException : System.Exception
    {
        #region Constructor.

        /// <summary>
        ///     观察规则为空异常
        /// </summary>
        public ObserverRuleHasNullException() : base("观察规则不能为空!")
        {

        }

        #endregion

    }
}
