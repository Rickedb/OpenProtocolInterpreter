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
    public class Mid0011 : Mid, IParameterSet
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<IEnumerable<int>> _intListConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 11;

        public int TotalParameterSets
        {
            get => GetField(1, (int)DataFields.TOTAL_PARAMETER_SETS).GetValue(_intConverter.Convert);
            private set => GetField(1, (int)DataFields.TOTAL_PARAMETER_SETS).SetValue(_intConverter.Convert, value);
        }

        public List<int> ParameterSets { get; set; }

        public Mid0011() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
            _intListConverter = new ParameterSetIdListConverter(_intConverter);
            if (ParameterSets == null)
                ParameterSets = new List<int>();
        }

        public Mid0011(IEnumerable<int> parameterSets) : this()
        {
            ParameterSets = parameterSets.ToList();
        }

        internal Mid0011(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override string Pack()
        {
            TotalParameterSets = ParameterSets.Count;
            var eachParameterField = GetField(1, (int)DataFields.EACH_PARAMETER_SET);
            eachParameterField.Value = _intListConverter.Convert(ParameterSets);
            eachParameterField.Size = eachParameterField.Value.Length;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);

                GetField(1, (int)DataFields.EACH_PARAMETER_SET).Size = package.Length - GetField(1, (int)DataFields.EACH_PARAMETER_SET).Index;
                ProcessDataFields(package);
                ParameterSets = _intListConverter.Convert(GetField(1, (int)DataFields.EACH_PARAMETER_SET).Value).ToList();
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
