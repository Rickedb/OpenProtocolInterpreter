using System.Collections.Generic;

namespace OpenProtocolInterpreter.Converters
{
    public class JobIdListConverter : AsciiConverter<IEnumerable<int>>
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly int _jobSize;

        public JobIdListConverter(IValueConverter<int> intConverter, int revision)
        {
            _intConverter = intConverter;
            _jobSize = revision > 1 ? 4 : 2;
        }

        public override IEnumerable<int> Convert(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                yield break;
            }

            for (int i = 0; i < value.Length; i+= _jobSize)
                yield return _intConverter.Convert(value.Substring(i, _jobSize));
        }

        public override string Convert(IEnumerable<int> value)
        {
            string pack = string.Empty;
            foreach (var v in value)
                pack += _intConverter.Convert('0', _jobSize, DataField.PaddingOrientations.LeftPadded, v);

            return pack;
        }

        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<int> value) => Convert(value);
    }
}
