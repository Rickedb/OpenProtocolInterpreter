using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Relay function subscribe
    /// Description: 
    ///     Subscribe for one single relay function. The data field consists of three ASCII digits, the relay number,
    ///     which corresponds to the specific relay function.The relay numbers can be found in Table 101 above.
    ///     At a subscription of a tracking event, MID 0217 Relay function immediately returns the current relay
    ///     status to the subscriber.
    ///     MID 0216 can only subscribe for one single relay function at a time, but still, Open Protocol supports
    ///     keeping several relay function subscriptions simultaneously.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    ///         MID 0004 Command error, The relay function subscription already exists
    /// </summary>
    public class MID_0216 : Mid, IIOInterface
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 216;

        public RelayNumber RelayNumber
        {
            get => (RelayNumber)RevisionsByFields[1][(int)DataFields.RELAY_NUMBER].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.RELAY_NUMBER].SetValue(_intConverter.Convert, (int)value);
        }

        public MID_0216(int? ackFlag = 1) : base(MID, LAST_REVISION, ackFlag)
        {
            _intConverter = new Int32Converter();
        }

        public MID_0216(RelayNumber relayNumber, int? ackFlag = 1) : this(ackFlag)
        {
            RelayNumber = relayNumber;
        }

        internal MID_0216(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.RELAY_NUMBER, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                    }
                }
            };
        }

        public enum DataFields
        {
            RELAY_NUMBER
        }
    }
}
