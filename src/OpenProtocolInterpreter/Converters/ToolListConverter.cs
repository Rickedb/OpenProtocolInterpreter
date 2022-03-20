﻿using OpenProtocolInterpreter.Tool;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Converters
{
    public class ToolListConverter : AsciiConverter<IEnumerable<ToolData>>
    {
        private readonly IValueConverter<int> _intConverter;

        public ToolListConverter(IValueConverter<int> intConverter)
        {
            _intConverter = intConverter;
        }

        public override IEnumerable<ToolData> Convert(string value)
        {
            for (int i = 0; i < value.Length; i += 94)
            {
                yield return new ToolData()
                {
                    Number = _intConverter.Convert(value.Substring(i, 4)),
                    SerialNumber = value.Substring(i + 4, 30),
                    ModelName = value.Substring(i + 34, 30),
                    ModelArticleNumber = value.Substring(i + 64, 30)
                };
            }
        }

        public override string Convert(IEnumerable<ToolData> value)
        {
            string pack = string.Empty;
            foreach (var tool in value)
            {
                pack += _intConverter.Convert('0', 4, DataField.PaddingOrientations.LEFT_PADDED, tool.Number) + 
                        GetPadded(' ', 30, DataField.PaddingOrientations.RIGHT_PADDED, tool.SerialNumber) +
                        GetPadded(' ', 30, DataField.PaddingOrientations.RIGHT_PADDED, tool.ModelName) +
                        GetPadded(' ', 30, DataField.PaddingOrientations.RIGHT_PADDED, tool.ModelArticleNumber);
            }

            return pack;
        }

        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<ToolData> value) => Convert(value);
    }
}
