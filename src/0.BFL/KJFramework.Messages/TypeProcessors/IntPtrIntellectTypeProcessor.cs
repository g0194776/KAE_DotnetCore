using System;
using KJFramework.Messages.Analysers;
using KJFramework.Messages.Attributes;
using KJFramework.Messages.Exceptions;
using KJFramework.Messages.Helpers;
using KJFramework.Messages.Proxies;

namespace KJFramework.Messages.TypeProcessors
{
    /// <summary>
    ///    IntPtr类型智能处理器，提供了相关的基本操作。
    /// </summary>
    public class IntPtrIntellectTypeProcessor : IntellectTypeProcessor
    {
        #region 构造函数

        /// <summary>
        ///     IntPtr类型智能处理器，提供了相关的基本操作。
        /// </summary>
        public IntPtrIntellectTypeProcessor()
        {
            _supportedType = typeof(IntPtr);
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
            IntPtr value;
            if (!isNullable) value = analyseResult.GetValue<IntPtr>(target);
            else
            {
                IntPtr? nullableValue = analyseResult.GetValue<IntPtr?>(target);
                if (nullableValue == null)
                {
                    if (!attribute.IsRequire) return;
                    throw new PropertyNullValueException(
                        string.Format(ExceptionMessage.EX_PROPERTY_VALUE, attribute.Id,
                                        analyseResult.Property.Name,
                                        analyseResult.Property.PropertyType));
                }
                value = (IntPtr)nullableValue;
            }
            if (attribute.AllowDefaultNull && value.Equals(DefaultValue.IntPtr) && !isArrayElement) return;
            proxy.WriteByte((byte)attribute.Id);
            proxy.WriteIntPtr(value);
        }

        /// <summary>
        ///     从第三方客户数据转换为元数据
        ///     <para>* 此方法将会被轻量级的DataHelper所使用，并且写入的数据将不会拥有编号(Id)</para>
        /// </summary>
        /// <param name="proxy">内存片段代理器</param>
        /// <param name="target">目标对象实例</param>
        /// <param name="isArrayElement">当前写入的值是否为数组元素标示</param>
        /// <param name="isNullable">是否为可空字段标示</param>
        public override void Process(IMemorySegmentProxy proxy, object target, bool isArrayElement = false, bool isNullable = false)
        {
            IntPtr value;
            if (!isNullable) value = (IntPtr)target;
            else
            {
                if (target == null) return;
                value = (IntPtr)target;
            }
            proxy.WriteIntPtr(value);
        }

        /// <summary>
        ///     从元数据转换为第三方客户数据
        /// </summary>
        /// <param name="attribute">当前字段标注的属性</param>
        /// <param name="data">元数据</param>
        /// <returns>返回转换后的第三方客户数据</returns>
        /// <exception cref="Exception">转换失败</exception>
        public override object Process(IntellectPropertyAttribute attribute, byte[] data)
        {
            if (attribute == null) throw new System.Exception("非法的智能属性标签。");
            if (attribute.IsRequire && data == null) throw new System.Exception("无法处理非法的类型值。");
            //x86
            if(Size.IntPtr == 4) return new IntPtr(BitConverter.ToInt32(data, 0));
            //x64
            return new IntPtr(BitConverter.ToInt64(data, 0));
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
            //x86
            if (Size.IntPtr == 4)
            {
                if (result.Nullable) result.SetValue<IntPtr?>(instance, new IntPtr(BitConverter.ToInt32(data, offset)));
                else result.SetValue(instance, new IntPtr(BitConverter.ToInt32(data, offset)));
            }
            //x64
            else
            {
                if (result.Nullable) result.SetValue<IntPtr?>(instance, new IntPtr(BitConverter.ToInt64(data, offset)));
                else result.SetValue(instance, new IntPtr(BitConverter.ToInt64(data, offset)));
            }
        }

        #endregion
    }
}