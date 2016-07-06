namespace KJFramework.Cores
{
    /// <summary>
    ///     ������Ԫ�ӿڣ��ṩ��������Ļ�����ȡ�ʹ洢����
    /// </summary>
    /// <typeparam name="T">��������</typeparam>
    public interface ICacheItem<T>
    {
        #region Methods.

        /// <summary>
        ///     ��ȡ��������
        /// </summary>
        /// <returns>���ػ�������</returns>
        T GetValue();
        /// <summary>
        ///     ���û�������
        /// </summary>
        /// <param name="obj">�������</param>
        void SetValue(T obj);

        #endregion
    }
}