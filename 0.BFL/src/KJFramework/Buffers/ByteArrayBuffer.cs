using System;
using System.Collections.Generic;

namespace KJFramework.Buffers
{
    /// <summary>
    ///   �ֽ����黺�������������ڽ�����Ϣ��ʱ������յ����ֽ�����
    /// </summary>
    public abstract class ByteArrayBuffer : IByteArrayBuffer
    {
        #region Constructor.

        /// <summary>
        ///   �ֽ����黺�������������ڽ�����Ϣ��ʱ������յ����ֽ�����
        ///   <para>* �������Ĵ�СӦ������Ϊ������������ * ������</para>
        /// </summary>
        /// <param name="bufferSize">����������</param>
        protected ByteArrayBuffer(int bufferSize)
        {
            if (bufferSize <= 0) throw new Exception("�޷���ʼ�����������Ƿ��Ļ���������");
            _buffer = new byte[bufferSize];
        }

        #endregion

        #region Members

        protected int _offset;
        protected byte[] _buffer;
        protected int _bufferSize;
        protected bool _autoClear;
        private readonly object _oo = new object();

        /// <summary>
        ///   ��ȡ��������С
        ///   <para>* �������Ĵ�СӦ������Ϊ������������ * ������</para>
        /// </summary>
        public int BufferSize => _bufferSize;

        /// <summary>
        ///   ��ȡ������һ��ֵ����ֵ��ʾ�����������������ʱ���Ƿ��Զ����û�����
        /// </summary>
        public bool AutoClear
        {
            get { return _autoClear; }
            set { _autoClear = value; }
        }

        #endregion

        #region Abstract Methods.

        /// <summary>
        ///   ��ӻ���
        /// </summary>
        /// <param name="data">���յ�������</param>
        public List<byte[]> Add(byte[] data)
        {
            lock (_oo)
            {
                //�����ǰ������ʣ��Ŀռ��Ѿ��޷������½������ݵĳ��ȡ�
                if (_buffer.Length - _offset < data.Length)
                {
                    //�Զ����û�����
                    if (_autoClear) Clear();
                    else throw new Exception("�������޷��ٽ����µ����ݣ���Ϊ�������Ѿ����ˡ��볢������AutoClear = true����������⡣");
                }
                //��������
                Buffer.BlockCopy(data, 0, _buffer, _offset, data.Length);
                _offset += data.Length;
                //��ȡ����
                int currentOffset = 0;
                List<byte[]> result = PickupData(ref currentOffset, _offset);
                //û����ȡ����������
                if (currentOffset <= 0) return null;
                //��ȡ������������
                if (currentOffset > 0)
                {
                    int leaveSize = _buffer.Length - currentOffset;
                    //�����ǰ���õ����ݳ��ȣ����õ��ڻ������ܳ��ȣ������û�����ƫ����
                    if (leaveSize <= 0)
                    {
                        //��������ƫ����Ϊ0���������³�ʼ����������Ŀ����Ϊ�˼����ڴ����
                        //��һ�εĲ�����ֱ�Ӹ�д0λ������
                        _offset = 0;
                        return result;
                    }
                    //����ʣ�������
                    byte[] lastData = new byte[leaveSize];
                    Buffer.BlockCopy(_buffer, currentOffset, lastData, 0, lastData.Length);
                    //���Ƶ�ԭ���Ļ�������
                    Buffer.BlockCopy(lastData, 0, _buffer, 0, lastData.Length);
                    //����ƫ����
                    _offset -= currentOffset;
                    return result;
                }
                return null;
            }
        }

        /// <summary>
        ///   ��ջ�����
        /// </summary>
        public void Clear()
        {
            _buffer.Initialize();
            _offset = 0;
        }

        #endregion

        #region Methods.

        /// <summary>
        ///   �������û�ʹ�õķ���������ʹ���Լ��ķ�ʽ��ȡ���õ�����
        /// </summary>
        /// <returns></returns>
        protected abstract List<byte[]> PickupData(ref int nextOffset, int offset);

        #endregion
    }
}