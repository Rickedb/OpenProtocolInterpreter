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
            
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.FirstIdentifierStatus).Value = FirstIdentifierStatus.Pack();
            GetField(1, (int)DataFields.SecondIdentifierStatus).Value = SecondIdentifierStatus.Pack();
            GetField(1, (int)DataFields.ThirdIdentifierStatus).Value = ThirdIdentifierStatus.Pack();
            GetField(1, (int)DataFields.FourthIdentifierStatus).Value = FourthIdentifierStatus.Pack();
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            base.Parse(package);

            FirstIdentifierStatus = IdentifierStatus.Parse(GetField(1, (int)DataFields.FirstIdentifierStatus).Value);
            SecondIdentifierStatus = IdentifierStatus.Parse(GetField(1, (int)DataFields.SecondIdentifierStatus).Value);
            ThirdIdentifierStatus = IdentifierStatus.Parse(GetField(1, (int)DataFields.ThirdIdentifierStatus).Value);
            FourthIdentifierStatus = IdentifierStatus.Parse(GetField(1, (int)DataFields.FourthIdentifierStatus).Value);

            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new((int)DataFields.FirstIdentifierStatus, 20, 30),
                                new((int)DataFields.SecondIdentifierStatus, 52, 30),
                                new((int)DataFields.ThirdIdentifierStatus, 84, 30),
                                new((int)DataFields.FourthIdentifierStatus, 116, 30)
                            }
                }
            };
        }

        protected enum DataFields
        {
            FirstIdentifierStatus,
            SecondIdentifierStatus,
            ThirdIdentifierStatus,
            FourthIdentifierStatus
        }
    }
}
