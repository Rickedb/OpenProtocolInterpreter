using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Relay function
    /// Description: 
    ///     Upload of one specific relay function status, see Table 101.
    ///     For tracking event functions, MID 0217 Relay function, is sent each time the relay status is changed. For
    ///     relay functions which are not tracking events, the upload is sent only when the relay is set high, i.e. the
    ///     data field “Relay function status” will always be 1 for such functions.
    /// Message sent by: Controller
    /// Answer: MID 0218 Relay function acknowledge
    /// </summary>
    public class MID_0217 : Mid, IIOInterface
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 217;

        public RelayNumber RelayNumber
        {
            get => (RelayNumber)GetField(1,(int)DataFields.RELAY_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.RELAY_NUMBER).SetValue(_intConverter.Convert, (int)value);
        }
        public bool RelayStatus
        {
            get => GetField(1,(int)DataFields.RELAY_STATUS).GetValue(_boolConverter.Convert);
            set => GetField(1,(int)DataFields.RELAY_STATUS).SetValue(_boolConverter.Convert, value);
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="ackFlag">0=Ack needed, 1=No Ack needed</param>
        public MID_0217(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag)
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="relayNumber">Three ASCII digits corresponding to a relay function</param>
        /// <param name="relayStatus">One ASCII digit representing the relay function status <para>true = Active</para><para>false = Not Active</para></param>
        /// <param name="ackFlag">0=Ack needed, 1=No Ack needed</param>
        public MID_0217(RelayNumber relayNumber, bool relayStatus, int? noAckFlag = 0) : this(noAckFlag)
        {
            RelayNumber = relayNumber;
            RelayStatus = relayStatus;
        }

        internal MID_0217(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

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

