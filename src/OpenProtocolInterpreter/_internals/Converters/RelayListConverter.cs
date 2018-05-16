using OpenProtocolInterpreter.IOInterface;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Converters
{
    internal class RelayListConverter : IValueConverter<IEnumerable<Relay>>
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;

        public RelayListConverter()
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
        }

        public IEnumerable<Relay> Convert(string value)
        {
            for (int i = 0; i < value.Length; i += 4)
                yield return new Relay()
                {
                    Number = (RelayNumber)_intConverter.Convert(value.Substring(i, i + 3)),
                    Status = _boolConverter.Convert(value.Substring(i + 3, 1))
                };
        }

        public string Convert(IEnumerable<Relay> value)
        {
            string pack = string.Empty;
            foreach(var relay in value)
                pack += _intConverter.Convert('0', 3, DataField.PaddingOrientations.LEFT_PADDED, (int)relay.Number) + _boolConverter.Convert(relay.Status);

            return pack;
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<Relay> value) => Convert(value);
    }
}
