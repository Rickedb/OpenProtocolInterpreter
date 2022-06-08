using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Set Parameter set batch size
    /// <para>This message gives the possibility to set the batch size of a parameter set at run time.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///     <see cref="Communication.Mid0004"/> Command error, Invalid data
    /// </para>
    /// </summary>
    public class Mid0019 : Mid, IParameterSet, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 19;

        public IEnumerable<Error> PossibleErrors => new Error[] { Error.INVALID_DATA };

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

        public Mid0019() : this(new Header()
        {
            Mid = MID, 
            Revision = LAST_REVISION
        })
        {
        }

        public Mid0019(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="parameterSetId">Three ASCII digits, range 000-999</param>
        /// <param name="batchSize">Two ASCII digits, range 01-99</param>
        public Mid0019(int parameterSetId, int batchSize) : this()
        {
            ParameterSetId = parameterSetId;
            BatchSize = batchSize;
        }

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
