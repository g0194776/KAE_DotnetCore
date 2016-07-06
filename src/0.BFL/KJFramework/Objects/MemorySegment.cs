using System;
using System.Diagnostics;

namespace KJFramework.Objects
{
    /// <summary>
    ///     �ֽ������ڴ�Ƭ�Σ��ṩ����صĻ�������
    /// </summary>
    [DebuggerDisplay("Usedbytes: {UsedBytes}, Offset: {Segment.Offset}")]
    public class MemorySegment : IMemorySegment
    {
        #region Constructor.

        /// <summary>
        ///     �ֽ������ڴ�Ƭ�Σ��ṩ����صĻ�������
        /// </summary>
        /// <param name="segment">�ֽ������ڴ�Ƭ��</param>
        public MemorySegment(ArraySegment<byte> segment)
        {
            _segment = segment;
        }

        #endregion

        #region Members.

        private readonly ArraySegment<byte> _segment;

        /// <summary>
        ///     ��ȡ�ڲ����ֽ�����Ƭ��
        /// </summary>
        public ArraySegment<byte> Segment => _segment;

        /// <summary>
        ///     ��ȡ��������ʹ�õ��ֽ�����
        /// </summary>
        public int UsedBytes { get; set; }

        /// <summary>
        ///     ��ȡ��������ʹ��ƫ����
        ///     <para>* ���ǽ�����Ӧ������ʹ�ô��������жϵ�ǰ�������ݵ���ʵƫ����.</para>
        ///     <para>* �����ô����Ժ����ǽ����Զ�����UsedBytes.</para>
        /// </summary>
        public int UsedOffset
        {
            get { return _segment.Offset + UsedBytes; }
            set { UsedBytes += value; }
        }

        #endregion
    }
}