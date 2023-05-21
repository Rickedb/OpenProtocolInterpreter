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
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<IEnumerable<VariableDataField>> _variableDataFieldListConverter;

        public IEnumerable<Error> DocumentedPossibleErrors => Enumerable.Empty<Error>();

        public int ParameterSetId
        {
            get => GetField(1, (int)DataFields.ParameterSetId).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.ParameterSetId).SetValue(_intConverter.Convert, value);
        }
        public int NumberOfParameterDataFields
        {
            get => GetField(1, (int)DataFields.NumberOfParameterDataFields).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.NumberOfParameterDataFields).SetValue(_intConverter.Convert, value);
        }
        public List<VariableDataField> VariableDataFields { get; set; }

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
            VariableDataFields = new List<VariableDataField>();
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.DataFields).Value = _variableDataFieldListConverter.Convert(VariableDataFields);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            var dataFieldsField = GetField(1, (int)DataFields.DataFields);
            dataFieldsField.Size = Header.Length - dataFieldsField.Index;
            ProcessDataFields(package);
            VariableDataFields = _variableDataFieldListConverter.Convert(dataFieldsField.Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.ParameterSetId, 20, 3, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.NumberOfParameterDataFields, 23, 3, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.DataFields, 26, 0, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            ParameterSetId,
            NumberOfParameterDataFields,
            DataFields
        }
    }
}
