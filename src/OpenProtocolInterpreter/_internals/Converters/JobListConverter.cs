using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.Converters
{
    internal class JobListConverter : IValueConverter<IEnumerable<int>>
    {
        private readonly IValueConverter<int> _intConverter;
        public int TotalJobs { get; set; }
        public int EachJobSize { get; set; }

        public JobListConverter(IValueConverter<int> intConverter)
        {
            _intConverter = intConverter;
        }

        public IEnumerable<int> Convert(string value)
        {
            int index = 0;
            for (int i = 0; i < TotalJobs; i++)
            {
                index = i * EachJobSize;
                yield return _intConverter.Convert(value.Substring(index, EachJobSize));
            }
        }

        public string Convert(IEnumerable<int> value)
        {
            string pack = string.Empty;
            foreach (var v in value)
                pack += _intConverter.Convert('0', EachJobSize, DataField.PaddingOrientations.LEFT_PADDED, v);

            return pack;
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<int> value)
        {
            return Convert(value);
        }
    }
}
