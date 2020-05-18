using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Relay function subscribe
    /// <para>
    ///     Subscribe for one single relay function. The data field consists of three ASCII digits, the relay number,
    ///     which corresponds to the specific relay function.The relay numbers can be found in Table 101 above.
    ///     At a subscription of a tracking event, <see cref="Mid0217"/> Relay function immediately returns the current relay
    ///     status to the subscriber.
    ///     <see cref="Mid0216"/> can only subscribe for one single relay function at a time, but still, Open Protocol supports
    ///     keeping several relay function subscriptions simultaneously.
    /// </para>    
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, The relay function subscription already exists</para>
    /// </summary>
    public class Mid0216 : Mid, IIOInterface, IIntegrator
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 216;

        public RelayNumber RelayNumber
        {
            get => (RelayNumber)GetField(1,(int)DataFields.RELAY_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.RELAY_NUMBER).SetValue(_intConverter.Convert, (int)value);
        }

        public Mid0216() : this(0)
        {

        }

        public Mid0216(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag)
        {
            _intConverter = new Int32Converter();
        }

        public Mid0216(RelayNumber relayNumber, int? noAckFlag = 0) : this(noAckFlag)
        {
            RelayNumber = relayNumber;
        }

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
