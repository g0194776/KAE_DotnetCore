using System.Runtime.InteropServices;

namespace KJFramework.Net.Identities
{
    /// <summary>
    ///     消息唯一标示，提供了相关的基本属性结构
    ///     <para>* 此标示仅用来与客户端通讯时使用</para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 5)]
    public struct MessageIdentity
    {
        #region Members.

        /// <summary>
        ///     获取或设置消息大分类编号
        /// </summary>
        [FieldOffset(0)] public byte ProtocolId;

        /// <summary>
        ///     获取或设置消息小分类编号
        /// </summary>
        [FieldOffset(1)] public byte ServiceId;

        /// <summary>
        ///     获取或设置消息详细分类编号
        /// </summary>
        [FieldOffset(2)] public byte DetailsId;

        /// <summary>
        ///     获取或设置当前消息事务唯一编号
        /// </summary>
        [FieldOffset(3)] public short Tid;

        #endregion

        #region Methods

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"(P: {ProtocolId}, S: {ServiceId}, D: {DetailsId}, T: {Tid}) *{(DetailsId%2 == 0 ? "REQ" : "RSP")} MESSAGE";
        }

        #endregion
    }
}