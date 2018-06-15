using System.Collections.Generic;

namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: Identifier download request
    /// Description: Used by the integrator to send an identifier to the controller.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    /// MID 0004 Command error, Identifier input source not granted
    /// </summary>
    public class MID_0150 : Mid, IMultipleIdentifier
    {
        private const int LAST_REVISION = 1;
        public const int MID = 150;

        public string IdentifierData
        {
            get => GetField(1,(int)DataFields.IDENTIFIER_DATA).Value;
            set => GetField(1,(int)DataFields.IDENTIFIER_DATA).SetValue(value);
        }

        public MID_0150() : base(MID, LAST_REVISION) { }

        public MID_0150(string identifierData) : this()
        {
            IdentifierData = identifierData;
        }

        internal MID_0150(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);
                GetField(1,(int)DataFields.IDENTIFIER_DATA).Size = package.Length - 20;
                ProcessDataFields(package);
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
                        new DataField((int)DataFields.IDENTIFIER_DATA, 20, 100, false)
                    }
                }
            };
        }

        public enum DataFields
        {
            IDENTIFIER_DATA
        }
    }
}
