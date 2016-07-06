﻿using System;
using KJFramework.Messages.Analysers;
using KJFramework.Messages.Attributes;
using KJFramework.Messages.Exceptions;
using KJFramework.Messages.Helpers;
using KJFramework.Messages.Proxies;

namespace KJFramework.Messages.TypeProcessors
{
    /// <summary>
    ///     long数组类型处理器
    /// </summary>
    public class Int64ArrayIntellectTypeProcessor : IntellectTypeProcessor
    {
        #region Constructor

        /// <summary>
        ///     long数组类型处理器
        /// </summary>
        public Int64ArrayIntellectTypeProcessor()
        {
            _supportedType = typeof(long[]);
            _supportUnmanagement = true;
        }

        #endregion

        #region Overrides of IntellectTypeProcessor

        /// <summary>
        ///     从第三方客户数据转换为元数据
        /// </summary>
        /// <param name="proxy">内存片段代理器</param>
        /// <param name="attribute">字段属性</param>
        /// <param name="analyseResult">分析结果</param>
        /// <param name="target">目标对象实例</param>
        /// <param name="isArrayElement">当前写入的值是否为数组元素标示</param>
        public override void Process(IMemorySegmentProxy proxy, IntellectPropertyAttribute attribute, ToBytesAnalyseResult analyseResult, object target, bool isArrayElement = false, bool isNullable = false)
        {
            long[] value = analyseResult.GetValue<long[]>(target);
            if (value == null)
            {
                if (!attribute.IsRequire) return;
                throw new PropertyNullValueException(string.Format(ExceptionMessage.EX_PROPERTY_VALUE, attribute.Id, analyseResult.Property.Name, analyseResult.Property.PropertyType));
            }
            //id(1) + total length(4) + rank(4)
            proxy.WriteByte((byte)attribute.Id);
            MemoryPosition position = proxy.GetPosition();
            proxy.Skip(4U);
            proxy.WriteInt32(value.Length);
            if (value.Length == 0)
            {
                proxy.WriteBackInt32(position, 4);
                return;
            }
            if (value.Length > 10)
            {
                unsafe
                {
                    fixed (long* pByte = value) proxy.WriteMemory(pByte, (uint) (value.Length*Size.Int64));
                }
            }
            else for (int i = 0; i < value.Length; i++) proxy.WriteInt64(value[i]);
            proxy.WriteBackInt32(position, (int) (value.Length*Size.Int64 + 4));
        }

        /// <summary>
        ///     从第三方客户数据转换为元数据
        ///     <para>* 此方法将会被轻量级的DataHelper所使用，并且写入的数据将不会拥有编号(Id)</para>
        /// </summary>
        /// <param name="proxy">内存片段代理器</param>
        /// <param name="target">目标对象实例</param>
        /// <param name="isArrayElement">当前写入的值是否为数组元素标示</param>
        /// <param name="isNullable">是否为可空字段标示</param>
        public unsafe override void Process(IMemorySegmentProxy proxy, object target, bool isArrayElement = false, bool isNullable = false)
        {
            long[] array = (long[])target;
            if (array == null || array.Length == 0) return;
            if (array.Length > 10) fixed (long* pByte = array) proxy.WriteMemory(pByte, (uint)array.Length * Size.Int64);
            else for (int i = 0; i < array.Length; i++) proxy.WriteInt64(array[i]);
        }
        
        /// <summary>
        ///     从元数据转换为第三方客户数据
        /// </summary>
        /// <param name="attribute">当前字段标注的属性</param>
        /// <param name="data">元数据</param>
        /// <returns>返回转换后的第三方客户数据</returns>
        /// <exception cref="Exception">转换失败</exception>
        public unsafe override object Process(IntellectPropertyAttribute attribute, byte[] data)
        {
            long[] array = new long[data.Length/Size.Int64];
            fixed (byte* pByte = data)
            {
                long* pData = (long*)pByte;
                for (int i = 0; i < array.Length; i++) array[i] = *pData++;
            }
            return array;
        }
        
        /// <summary>
        ///     从元数据转换为第三方客户数据
        /// </summary>
        /// <param name="instance">目标对象</param>
        /// <param name="result">分析结果</param>
        /// <param name="data">元数据</param>
        /// <param name="offset">元数据所在的偏移量</param>
        /// <param name="length">元数据长度</param>
        public override void Process(object instance, GetObjectAnalyseResult result, byte[] data, int offset, int length = 0)
        {
            if (length == 4)
            {
                result.SetValue(instance, new long[0]);
                return;
            }
            long[] array;
            unsafe
            {
                fixed (byte* pByte = &data[offset])
                {
                    int arrLength = *(int*)pByte;
                    array = new long[arrLength];
                    if (arrLength > 10)
                    {
                        fixed (long* point = array)
                        {
                            Buffer.MemoryCopy((void*)new IntPtr(pByte + 4), (void*)new IntPtr((byte*)point), (uint)(Size.Int64 * arrLength), (uint)(Size.Int64 * arrLength));
                            //Native.Win32API.memcpy(new IntPtr((byte*)point), new IntPtr(pByte + 4), (uint)(Size.Int64 * arrLength));
                        }

                    }
                    else
                    {
                        long* point = (long*)(pByte + 4);
                        for (int i = 0; i < arrLength; i++)
                            array[i] = *(point++);
                    }
                }
            }
            result.SetValue(instance, array);
        }

        #endregion
    }
}