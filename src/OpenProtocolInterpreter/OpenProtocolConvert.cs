using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OpenProtocolInterpreter
{
#pragma warning disable IDE0060 // Remove unused parameter
    public class OpenProtocolConvert
    {
        private static readonly IFormatProvider _formatProvider = new CultureInfo("en-US");

        public static string ToString(bool value)
            => value ? "1" : "0";

        public static string ToString(char paddingChar, int size, PaddingOrientation orientation, bool value)
            => ToString(value);

        public static bool ToBoolean(string value)
        {
            int intValue = 0;
            if (value != null)
                int.TryParse(value.ToString(), out intValue);

            return Convert.ToBoolean(intValue);
        }

        public static string ToString(DateTime value)
            => value.ToString("yyyy-MM-dd:HH:mm:ss");

        public static string ToString(char paddingChar, int size, PaddingOrientation orientation, DateTime value)
            => ToString(value);

        public static DateTime ToDateTime(string value)
        {
            var convertedValue = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(value.ToString()))
            {
                var date = value.ToString();
                DateTime.TryParse(date.Substring(0, 10) + " " + date.Substring(11, 8), out convertedValue);
            }

            return convertedValue;
        }

        public static string ToString(decimal value)
        {
            return value.ToString("00.0###", _formatProvider);
        }

        public static string ToString(char paddingChar, int size, PaddingOrientation orientation, decimal value)
        {
            var str = ToString(value);
            return TruncatePadded(paddingChar, size, orientation, str);
        }

        public static decimal ToDecimal(string value)
        {
            decimal decimalValue = 0;
            if (!string.IsNullOrWhiteSpace(value))
                decimal.TryParse(value.Replace(',', '.'), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, _formatProvider, out decimalValue);

            return decimalValue;
        }

        public static string TruncatedDecimalToString(decimal value)
        {
            int convertedValue = (int)(Math.Round(value, 2) * 100m);
            return convertedValue.ToString();
        }

        public static string TruncatedDecimalToString(char paddingChar, int size, PaddingOrientation orientation, decimal value)
        {
            var str = TruncatedDecimalToString(value);
            return TruncatePadded(paddingChar, size, orientation, str);
        }

        public static decimal ToTruncatedDecimal(string value)
        {
            int intValue = ToInt32(value);
            return intValue / 100m;
        }

        public static string ToString(int value)
            => value.ToString();

        public static string ToString<TEnum>(TEnum value) where TEnum : struct, Enum
           => ToString(value.GetHashCode());

        public static string ToString(char paddingChar, int size, PaddingOrientation orientation, int value)
            => TruncatePadded(paddingChar, size, orientation, ToString(value));

        public static string ToString<TEnum>(char paddingChar, int size, PaddingOrientation orientation, TEnum value) where TEnum : struct, Enum
            => TruncatePadded(paddingChar, size, orientation, ToString(value));

        public static int ToInt32(string value)
        {
            int.TryParse(value, out int convertedValue);
            return convertedValue;
        }

        public static string ToString(long value)
           => value.ToString();

        public static string ToString(char paddingChar, int size, PaddingOrientation orientation, long value)
            => TruncatePadded(paddingChar, size, orientation, ToString(value));

        public static long ToInt64(string value)
        {
            long.TryParse(value.ToString(), out long convertedValue);
            return convertedValue;
        }

        public static string ToString(IEnumerable<VariableDataField> value)
        {
            var builder = new StringBuilder();
            foreach (var v in value)
            {
                builder.Append(v.Pack());
            }
            return builder.ToString();
        }

        public static bool GetBit(byte b, int bitNumber) => (b & (1 << bitNumber - 1)) != 0;

        public static byte ToByte(bool[] values)
        {
            byte result = 0;
            int index = 9 - values.Length;
            foreach (bool b in values)
            {
                if (b)
                    result |= (byte)(1 << (index - 1));

                index++;
            }

            return result;
        }

        public static string TruncatePadded(char paddingChar, int size, PaddingOrientation orientation, string value)
        {
            if (value == null)
                return string.Empty.PadLeft(size, paddingChar);

            if (size > 0 && value.Length > size)
            {
                value = value.Substring(0, size);
            }

            if (orientation == PaddingOrientation.RightPadded)
                return value.PadRight(size, paddingChar);

            return value.PadLeft(size, paddingChar);
        }
    }
}
