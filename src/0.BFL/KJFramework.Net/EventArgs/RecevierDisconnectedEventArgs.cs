using System;
namespace KJFramework.Net.EventArgs
{
    /// <summary>
    ///     �������Ͽ������¼�
    /// </summary>
    public class RecevierDisconnectedEventArgs : System.EventArgs
    {
        #region Constructor.

        /// <summary>
        ///     �������Ͽ������¼�
        /// </summary>
        /// <param name="key">Ψһ��ʶ</param>
        public RecevierDisconnectedEventArgs(String key)
        {
            Key = key;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     ��ȡ������Ψһ��ʶ
        /// </summary>
        public String Key { get; }

        #endregion
    }
}