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
    public class Mid0216 : Mid, IIOInterface, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 216;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.RelayFunctionSubscriptionAlreadyExists };

        public RelayNumber RelayNumber
        {
            get => (RelayNumber)GetField(1,(int)DataFields.RelayNumber).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.RelayNumber).SetValue(_intConverter.Convert, (int)value);
        }

        public Mid0216() : this(false)
        {

        }

        public Mid0216(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        public Mid0216(bool noAckFlag = false) : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION,
            NoAckFlag = noAckFlag
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
                        new DataField((int)DataFields.RelayNumber, 20, 3, '0', DataField.PaddingOrientations.LeftPadded, false)
                    }
                }
            };
        }

        protected enum DataFields
        {
            RelayNumber
        }
    }
}
