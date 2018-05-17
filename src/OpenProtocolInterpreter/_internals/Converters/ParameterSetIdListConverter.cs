using System.Collections.Generic;

namespace OpenProtocolInterpreter.Converters
{
    internal class ParameterSetIdListConverter : IValueConverter<IEnumerable<int>>
    {
        private readonly IValueConverter<int> _intConverter;

        public ParameterSetIdListConverter()
        {
            _intConverter = new Int32Converter();
        }

        public IEnumerable<int> Convert(string value)
        {
            for (int i = 0; i < value.Length; i += 3)
                yield return _intConverter.Convert(value.Substring(i, 3));
        }

        public string Convert(IEnumerable<int> value)
        {
            string pack = string.Empty;
            foreach (var v in value)
                pack += _intConverter.Convert('0', 3, DataField.PaddingOrientations.LEFT_PADDED, v);
            return pack;
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<int> value) => Convert(value);
    }
}
