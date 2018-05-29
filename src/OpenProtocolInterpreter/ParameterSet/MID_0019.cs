using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Set Parameter set batch size
    /// Description: 
    ///     This message gives the possibility to set the batch size of a parameter set at run time.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Invalid data
    /// </summary>
    public class MID_0019 : Mid, IParameterSet
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 19;
        
        public int ParameterSetId
        {
            get => GetField(1,(int)DataFields.PARAMETER_SET_ID).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.PARAMETER_SET_ID).SetValue(_intConverter.Convert, value);
        }
        public int BatchSize
        {
            get => GetField(1,(int)DataFields.BATCH_SIZE).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.BATCH_SIZE).SetValue(_intConverter.Convert, value);
        }

        public MID_0019() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="parameterSetId">Three ASCII digits, range 000-999</param>
        /// <param name="batchSize">Two ASCII digits, range 01-99</param>
        public MID_0019(int parameterSetId, int batchSize) : this()
        {
            ParameterSetId = parameterSetId;
            BatchSize = batchSize;
        }

        internal MID_0019(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.BATCH_SIZE, 23, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
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
            if (BatchSize < 0 || BatchSize > 99)
                failed.Add(new ArgumentOutOfRangeException(nameof(BatchSize), "Range: 00-99").Message);

            errors = failed;
            return errors.Any();
        }

        public enum DataFields
        {
            PARAMETER_SET_ID,
            BATCH_SIZE
        }
    }
}
