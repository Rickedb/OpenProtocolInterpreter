using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Set calibration value request
    /// <para>
    ///     This message is sent by the integrator in order to set the calibration value of the tool.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///             <see cref="Communication.Mid0004"/> Command error, Calibration failed
    /// </para>
    /// </summary>
    public class Mid0045 : Mid, ITool, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        private readonly IValueConverter<decimal> _decimalConverter;
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 45;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.CALIBRATION_FAILED };

        public CalibrationUnit CalibrationValueUnit
        {
            get => (CalibrationUnit)GetField(1, (int)DataFields.CALIBRATION_VALUE_UNIT).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.CALIBRATION_VALUE_UNIT).SetValue(_intConverter.Convert, (int)value);
        }
        public decimal CalibrationValue
        {
            get => GetField(1, (int)DataFields.CALIBRATION_VALUE).GetValue(_decimalConverter.Convert);
            set => GetField(1, (int)DataFields.CALIBRATION_VALUE).SetValue(_decimalConverter.Convert, value);
        }
        public int ChannelNumber
        {
            get => GetField(2, (int)DataFields.CHANNEL_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.CHANNEL_NUMBER).SetValue(_intConverter.Convert, value);
        }

        public Mid0045() : this(DEFAULT_REVISION)
        {
        }

        public Mid0045(Header header) : base(header)
        {
            _decimalConverter = new DecimalTrucatedConverter(2);
            _intConverter = new Int32Converter();
        }

        public Mid0045(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.CALIBRATION_VALUE_UNIT, 20, 1),
                                new DataField((int)DataFields.CALIBRATION_VALUE, 23, 6, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                },
                {
                    2, new List<DataField>()
                            {
                                new DataField((int)DataFields.CHANNEL_NUMBER, 31, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                            }
                }
            };
        }

        public enum DataFields
        {
            CALIBRATION_VALUE_UNIT,
            CALIBRATION_VALUE,
            CHANNEL_NUMBER
        }
    }
}
