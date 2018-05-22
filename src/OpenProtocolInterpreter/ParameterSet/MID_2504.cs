using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Select Parameter set, Dynamic Job Included
    /// Description: 
    ///     Select a parameter set.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Dynamic Job cannot be created, non-existing pset
    /// </summary>
    public class MID_2504 : Mid, IParameterSet
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 2504;

        public int ParameterSetId
        {
            get => RevisionsByFields[1][(int)DataFields.PARAMETER_SET_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.PARAMETER_SET_ID].SetValue(_intConverter.Convert, value);
        }

        public MID_2504() : base(MID, LAST_REVISION) => _intConverter = new Int32Converter();

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="parameterSetId">Three ASCII digits, range 000-999</param>
        public MID_2504(int parameterSetId) : this() => ParameterSetId = parameterSetId;

        internal MID_2504(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                            }
                }
            };
        }

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            List<string> failed = new List<string>();
            if (ParameterSetId < 0 || ParameterSetId > 999)
                failed.Add(new ArgumentOutOfRangeException(nameof(ParameterSetId), "Range: 000-999").Message);

            errors = failed;
            return errors.Any();
        }

        public enum DataFields
        {
            PARAMETER_SET_ID
        }
    }
}
