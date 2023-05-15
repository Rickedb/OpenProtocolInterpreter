using OpenProtocolInterpreter.Converters;
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
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 223;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.RELAY_FUNCTION_SUBSCRIPTION_DOESNT_EXISTS };

        public DigitalInputNumber DigitalInputNumber
        {
            get => (DigitalInputNumber)GetField(1,(int)DataFields.DIGITAL_INPUT_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.DIGITAL_INPUT_NUMBER).SetValue(_intConverter.Convert, (int)value);
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
            _intConverter = new Int32Converter();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.DIGITAL_INPUT_NUMBER, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                    }
                }
            };
        }

        public enum DataFields
        {
            DIGITAL_INPUT_NUMBER
        }
    }
}
