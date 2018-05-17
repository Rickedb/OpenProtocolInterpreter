using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: Multiple identifier and result parts
    /// Description: 
    ///    Transmission of the work order status, optional identifier and identifier result parts
    ///    by the controller to the subscriber.
    ///    
    ///    The identifier contains the status of the maximum four identifier result parts that could 
    ///    be extracted from one or more valid identifiers.
    /// Message sent by: Controller
    /// Answer: MID 0153 Multiple identifiers and result parts acknowledge
    /// </summary>
    public class MID_0152 : Mid, IMultipleIdentifier
    {
        private readonly IValueConverter<IdentifierStatus> _identifierStatusConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 152;

        public IdentifierStatus FirstIdentifierStatus { get; set; }
        public IdentifierStatus SecondIdentifierStatus { get; set; }
        public IdentifierStatus ThirdIdentifierStatus { get; set; }
        public IdentifierStatus FourthIdentifierStatus { get; set; }

        public MID_0152() : base(MID, LAST_REVISION)
        {
            _identifierStatusConverter = new IdentifierStatusConverter();
        }

        internal MID_0152(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override string Pack()
        {
            RevisionsByFields[1][(int)DataFields.FIRST_IDENTIFIER_STATUS].Value = _identifierStatusConverter.Convert(FirstIdentifierStatus);
            RevisionsByFields[1][(int)DataFields.SECOND_IDENTIFIER_STATUS].Value = _identifierStatusConverter.Convert(SecondIdentifierStatus);
            RevisionsByFields[1][(int)DataFields.THIRD_IDENTIFIER_STATUS].Value = _identifierStatusConverter.Convert(ThirdIdentifierStatus);
            RevisionsByFields[1][(int)DataFields.FOURTH_IDENTIFIER_STATUS].Value = _identifierStatusConverter.Convert(FourthIdentifierStatus);
            return base.Pack();
        }
        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                base.Parse(package);

                FirstIdentifierStatus =  _identifierStatusConverter.Convert(RevisionsByFields[1][(int)DataFields.FIRST_IDENTIFIER_STATUS].Value);
                SecondIdentifierStatus =  _identifierStatusConverter.Convert(RevisionsByFields[1][(int)DataFields.SECOND_IDENTIFIER_STATUS].Value);
                ThirdIdentifierStatus =  _identifierStatusConverter.Convert(RevisionsByFields[1][(int)DataFields.THIRD_IDENTIFIER_STATUS].Value);
                FourthIdentifierStatus =  _identifierStatusConverter.Convert(RevisionsByFields[1][(int)DataFields.FOURTH_IDENTIFIER_STATUS].Value);

                return this;
            }

            return NextTemplate.Parse(package);
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

        public enum DataFields
        {
            FIRST_IDENTIFIER_STATUS,
            SECOND_IDENTIFIER_STATUS,
            THIRD_IDENTIFIER_STATUS,
            FOURTH_IDENTIFIER_STATUS
        }
    }
}
