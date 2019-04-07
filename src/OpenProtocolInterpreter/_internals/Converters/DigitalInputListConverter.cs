using OpenProtocolInterpreter.IOInterface;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Converters
{
    internal class DigitalInputListConverter : AsciiConverter<IEnumerable<DigitalInput>>
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;

        public DigitalInputListConverter(IValueConverter<int> intConverter, IValueConverter<bool> boolConverter)
        {
            _intConverter = intConverter;
            _boolConverter = boolConverter;
        }

        public override IEnumerable<DigitalInput> Convert(string value)
        {
            for (int i = 0; i < value.Length; i += 4)
                yield return new DigitalInput()
                {
                    Number = (DigitalInputNumber)_intConverter.Convert(value.Substring(i, 3)),
                    Status = _boolConverter.Convert(value.Substring(i + 3, 1))
                };
        }

        public override string Convert(IEnumerable<DigitalInput> value)
        {
            string pack = string.Empty;
            foreach (var digitalInput in value)
                pack += _intConverter.Convert('0', 3, DataField.PaddingOrientations.LEFT_PADDED, (int)digitalInput.Number) + _boolConverter.Convert(digitalInput.Status);

            return pack;
        }

        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<DigitalInput> value) => Convert(value);
    }
}
