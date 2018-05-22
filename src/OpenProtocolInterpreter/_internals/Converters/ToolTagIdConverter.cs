using System;
using System.Collections.Generic;
using System.Globalization;

namespace OpenProtocolInterpreter.Converters
{
    internal class ToolTagIdConverter : IValueConverter<string>
    {
        public string Convert(string value)
        {
            List<int> values = new List<int>();
            for (int i = 0; i < value.Length; i += 2)
                values.Add(int.Parse(value.Substring(i, 2), NumberStyles.HexNumber));

            return string.Join("-", values);
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, string value)
        {
            throw new NotImplementedException();
        }
    }
}
