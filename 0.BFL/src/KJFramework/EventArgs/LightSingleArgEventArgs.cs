namespace KJFramework.EventArgs
{
    /// <summary>
    ///     KJFramework�ṩ����������һ�����¼���ʹ�ø��¼�����ʡȥ���±�д�ض��¼�����¼���
    /// </summary>
    /// <typeparam name="T">��������</typeparam>
    public class LightSingleArgEventArgs<T> : CanDisposeEventArgs
    {
        #region Constructor.

        /// <summary>
        ///     KJFramework�ṩ����������һ�����¼���ʹ�ø��¼�����ʡȥ���±�д�ض��¼�����¼���
        /// </summary>
        /// <param name="target">����</param>
        public LightSingleArgEventArgs(T target)
        {
            Target = target;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     ��ȡĿ��
        /// </summary>
        public T Target { get; }

        #endregion

    }
}