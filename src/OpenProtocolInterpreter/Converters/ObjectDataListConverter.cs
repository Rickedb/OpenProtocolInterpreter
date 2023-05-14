using OpenProtocolInterpreter.Result;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Converters
{
    public class ObjectDataListConverter : AsciiConverter<IEnumerable<ObjectData>>
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;

        public ObjectDataListConverter(IValueConverter<int> intConverter, IValueConverter<bool> boolConverter)
        {
            _intConverter = intConverter;
            _boolConverter = boolConverter;
        }

        public override IEnumerable<ObjectData> Convert(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                yield break;
            }

            for (int i = 0; i < value.Length; i += 5)
                yield return new ObjectData()
                {
                    Id = _intConverter.Convert(value.Substring(i, 4)),
                    Status = _boolConverter.Convert(value.Substring(i + 4, 1))
                };
        }

        public override string Convert(IEnumerable<ObjectData> value)
        {
            string pack = string.Empty;
            foreach(var v in value)
            {
                pack += _intConverter.Convert('0', 4, DataField.PaddingOrientations.LEFT_PADDED, v.Id);
                pack += _boolConverter.Convert(v.Status);
            }

            return pack;
        }

        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<ObjectData> value) => Convert(value);
    }
}
