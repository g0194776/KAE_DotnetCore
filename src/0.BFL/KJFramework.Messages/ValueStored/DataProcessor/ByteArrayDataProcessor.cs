﻿using System;
using KJFramework.Messages.Contracts;
using KJFramework.Messages.Enums;
using KJFramework.Messages.Helpers;
using KJFramework.Messages.Proxies;

namespace KJFramework.Messages.ValueStored.DataProcessor
{
    /// <summary>
    ///     Byte数组关于元数据的处理
    /// </summary>
    public class ByteArrayDataProcessor : IDataProcessor
    {
        #region Members

        /// <summary>
        ///     元数据转换成第三方数据
        /// </summary>
        public PropertyTypes TypeId { get { return PropertyTypes.ByteArray; } }

        #endregion

        #region Methods

        /// <summary>
        ///     元数据转换成第三方数据
        /// </summary>
        /// <param name="metadataObject">元数据集合</param>
        /// <param name="id">属性对应key</param>
        /// <param name="data">属性对应byte数组</param>
        /// <param name="offsetStart">属性在数组中的偏移值</param>
        /// <param name="length">属性在byte数组中的长度</param>
        /// <exception cref="ArgumentNullException">参数不能为空</exception>
        public unsafe void DataProcessor(MetadataContainer metadataObject, byte id, byte[] data, int offsetStart, uint length)
        {
            if (metadataObject == null) throw new ArgumentNullException("metadataObject");
            if (length == 0)
            {
                metadataObject.SetAttribute(id, new ByteArrayValueStored(new byte[0]));
                return;
            }
            byte[] array = new byte[length / Size.Byte];
            fixed (byte* pByte = (&data[offsetStart]))
            {
                byte* pData = pByte;
                for (int j = 0; j < array.Length; j++) array[j] = *pData++;
            }
            metadataObject.SetAttribute(id, new ByteArrayValueStored(array));
        }

        /// <summary>
        ///     第三方数据转换成元数据
        /// </summary>
        /// <param name="proxy">内存段实例</param>
        /// <param name="baseValueMessage">存储属性的实例对象</param>
        /// <exception cref="ArgumentNullException">参数不能为空</exception>
        public unsafe void ValueProcessor(IMemorySegmentProxy proxy, BaseValueStored baseValueMessage)
        {
            if (proxy == null) throw new ArgumentNullException("proxy");
            if (baseValueMessage == null) throw new ArgumentNullException("baseValueMessage");
            fixed (byte* pByte = baseValueMessage.GetValue<byte[]>())
                proxy.WriteMemory(pByte, (uint)baseValueMessage.GetValue<byte[]>().Length * Size.Byte);
        }

        #endregion
    }
}