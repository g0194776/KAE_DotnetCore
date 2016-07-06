namespace KJFramework
{
    /// <summary>
    ///     支持克隆方式的接口
    /// </summary>
    public interface ICloneable
    {
        #region Methods.

        /// <summary>
        ///     克隆当前对象
        /// </summary>
        /// <returns>返回当前对象克隆后的浅备份</returns>
        object Clone();

        #endregion
    }
}