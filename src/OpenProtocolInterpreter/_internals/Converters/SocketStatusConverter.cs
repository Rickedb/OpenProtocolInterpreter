using System.Collections.Generic;

namespace OpenProtocolInterpreter.Converters
{
    internal class SocketStatusConverter : IValueConverter<IEnumerable<bool>>
    {
        private readonly IValueConverter<bool> _boolConverter;

        public SocketStatusConverter(IValueConverter<bool> boolConverter)
        {
            _boolConverter = boolConverter;
        }

        public IEnumerable<bool> Convert(string value)
        {
            foreach (var c in value)
                yield return _boolConverter.Convert(c.ToString());
        }

        public string Convert(IEnumerable<bool> value)
        {
            string pack = string.Empty;
            foreach (var v in value)
                pack += _boolConverter.Convert(v);

            return pack;
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<bool> value) => Convert(value);
    }
}
