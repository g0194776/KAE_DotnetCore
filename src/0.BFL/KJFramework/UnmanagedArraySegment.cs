namespace KJFramework
{
    /// <summary>
    ///     非托管的内存段
    ///     <para>* 使用此结构将不会进行安全边界检查</para>
    /// </summary>
    public unsafe struct UnmanagedArraySegment
    {
        #region Constructor.

        /// <summary>
        ///     非托管的内存段
        ///     <para>* 使用此结构将不会进行安全边界检查</para>
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="offset">当前内存段偏移</param>
        /// <param name="length">当前内存段可用长度</param>
        public UnmanagedArraySegment(byte* data, int offset, int length)
        {
            Array = data;
            Offset = offset;
            Length = length;
            RefPointer = Array + offset;
        }

        #endregion

        #region Members.

        /// <summary>
        ///     获取关联的数组
        /// </summary>
        public byte* Array { get; }
        /// <summary>
        ///     获取从当前内存段起始位置的内存指针
        /// </summary>
        public byte* RefPointer { get; }
        /// <summary>
        ///     获取当前内存段偏移
        /// </summary>
        public int Offset { get; }
        /// <summary>
        ///     获取当前内存段可用长度
        /// </summary>
        public int Length { get; }

        #endregion
    }
}