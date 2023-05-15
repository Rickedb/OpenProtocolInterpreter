using OpenProtocolInterpreter.Converters;
using OpenProtocolInterpreter.Result;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Select Parameter set dynamically.
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error, Dynamic Pset cannot be created, non-existing pset
    /// </para>
    /// <para>
    /// A dynamic pset is created from a preexisting Pset in the Controller and selected for tightenings. 
    /// The message can substitute Pset selection, Set Identifier, Reset All Identifier, Reset Latest Identifier, Set Batch Size, Disable Tool and Enable Tool.
    /// </para>
    /// </summary>
    public class Mid2505 : Mid, IParameterSet, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 2505;
        private readonly Int32Converter _intConverter;
        private readonly VariableDataFieldListConverter _variableDataFieldListConverter;

        public IEnumerable<Error> DocumentedPossibleErrors => Enumerable.Empty<Error>();

        public int ParameterSetId { get; set; }
        public int NumberOfParameterDataFields { get; set; }
        public List<VariableDataField> DataFields { get; set; }

        public Mid2505() : this(DEFAULT_REVISION)
        {

        }

        public Mid2505(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        public Mid2505(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            _variableDataFieldListConverter = new VariableDataFieldListConverter(_intConverter);
            if (DataFields == null)
                DataFields = new List<VariableDataField>();
        }

        public override string Pack()
        {
            GetField(1, (int)MidDataFields.DataFields).Value = _variableDataFieldListConverter.Convert(DataFields);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            var dataFieldsField = GetField(1, (int)MidDataFields.DataFields);
            dataFieldsField.Size = Header.Length - dataFieldsField.Index;
            base.Parse(package);
            DataFields = _variableDataFieldListConverter.Convert(dataFieldsField.Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)MidDataFields.ParameterSetId, 0, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)MidDataFields.NumberOfParameterDataFields, 3, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)MidDataFields.DataFields, 6, 0)
                            }
                }
            };
        }

        internal enum MidDataFields
        {
            ParameterSetId,
            NumberOfParameterDataFields,
            DataFields
        }
    }
}
