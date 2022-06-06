using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Relay function
    /// <para>
    ///     Upload of one specific relay function status, see Table 101.
    ///     For tracking event functions, <see cref="Mid0217"/> Relay function, is sent each time the relay status is changed. For
    ///     relay functions which are not tracking events, the upload is sent only when the relay is set high, i.e. the
    ///     data field “Relay function status” will always be 1 for such functions.
    /// </para>
    /// Message sent by: Controller
    /// Answer: MID 0218 Relay function acknowledge
    /// </summary>
    public class Mid0217 : Mid, IIOInterface, IController
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 217;

        public RelayNumber RelayNumber
        {
            get => (RelayNumber)GetField(1, (int)DataFields.RELAY_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.RELAY_NUMBER).SetValue(_intConverter.Convert, (int)value);
        }
        public bool RelayStatus
        {
            get => GetField(1, (int)DataFields.RELAY_STATUS).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.RELAY_STATUS).SetValue(_boolConverter.Convert, value);
        }

        public Mid0217() : this(new Header()
        {
            Mid = MID,
            Revision = LAST_REVISION
        })
        {

        }

        public Mid0217(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="relayNumber">Three ASCII digits corresponding to a relay function</param>
        /// <param name="relayStatus">One ASCII digit representing the relay function status <para>true = Active</para><para>false = Not Active</para></param>
        public Mid0217(RelayNumber relayNumber, bool relayStatus) : this()
        {
            RelayNumber = relayNumber;
            RelayStatus = relayStatus;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.RELAY_NUMBER, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.RELAY_STATUS, 25, 1)
                    }
                }
            };
        }

        public enum DataFields
        {
            RELAY_NUMBER,
            RELAY_STATUS
        }
    }
}

