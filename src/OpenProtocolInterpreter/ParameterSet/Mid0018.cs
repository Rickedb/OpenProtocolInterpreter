using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Select Parameter set
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///     <see cref="Communication.Mid0004"/> Command error, Parameter set can not be set
    /// </para>
    /// </summary>
    public class Mid0018 : Mid, IParameterSet, IIntegrator
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 18;

        public int ParameterSetId
        {
            get => GetField(1,(int)DataFields.PARAMETER_SET_ID).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.PARAMETER_SET_ID).SetValue(_intConverter.Convert, value);
        }

        public Mid0018() : base(MID, LAST_REVISION) => _intConverter = new Int32Converter();

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="parameterSetId">Three ASCII digits, range 000-999</param>
        public Mid0018(int parameterSetId) : this() => ParameterSetId = parameterSetId;

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
