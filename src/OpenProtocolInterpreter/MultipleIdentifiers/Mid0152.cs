using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// Multiple identifier and result parts
    /// <para>
    ///    Transmission of the work order status, optional identifier and identifier result parts
    ///    by the controller to the subscriber.
    /// </para>
    /// <para>
    ///    The identifier contains the status of the maximum four identifier result parts that could 
    ///    be extracted from one or more valid identifiers.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0153"/> Multiple identifiers and result parts acknowledge</para>
    /// </summary>
    public class Mid0152 : Mid, IMultipleIdentifier, IController, IAcknowledgeable<Mid0153>
    {
        private readonly IValueConverter<IdentifierStatus> _identifierStatusConverter;
        public const int MID = 152;

        public IdentifierStatus FirstIdentifierStatus { get; set; }
        public IdentifierStatus SecondIdentifierStatus { get; set; }
        public IdentifierStatus ThirdIdentifierStatus { get; set; }
        public IdentifierStatus FourthIdentifierStatus { get; set; }

        public Mid0152() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0152(Header header) : base(header)
        {
            _identifierStatusConverter = new IdentifierStatusConverter(new Int32Converter(), new BoolConverter());
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.FIRST_IDENTIFIER_STATUS).Value = _identifierStatusConverter.Convert(FirstIdentifierStatus);
            GetField(1, (int)DataFields.SECOND_IDENTIFIER_STATUS).Value = _identifierStatusConverter.Convert(SecondIdentifierStatus);
            GetField(1, (int)DataFields.THIRD_IDENTIFIER_STATUS).Value = _identifierStatusConverter.Convert(ThirdIdentifierStatus);
            GetField(1, (int)DataFields.FOURTH_IDENTIFIER_STATUS).Value = _identifierStatusConverter.Convert(FourthIdentifierStatus);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            base.Parse(package);

            FirstIdentifierStatus = _identifierStatusConverter.Convert(GetField(1, (int)DataFields.FIRST_IDENTIFIER_STATUS).Value);
            SecondIdentifierStatus = _identifierStatusConverter.Convert(GetField(1, (int)DataFields.SECOND_IDENTIFIER_STATUS).Value);
            ThirdIdentifierStatus = _identifierStatusConverter.Convert(GetField(1, (int)DataFields.THIRD_IDENTIFIER_STATUS).Value);
            FourthIdentifierStatus = _identifierStatusConverter.Convert(GetField(1, (int)DataFields.FOURTH_IDENTIFIER_STATUS).Value);

            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.FIRST_IDENTIFIER_STATUS, 20, 30),
                                new DataField((int)DataFields.SECOND_IDENTIFIER_STATUS, 52, 30),
                                new DataField((int)DataFields.THIRD_IDENTIFIER_STATUS, 84, 30),
                                new DataField((int)DataFields.FOURTH_IDENTIFIER_STATUS, 116, 30)
                            }
                }
            };
        }

        protected enum DataFields
        {
            FIRST_IDENTIFIER_STATUS,
            SECOND_IDENTIFIER_STATUS,
            THIRD_IDENTIFIER_STATUS,
            FOURTH_IDENTIFIER_STATUS
        }
    }
}
