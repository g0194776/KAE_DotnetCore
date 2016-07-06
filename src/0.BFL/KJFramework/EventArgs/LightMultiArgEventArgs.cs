namespace KJFramework.EventArgs
{
    /// <summary>
    ///     KJFramework�ṩ��������������¼���ʹ�ø��¼�����ʡȥ���±�д�ض��¼�����¼���
    /// </summary>
    /// <typeparam name="T">��������</typeparam>
    public class LightMultiArgEventArgs<T> : CanDisposeEventArgs
    {
        #region Constructor.

        /// <summary>
        ///     KJFramework�ṩ��������������¼���ʹ�ø��¼�����ʡȥ���±�д�ض��¼�����¼���
        /// </summary>
        /// <param name="target">����</param>
        public LightMultiArgEventArgs(params T[] target)
        {
            Target = target;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     ��ȡĿ��
        /// </summary>
        public T[] Target { get; }

        #endregion
    }
}