/// <summary>
/// Created by İsmail Sarikaya in 2012.
/// Converted to .Net Standard in 2020.
/// https://ismail-sarikaya.com
/// https://github.com/ismsrky
/// https://stackoverflow.com/users/14562535
/// </summary>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSharpExtensions
{
    public static class Extensions
    {
        #region < Is.. >
        /// <summary>
        /// Returns if given value is null. Also checks dbnull.
        /// </summary>
        /// <param name="value">The value to be used.</param>
        /// <returns>bool</returns>
        public static bool IsNull(this object value)
        {
            if (value == DBNull.Value || value == null || (value.GetType() == typeof(string) && (string.IsNullOrEmpty(value.ToString()) || string.IsNullOrWhiteSpace(value.ToString()))))
                return true;
            return false;
        }

        /// <summary>
        /// Returns if given value is not null. Also checks dbnull.
        /// </summary>
        /// <param name="value">The value to be used.</param>
        /// <returns>bool</returns>
        public static bool IsNotNull(this object value)
        {
            return !IsNull(value);
        }

        /// <summary>
        /// Returns if the value is integer.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns>bool</returns>
        public static bool IsInteger(this object value)
        {
            if (IsNull(value)) return false;
            return Regex.IsMatch(value.ToString(), "^\\d+$");
        }

        /// <summary>
        /// Returns if the value is integer or  decimal.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns>bool</returns>
        public static bool IsIntegerOrDecimal(this object value)
        {
            if (IsNull(value)) return false;

            if (IsInteger(value))
            {
                return true;
            }

            decimal decValue;
            return decimal.TryParse(value.ToString(), out decValue);
        }

        /// <summary>
        /// Returns if the given value is list.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns>bool</returns>
        public static bool IsList(this object value)
        {
            if (value == null) return false;
            return value is IList &&
                   value.GetType().IsGenericType &&
                   value.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        }

        /// <summary>
        /// Returns if the given value is dictionary.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns>bool</returns>
        public static bool IsDictionary(this object value)
        {
            if (value == null) return false;
            return value is IDictionary &&
                   value.GetType().IsGenericType &&
                   value.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(Dictionary<,>));
        }

        /// <summary>
        /// Returns if the given value is guid.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns>bool</returns>
        public static bool IsGuid(this object value)
        {
            if (value.IsNull()) return false;
            Guid guidValue;
            return Guid.TryParse(value.ToString(), out guidValue);
        }
        #endregion

        #region < To.. >
        /// <summary>
        /// Converts the given value to Int16.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Int16</returns>
        public static short ToInt16(this object value)
        {
            return Convert.ToInt16(value);
        }

        /// <summary>
        /// Converts the given value to Int32.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Int32</returns>
        public static int ToInt32(this object value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// Converts the given value to Int64.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Int64</returns>
        public static long ToInt64(this object value)
        {
            return Convert.ToInt64(value);
        }

        /// <summary>
        /// Converts the given value to Decimal.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Decimal</returns>
        public static decimal ToDecimal(this object value)
        {
            return Convert.ToDecimal(value);
        }

        /// <summary>
        /// Converts the given value to Byte.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Byte</returns>
        public static byte ToByte(this object value)
        {
            return Convert.ToByte(value);
        }

        /// <summary>
        /// Converts the given value to ByteArray.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>ByteArray</returns>
        public static byte[] ToByteArray(this object value)
        {
            return (byte[])value;
        }

        /// <summary>
        /// Converts the given value to DateTime.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDateTime(this object value)
        {
            return Convert.ToDateTime(value);
        }

        /// <summary>
        /// Converts the given value as unix time to DateTime.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDateTimeFromNumber(this double value)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds(value);
        }

        /// <summary>
        /// Converts the given value as DateTime to unix time.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Unix time</returns>
        public static double ToNumberFromDateTime(this DateTime value)
        {
            return value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        /// <summary>
        /// Converts the given value to bool.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Bool</returns>
        public static bool ToBool(this object value)
        {
            return Convert.ToBoolean(value);
        }

        /// <summary>
        /// Converts the given value to Guid.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Guid</returns>
        public static Guid ToGuid(this object value)
        {
            return new Guid(value.ToString());
        }


        /// <summary>
        /// Converts the given value to String. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Nullable String</returns>
        public static string ToStringNull(this object value)
        {
            if (value.IsNull()) return null;
            return value.ToString();
        }

        /// <summary>
        /// Converts the given value to Int16. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Nullable Int16</returns>
        public static short? ToInt16Null(this object value)
        {
            if (value.IsNull()) return null;
            return Convert.ToInt16(value);
        }

        /// <summary>
        /// Converts the given value to Int32. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Nullable Int32</returns>
        public static int? ToInt32Null(this object value)
        {
            if (value.IsNull()) return null;
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// Converts the given value to Int64. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Nullable Int64</returns>
        public static long? ToInt64Null(this object value)
        {
            if (value.IsNull()) return null;
            return Convert.ToInt64(value);
        }

        /// <summary>
        /// Converts the given value to Decimal. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Nullable Decimal</returns>
        public static decimal? ToDecimalNull(this object value)
        {
            if (value.IsNull()) return null;
            return Convert.ToDecimal(value);
        }

        /// <summary>
        /// Converts the given value to Byte. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Nullable Byte</returns>
        public static byte? ToByteNull(this object value)
        {
            if (value.IsNull()) return null;
            return Convert.ToByte(value);
        }

        /// <summary>
        /// Converts the given value to ByteArray. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Nullable ByteArray</returns>
        public static byte[] ToByteArrayNull(this object value)
        {
            if (value.IsNull()) return null;
            return (byte[])value;
        }

        /// <summary>
        /// Converts the given value to DateTime. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Nullable DateTime</returns>
        public static DateTime? ToDateTimeNull(this object value)
        {
            if (value.IsNull()) return null;
            return Convert.ToDateTime(value);
        }

        /// <summary>
        /// Converts the given value as unix time to DateTime. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Nullable DateTime</returns>
        public static DateTime? ToDateTimeFromNumberNull(this double? value)
        {
            if (value.IsNull()) return null;
            return new DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds(value.Value);
        }

        /// <summary>
        /// Converts the given value as DateTime to unix time. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Nullable Double</returns>
        public static double? ToNumberFromDateTimeNull(this DateTime? value)
        {
            if (value.IsNull()) return null;
            return value.Value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        /// <summary>
        /// Converts the given value to Bool. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Nullable Bool</returns>
        public static bool? ToBoolNull(this object value)
        {
            if (value.IsNull()) return null;
            return Convert.ToBoolean(value);
        }

        /// <summary>
        /// Converts the given value to Guid. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Nullable Guid</returns>
        public static Guid? ToGuidNull(this object value)
        {
            if (value.IsNull()) return null;
            return new Guid(value.ToString());
        }

        /// <summary>
        /// Returns separated string by delimiter of elements of from given list. Returns null if value is null.
        /// </summary>
        /// <typeparam name="T">Generic</typeparam>
        /// <param name="value"></param>
        /// <param name="delimiter">The delimiter that will be used while separating.</param>
        /// <returns></returns>
        public static string ToStrSeparated<T>(this List<T> value, string delimiter)
        {
            if (value == null || value.Count == 0)
            {
                return null;
            }
            string sonuc = "";
            Type type = null;
            foreach (object item in value)
            {
                type = item.GetType();
                if (type.IsEnum)
                {
                    sonuc += ((int)item).ToString() + delimiter;
                }
                else
                {
                    sonuc += item.ToString() + delimiter;
                }
            }
            sonuc = sonuc.Substring(0, sonuc.Length - 1);
            return sonuc;
        }

        /// <summary>
        /// Converts given hex value decimal array. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Byte Array</returns>
        public static byte[] ToByteFromHex(this string value)
        {
            if (value.IsNull()) return null;

            string[] value_arr = value.Split('-');
            byte[] result = new byte[value_arr.Length];
            for (int i = 0; i < value_arr.Length; i++)
            {
                result[i] = byte.Parse(value_arr[i], System.Globalization.NumberStyles.HexNumber);
            }
            return result;
        }

        /// <summary>
        /// Converts given string to first letter to upper and others to lower. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="culture">The culture to be used while converting.</param>
        /// <returns>String</returns>
        public static string ToTitleCase(this string value, string culture = "tr-TR")
        {
            if (value.IsNull()) return null;

            value = value.Trim();
            if (value.Length > 0)
            {
                System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(culture);
                System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;
                value = textInfo.ToLower(value);
                value = textInfo.ToTitleCase(value);
            }

            return value;
        }

        /// <summary>
        /// Converts given value to Md5. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>String</returns>
        public static string ToMd5(this string value)
        {
            if (value.IsNull()) return null;

            System.Security.Cryptography.MD5 MD5Pass = System.Security.Cryptography.MD5.Create();
            byte[] MD5Buff = MD5Pass.ComputeHash(System.Text.Encoding.GetEncoding(1254).GetBytes(value));
            return BitConverter.ToString(MD5Buff).Replace("-", string.Empty);
        }

        /// <summary>
        /// Converts given string to upper. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="culture">The culture to be used while converting.</param>
        /// <returns>String</returns>
        public static string ToUpperNull(this string value, CultureInfo culture = null)
        {
            if (value.IsNull()) return null;

            if (culture == null)
                return value.ToUpper();
            else
                return value.ToUpper(culture);
        }

        /// <summary>
        /// Converts given string to lower. Returns null if value is null.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="culture">The culture to be used while converting.</param>
        /// <returns>String</returns>
        public static string ToLowerNull(this string value, CultureInfo culture = null)
        {
            if (value.IsNull()) return null;

            if (culture == null)
                return value.ToLower();
            else
                return value.ToLower(culture);
        }

        /// <summary>
        /// Converts the given byte array to string separated by '-'.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <returns>String</returns>
        public static string ToHexWithSeparator(this byte[] value)
        {
            return string.Join("-", value.Select(x => x.ToString("X")).ToArray());
        }
        #endregion
    }
}