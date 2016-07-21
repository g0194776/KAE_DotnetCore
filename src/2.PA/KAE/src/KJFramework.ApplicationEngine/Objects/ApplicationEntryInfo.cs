namespace KJFramework.ApplicationEngine.Objects
{
    /// <summary>
    ///     应用入口信息对象
    /// </summary>
    public class ApplicationEntryInfo
    {
        #region Members.

        /// <summary>
        ///     获取或设置文件CRC值
        /// </summary>
        public long FileCRC { get; set; }
        /// <summary>
        ///     获取或设置文件路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        ///     获取或设置目录路径
        /// </summary>
        public string FolderPath { get; set; }
        /// <summary>
        ///     获取或设置入口点名称
        /// </summary>
        public string EntryPoint { get; set; }

        #endregion
    }
}