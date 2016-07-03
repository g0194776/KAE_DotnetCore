using System;
namespace KJFramework.EventArgs
{
    /// <summary>
    ///     新信息事件
    /// </summary>
    public class NewInfomationEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     新信息事件
        /// </summary>
        /// <param name="infomation">收集到的新信息</param>
        public NewInfomationEventArgs(string infomation)
        {
            Infomation = infomation;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取收集到的信息
        /// </summary>
        public string Infomation { get; }

        #endregion
    }
}