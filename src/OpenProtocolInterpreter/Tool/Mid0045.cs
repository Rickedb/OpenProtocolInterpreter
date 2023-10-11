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
        public const int MID = 45;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.CalibrationFailed };

        public CalibrationUnit CalibrationValueUnit
        {
            get => (CalibrationUnit)GetField(1, (int)DataFields.CalibrationValueUnit).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.CalibrationValueUnit).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public decimal CalibrationValue
        {
            get => GetField(1, (int)DataFields.CalibrationValue).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1, (int)DataFields.CalibrationValue).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public int ChannelNumber
        {
            get => GetField(2, (int)DataFields.ChannelNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.ChannelNumber).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0045() : this(DEFAULT_REVISION)
        {
        }

        public Mid0045(Header header) : base(header)
        {
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
                                new((int)DataFields.CalibrationValueUnit, 20, 1),
                                new((int)DataFields.CalibrationValue, 23, 6, '0', PaddingOrientation.LeftPadded)
                            }
                },
                {
                    2, new List<DataField>()
                            {
                                new((int)DataFields.ChannelNumber, 31, 2, '0', PaddingOrientation.LeftPadded),
                            }
                }
            };
        }

        protected enum DataFields
        {
            CalibrationValueUnit,
            CalibrationValue,
            ChannelNumber
        }
    }
}
