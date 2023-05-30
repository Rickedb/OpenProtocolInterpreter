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
    /// Answer: <see cref="Mid0218"/> Relay function acknowledge
    /// </summary>
    public class Mid0217 : Mid, IIOInterface, IController, IAcknowledgeable<Mid0218>
    {
        public const int MID = 217;

        public RelayNumber RelayNumber
        {
            get => (RelayNumber)GetField(1, (int)DataFields.RelayNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.RelayNumber).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public bool RelayStatus
        {
            get => GetField(1, (int)DataFields.RelayStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, (int)DataFields.RelayStatus).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0217() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0217(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.RelayNumber, 20, 3, '0', PaddingOrientation.LeftPadded),
                        new DataField((int)DataFields.RelayStatus, 25, 1)
                    }
                }
            };
        }

        protected enum DataFields
        {
            RelayNumber,
            RelayStatus
        }
    }
}

