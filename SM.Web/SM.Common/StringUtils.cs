using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Common
{
    public class StringUtils
    {
        public static T TryParse<T>(string value)
        {
            return TryParse<T>(value, default(T));
        }

        public static T TryParse<T>(string value, T defaultValue)
        {
            object r = null;

            if (TryParse(typeof(T), value, out r))
            {
                return (T)r;
            }
            return defaultValue;
        }

        public static bool TryParse<T>(string value, out T result)
        {
            object r = null;

            if (TryParse(typeof(T), value, out r))
            {
                result = (T)r;
                return true;
            }

            result = default(T);

            return false;
        }

        /// <summary>
        /// 尝试解析字符串
        /// </summary>
        /// <param name="type">所要解析成的类型</param>
        /// <param name="value">字符串</param>
        /// <param name="result">解析结果，解析失败将返回null</param>
        /// <returns>解析失败将返回具体错误消息，否则将返回null，解析结果通过result获得</returns>
        public static bool TryParse(Type type, string value, out object result)
        {
            if (value == null)
            {
                result = null;

                return false;
            }

            bool succeed = false;
            object parsedValue = null;

            bool isNullable = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);

            if (isNullable)
                type = type.GetGenericArguments()[0];

            if (type.IsEnum)
            {
                try
                {
                    parsedValue = System.Enum.Parse(type, value, true);
                    succeed = true;
                }
                catch
                {

                }
            }
            else if (type == typeof(Guid))
            {
                try
                {
                    parsedValue = new Guid(value);
                    succeed = true;
                }
                catch
                {

                }
            }
            else
            {
                TypeCode typeCode = Type.GetTypeCode(type);

                switch (typeCode)
                {
                    case TypeCode.Object:
                    case TypeCode.String:
                        parsedValue = value;
                        succeed = true;
                        break;
                    case TypeCode.Boolean:
                        {
                            if (value == "1")
                            {
                                parsedValue = true;
                                succeed = true;
                            }
                            else if (value == "0")
                            {
                                parsedValue = false;
                                succeed = true;
                            }
                            else
                            {
                                Boolean temp;
                                succeed = Boolean.TryParse(value, out temp);

                                if (succeed)
                                    parsedValue = temp;
                            }
                        }
                        break;
                    case TypeCode.Byte:
                        {
                            Byte temp;
                            succeed = Byte.TryParse(value, out temp);

                            if (succeed)
                                parsedValue = temp;
                        }
                        break;
                    case TypeCode.Decimal:
                        {
                            Decimal temp;
                            succeed = Decimal.TryParse(value, out temp);

                            if (succeed)
                                parsedValue = temp;
                        }
                        break;
                    case TypeCode.Double:
                        {
                            Double temp;
                            succeed = Double.TryParse(value, out temp);

                            if (succeed)
                                parsedValue = temp;
                        }
                        break;
                    case TypeCode.Int16:
                        {
                            Int16 temp;
                            succeed = Int16.TryParse(value, out temp);

                            if (succeed)
                                parsedValue = temp;
                        }
                        break;
                    case TypeCode.Int32:
                        {
                            Int32 temp;
                            succeed = Int32.TryParse(value, out temp);

                            if (succeed)
                                parsedValue = temp;
                        }
                        break;
                    case TypeCode.Int64:
                        {
                            Int64 temp;
                            succeed = Int64.TryParse(value, out temp);

                            if (succeed)
                                parsedValue = temp;
                        }
                        break;
                    case TypeCode.SByte:
                        {
                            SByte temp;
                            succeed = SByte.TryParse(value, out temp);

                            if (succeed)
                                parsedValue = temp;
                        }
                        break;
                    case TypeCode.Single:
                        {
                            Single temp;
                            succeed = Single.TryParse(value, out temp);

                            if (succeed)
                                parsedValue = temp;
                        }
                        break;
                    case TypeCode.UInt16:
                        {
                            UInt16 temp;
                            succeed = UInt16.TryParse(value, out temp);

                            if (succeed)
                                parsedValue = temp;
                        }
                        break;
                    case TypeCode.UInt32:
                        {
                            UInt32 temp;
                            succeed = UInt32.TryParse(value, out temp);

                            if (succeed)
                                parsedValue = temp;
                        }
                        break;
                    case TypeCode.UInt64:
                        {
                            UInt64 temp;
                            succeed = UInt64.TryParse(value, out temp);

                            if (succeed)
                                parsedValue = temp;
                        }
                        break;
                    case TypeCode.DateTime:
                        {
                            DateTime temp;
                            succeed = DateTime.TryParse(value, out temp);
                            if (succeed)
                            {
                                parsedValue = temp;
                            }
                        }
                        break;
                }
            }

            result = parsedValue;

            return succeed;
        }
        /// <summary>
        /// 获取dynamic类型字段的值
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string GetDynamicValue(dynamic data)
        {
            string result = string.Empty;
            if (data != null)
            {
                // result = data.Value;
                result = data;
            }
            return result;
        }
    }
}
