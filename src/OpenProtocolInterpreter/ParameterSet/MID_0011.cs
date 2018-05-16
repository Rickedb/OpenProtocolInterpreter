using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Parameter set ID upload reply
    /// Description: 
    ///     The transmission of all the valid parameter set IDs of the controller. In the revision 000-001 the data
    ///     field contains the number of valid parameter sets currently present in the controller, and the ID of each
    ///     parameter set present.In revision 2 is the number of stages on each Pset/Mset added.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0011 : Mid, IParameterSet
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<IEnumerable<int>> _intListConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 11;

        public int TotalParameterSets
        {
            get => RevisionsByFields[1][(int)DataFields.TOTAL_PARAMETER_SETS].GetValue(_intConverter.Convert);
            private set => RevisionsByFields[1][(int)DataFields.TOTAL_PARAMETER_SETS].SetValue(_intConverter.Convert, value);
        }

        public List<int> ParameterSets { get; set; }

        public MID_0011() : base(MID, LAST_REVISION)
        {
            ParameterSets = new List<int>();
            _intConverter = new Int32Converter();
            _intListConverter = new JobListConverter(_intConverter);
        }

        public MID_0011(IEnumerable<int> parameterSets) : this()
        {
            ParameterSets = parameterSets.ToList();
            TotalParameterSets = ParameterSets.Count;
        }

        internal MID_0011(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override string Pack()
        {
            TotalParameterSets = ParameterSets.Count;
            RevisionsByFields[1][(int)DataFields.EACH_PARAMETER_SET].Value = _intListConverter.Convert(ParameterSets);
            RevisionsByFields[1][(int)DataFields.TOTAL_PARAMETER_SETS].Size = RevisionsByFields[1][(int)DataFields.EACH_PARAMETER_SET].Value.Length;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);

                RevisionsByFields[1][(int)DataFields.EACH_PARAMETER_SET].Size = package.Length - RevisionsByFields[1][(int)DataFields.TOTAL_PARAMETER_SETS].Size - 20;
                ProcessDataFields(package);
                ParameterSets = _intListConverter.Convert(RevisionsByFields[1][(int)DataFields.EACH_PARAMETER_SET].Value).ToList();
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
                                new DataField((int)DataFields.TOTAL_PARAMETER_SETS, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.EACH_PARAMETER_SET, 23, 3, false)
                            }
                }
            };
        }

        public enum DataFields
        {
            TOTAL_PARAMETER_SETS,
            EACH_PARAMETER_SET
        }
    }
}
