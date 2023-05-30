using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Relay function unsubscribe
    /// <para>
    ///     Unsubscribe for a single relay function. The data field consists of three ASCII digits,
    ///     the relay number, which corresponds to the specific relay function. The relay numbers can be 
    ///     found in Table 101.
    /// </para>    
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, The relay function subscription does not exist</para>
    /// </summary>
    public class Mid0223 : Mid, IIOInterface, IIntegrator, IUnsubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 223;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.RelayFunctionSubscriptionDoesntExists };

        public DigitalInputNumber DigitalInputNumber
        {
            get => (DigitalInputNumber)GetField(1,(int)DataFields.DigitalInputNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.DigitalInputNumber).SetValue(OpenProtocolConvert.ToString, (int)value);
        }

        public Mid0223() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {
            
        }

        public Mid0223(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.DigitalInputNumber, 20, 3, '0', DataField.PaddingOrientations.LeftPadded, false)
                    }
                }
            };
        }

        protected enum DataFields
        {
            DigitalInputNumber
        }
    }
}
