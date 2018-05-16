using System.Collections.Generic;

namespace OpenProtocolInterpreter.Converters
{
    public class LightCommandListConverter : IValueConverter<IEnumerable<LightCommand>> 
    {
        private readonly IValueConverter<int> _intConverter;

        public LightCommandListConverter()
        {
            _intConverter = new Int32Converter();
        }

        public IEnumerable<LightCommand> Convert(string value)
        {
            foreach (var c in value)
                yield return (LightCommand)_intConverter.Convert(c.ToString());
        }

        public string Convert(IEnumerable<LightCommand> value)
        {
            string pack = string.Empty;
            foreach (var e in value)
                pack += _intConverter.Convert((int)e);

            return pack;
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<LightCommand> value) => Convert(value);
    }
}
