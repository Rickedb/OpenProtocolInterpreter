using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Select Parameter set
    /// Description: 
    ///     Select a parameter set.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Parameter set can not be set
    /// </summary>
    public class MID_0018 : MID, IParameterSet
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 18;

        public int ParameterSetId
        {
            get => RevisionsByFields[1][(int)DataFields.PARAMETER_SET_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.PARAMETER_SET_ID].SetValue(_intConverter.Convert, value);
        }

        public MID_0018() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="parameterSetId">Three ASCII digits, range 000-999</param>
        public MID_0018(int parameterSetId) : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
            SetRevision1(parameterSetId);
        }

        internal MID_0018(IMID nextTemplate) : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
            NextTemplate = nextTemplate;
        }

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
        /// Revision 1 Setter
        /// </summary>
        /// <param name="parameterSetId">Three ASCII digits, range 000-999</param>
        public void SetRevision1(int parameterSetId)
        {
            ParameterSetId = parameterSetId;
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
