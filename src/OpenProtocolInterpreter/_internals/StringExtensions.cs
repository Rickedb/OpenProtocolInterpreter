namespace OpenProtocolInterpreter
{
    public static class StringExtensions
    {
        public static string TruncatePadded(this string value, char paddingChar, int size, DataField.PaddingOrientations orientation)
        {
            if (value == null)
                return string.Empty.PadLeft(size, paddingChar);

            if (size > 0 && value.Length > size)
            {
                value = value.Substring(0, size);
            }

            if (orientation == DataField.PaddingOrientations.RightPadded)
                return value.PadRight(size, paddingChar);

            return value.PadLeft(size, paddingChar);
        }

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
        {
            if(string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            if (value.Length < startIndex + length)
            {
                return value.Substring(startIndex, value.Length - startIndex);
            }

            return value.Substring(startIndex, length);
        }
    }
}
