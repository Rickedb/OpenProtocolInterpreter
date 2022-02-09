namespace OpenProtocolInterpreter.Emulator.AutomaticControllers
{
    internal static class GridExtensions
    {
        public static string GetString(this DataGridViewCellCollection collection, string columnName)
        {
            var value = collection[columnName].Value;
            return GetString(value);
        }
        public static string GetString(this DataGridViewCellCollection collection, int columnIndex)
        {
            var value = collection[columnIndex].Value;
            return GetString(value);
        }

        public static int GetInt(this DataGridViewCellCollection collection, string columnName)
        {
            var value = collection.GetString(columnName);
            return int.Parse(value);
        }

        public static int GetInt(this DataGridViewCellCollection collection, int columnIndex)
        {
            var value = collection.GetString(columnIndex);
            return int.Parse(value);
        }

        public static TEnum GetEnum<TEnum>(this DataGridViewCellCollection collection, string columnName) where TEnum : struct
        {
            var value = collection.GetString(columnName);
            return Enum.Parse<TEnum>(value);
        }

        public static TEnum GetEnum<TEnum>(this DataGridViewCellCollection collection, int columnIndex) where TEnum : struct
        {
            var value = collection.GetString(columnIndex);
            return Enum.Parse<TEnum>(value);
        }

        public static bool GetBool(this DataGridViewCellCollection collection, string columnName)
        {
            var value = collection[columnName].Value;
            if(value is bool b)
            {
                return b;
            }

            return false;
        }

        public static bool GetBool(this DataGridViewCellCollection collection, int columnIndex)
        {
            var value = collection[columnIndex].Value;
            if (value is bool b)
            {
                return b;
            }

            return false;
        }

        private static string GetString(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            if (value is string str)
            {
                return str;
            }

            return value.ToString();
        }
    }
}
