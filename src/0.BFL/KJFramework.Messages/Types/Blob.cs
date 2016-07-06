using System;
using System.Text;
using KJFramework.Messages.Enums;
using KJFramework.Tracing;

namespace KJFramework.Messages.Types
{
    /// <summary>
    ///     大数据对象，使用此对象的场景在于需要对元数据进行压缩传输
    ///     <para>* 使用Blob类型进行数据传输，虽然会减少传输数据的长度但是要增加压缩/解压缩的时间成本，请慎用。</para>
    ///     <para>* 默认使用GZIP方式进行压缩/解压缩</para>
    /// </summary>
    public class Blob
    {
        #region Members

        private int _count;
        private readonly int _index;
        private byte[] _compressedData;
        private byte[] _decompressedData;
        private readonly CompressionTypes _type;
        private readonly bool _isCompleteConstructed;
        private static readonly ITracing _tracing = TracingManager.GetTracing(typeof (Blob));

        /// <summary>
        ///     获取内部使用的压缩算法类型
        /// </summary>
        public CompressionTypes CompressionType
        {
            get { return _type; }
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     大数据对象，使用此对象的场景在于需要对元数据进行压缩传输
        ///     <para>* 使用Blob类型进行数据传输，虽然会减少传输数据的长度但是要增加压缩/解压缩的时间成本，请慎用。</para>
        ///     <para>* 默认使用GZIP方式进行压缩/解压缩</para>
        ///     <para>* 使用此构造传入的数据为 *完全构造数据*</para>
        /// </summary>
        /// <param name="networkData">完全构造数据</param>
        public Blob(byte[] networkData)
            : this(networkData, 0, networkData.Length)
        {
        }

        /// <summary>
        ///     大数据对象，使用此对象的场景在于需要对元数据进行压缩传输
        ///     <para>* 使用Blob类型进行数据传输，虽然会减少传输数据的长度但是要增加压缩/解压缩的时间成本，请慎用。</para>
        ///     <para>* 默认使用GZIP方式进行压缩/解压缩</para>
        ///     <para>* 使用此构造传入的数据为 *完全构造数据*</para>
        /// </summary>
        /// <param name="networkData">完全构造数据</param>
        /// <param name="index">可用位置起始偏移</param>
        /// <param name="count">可用长度</param>
        public Blob(byte[] networkData, int index, int count)
        {
            if (networkData == null || networkData.Length == 0) throw new ArgumentNullException("networkData");
            _type = (CompressionTypes)networkData[index];
            _index = index + 1;
            _compressedData = networkData;
            _count = count - 1;
            _isCompleteConstructed = true;
        }

        /// <summary>
        ///     大数据对象，使用此对象的场景在于需要对元数据进行压缩传输
        ///     <para>* 使用Blob类型进行数据传输，虽然会减少传输数据的长度但是要增加压缩/解压缩的时间成本，请慎用。</para>
        ///     <para>* 默认使用GZIP方式进行压缩/解压缩</para>
        /// </summary>
        /// <param name="type">使用的压缩类型</param>
        /// <param name="rawData">元数据</param>
        public Blob(CompressionTypes type, byte[] rawData)
        {
            if (rawData == null || rawData.Length == 0) throw new ArgumentNullException("rawData");
            _type = type;
            _decompressedData = rawData;
            _index = 0;
            _count = rawData.Length;
            _isCompleteConstructed = false;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     使用指定的方式压缩内部数据，并返回压缩后的数据
        /// </summary>
        /// <returns>返回压缩后的字节数据</returns>
        public byte[] Compress()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     使用指定的方式压缩内部数据，并返回压缩后的数据
        /// </summary>
        /// <returns>返回压缩后的字节数据</returns>
        public byte[] Decompress()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     输出压缩比信息
        /// </summary>
        /// <returns>返回压缩比信息</returns>
        public override string ToString()
        {
            return ToString(string.Empty);
        }

        /// <summary>
        ///     输出压缩比信息
        /// </summary>
        /// <para>输出格式的对齐长度</para>
        /// <returns>返回压缩比信息</returns>
        internal string ToString(string space)
        {
            if (_compressedData == null || _decompressedData == null)
                return "#Sadly, We cannot calc details infomation, Because [compress data] or [de-compress data] is NULL.";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format("{0}#Used Compression Method: {1}", space, _type));
            stringBuilder.AppendLine(string.Format("{0}#Compressed Length: {1}", space, _count));
            stringBuilder.AppendLine(string.Format("{0}#Decompressed Length: {1}", space, _decompressedData.Length));
            stringBuilder.Append(string.Format("{0}#Compression Percentage: {1}%", space, Math.Round((((double)_decompressedData.Length - (double)_count) / (double)_decompressedData.Length) * 100), 2));
            return stringBuilder.ToString();
        }

        #endregion
    }
}