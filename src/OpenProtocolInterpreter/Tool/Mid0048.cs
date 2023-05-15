using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Tool Pairing status
    /// <para>This message is sent by the controller in order to report the current status of the tool pairing.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0048 : Mid, ITool, IController
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        public const int MID = 48;

        public PairingStatus PairingStatus
        {
            get => (PairingStatus)GetField(1,(int)DataFields.PAIRING_STATUS).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.PAIRING_STATUS).SetValue(_intConverter.Convert, (int)value);
        }
        public DateTime TimeStamp
        {
            get => GetField(1,(int)DataFields.TIMESTAMP).GetValue(_dateConverter.Convert);
            set => GetField(1,(int)DataFields.TIMESTAMP).SetValue(_dateConverter.Convert, value);
        }

        public Mid0048() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0048(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            _dateConverter = new DateConverter();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.PAIRING_STATUS, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TIMESTAMP, 24, 19)
                            }
                }
            };
        }

        protected enum DataFields
        {
            PAIRING_STATUS,
            TIMESTAMP
        }
    }
}
