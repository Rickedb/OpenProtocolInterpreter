﻿using OpenProtocolInterpreter.PowerMACS;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Converters
{
    public class BoltDataListConverter : AsciiConverter<IEnumerable<BoltData>>
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<decimal> _decimalConverter;
        private readonly int _totalBolts;

        public BoltDataListConverter(IValueConverter<int> intConverter, IValueConverter<bool> boolConverter, IValueConverter<decimal> decimalConverter, int totalBolts)
        {
            _intConverter = intConverter;
            _boolConverter = boolConverter;
            _decimalConverter = decimalConverter;
            _totalBolts = totalBolts;
        }

        public override IEnumerable<BoltData> Convert(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                yield break;
            }

            List<string> bolts = new List<string>();
            for (int i = 0; i < _totalBolts; i++)
                bolts.Add(value.Substring(i * 67, 67));

            foreach (var bolt in bolts)
                yield return new BoltData()
                {
                    OrdinalBoltNumber = _intConverter.Convert(bolt.Substring(2, 2)),
                    SimpleBoltStatus = _boolConverter.Convert(bolt.Substring(6, 1)),
                    TorqueStatus = (TorqueStatus)_intConverter.Convert(bolt.Substring(9, 1)),
                    AngleStatus = (AngleStatus)_intConverter.Convert(bolt.Substring(12, 1)),
                    BoltTorque = _decimalConverter.Convert(bolt.Substring(15, 7)),
                    BoltAngle = _decimalConverter.Convert(bolt.Substring(24, 7)),
                    BoltTorqueHighLimit = _decimalConverter.Convert(bolt.Substring(33, 7)),
                    BoltTorqueLowLimit = _decimalConverter.Convert(bolt.Substring(42, 7)),
                    BoltAngleHighLimit = _decimalConverter.Convert(bolt.Substring(51, 7)),
                    BoltAngleLowLimit = _decimalConverter.Convert(bolt.Substring(60, 7)),
                };
        }

        public override string Convert(IEnumerable<BoltData> value)
        {
            string package = string.Empty;
            foreach(var bolt in value)
            {
                package += $"13{_intConverter.Convert('0', 2, DataField.PaddingOrientations.LeftPadded, bolt.OrdinalBoltNumber)}";
                package += $"14{_boolConverter.Convert(bolt.SimpleBoltStatus)}";
                package += $"15{_intConverter.Convert((int)bolt.TorqueStatus)}";
                package += $"16{_intConverter.Convert((int)bolt.AngleStatus)}";
                package += $"17{_decimalConverter.Convert('0', 7, DataField.PaddingOrientations.RightPadded, bolt.BoltTorque)}";
                package += $"18{_decimalConverter.Convert('0', 7, DataField.PaddingOrientations.RightPadded, bolt.BoltAngle)}";
                package += $"19{_decimalConverter.Convert('0', 7, DataField.PaddingOrientations.RightPadded, bolt.BoltTorqueHighLimit)}";
                package += $"20{_decimalConverter.Convert('0', 7, DataField.PaddingOrientations.RightPadded, bolt.BoltTorqueLowLimit)}";
                package += $"21{_decimalConverter.Convert('0', 7, DataField.PaddingOrientations.RightPadded, bolt.BoltAngleHighLimit)}";
                package += $"22{_decimalConverter.Convert('0', 7, DataField.PaddingOrientations.RightPadded, bolt.BoltAngleLowLimit)}";
            }

            return package;
        }

        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<BoltData> value) => Convert(value);
    }
}
