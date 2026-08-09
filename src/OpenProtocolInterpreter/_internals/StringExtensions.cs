using System;

namespace OpenProtocolInterpreter
{
    public static class StringExtensions
    {
        public static string TruncatePadded(this string value, char paddingChar, int size, PaddingOrientation orientation)
            => OpenProtocolConvert.TruncatePadded(paddingChar, size, orientation, value.AsSpan());

        internal static string SafePadRight(this string value, int length)
            => SafePadRight(value, length, ' ');

        internal static string SafePadRight(this string value, int length, char character)
        {
            if(string.IsNullOrEmpty(value))
            {
                value = string.Empty;
            }

            return value.PadRight(length, character);
        }

        internal static string SafeSubstring(this string value, int startIndex, int length)
            => SafeSubstring(value.AsSpan(), startIndex, length);

        internal static string SafeSubstring(this ReadOnlySpan<char> value, int startIndex, int length)
        {
            if (value.IsEmpty)
                return string.Empty;

            if (value.Length < startIndex + length)
                return startIndex < value.Length ? value.Slice(startIndex).ToString() : string.Empty;

            return value.Slice(startIndex, length).ToString();
        }
    }
}
