using System.Collections.Generic;

namespace OpenProtocolInterpreter.Converters
{
    public class SocketStatusConverter : AsciiConverter<IEnumerable<bool>>
    {
        private readonly IValueConverter<bool> _boolConverter;

        public SocketStatusConverter(IValueConverter<bool> boolConverter)
        {
            _boolConverter = boolConverter;
        }

        public override IEnumerable<bool> Convert(string value)
        {
            foreach (var c in value)
                yield return _boolConverter.Convert(c.ToString());
        }

        public override string Convert(IEnumerable<bool> value)
        {
            string pack = string.Empty;
            foreach (var v in value)
                pack += _boolConverter.Convert(v);

            return pack;
        }

        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<bool> value) => Convert(value);
    }
}
