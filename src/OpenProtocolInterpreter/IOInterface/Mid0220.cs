using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Digital input function subscribe
    /// <para>
    ///     Subscribe for one single digital input function. The data field consists of three ASCII digits, 
    ///     the digital input function number. The digital input function numbers can be found in Table 80 above.
    ///     At a subscription of a tracking event, <see cref="Mid0221"/> Digital input function upload immediately returns the 
    ///     current digital input function status to the subscriber.
    /// </para>
    /// <para>
    ///     <see cref="Mid0220"/> can only subscribe for one single digital input function at a time, 
    ///     but still, Open Protocol supports keeping several digital input function subscriptions simultaneously.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, The digital input function subscription already exists</para>
    /// </summary>
    public class Mid0220 : Mid, IIOInterface, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 220;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] {  };

        public DigitalInputNumber DigitalInputNumber
        {
            get => (DigitalInputNumber)GetField(1, (int)DataFields.DIGITAL_INPUT_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.DIGITAL_INPUT_NUMBER).SetValue(_intConverter.Convert, (int)value);
        }

        public Mid0220() : this(false)
        {

        }

        public Mid0220(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        public Mid0220(bool noAckFlag = false) : this(new Header()
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
