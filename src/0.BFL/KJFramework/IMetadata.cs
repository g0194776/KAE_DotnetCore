namespace KJFramework
{
    /// <summary>
    ///     元数据接口
    /// </summary>
    public interface IMetadata<T>
    {
        #region Members.

        /// <summary>
        ///     获取或设置用来约束所有对象的唯一标示
        /// </summary>
        T Key { get; set; }

        #endregion

    }
}
