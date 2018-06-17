using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Parameter set data upload request
    /// Description: 
    ///     Request to upload parameter set data from the controller.
    /// Message sent by: Integrator
    /// Answer: MID 0013 Parameter set data upload reply, or MID 0004 Command error, Parameter set not present
    /// </summary>
    public class Mid0012 : Mid, IParameterSet
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 4;
        public const int MID = 12;

        public int ParameterSetId
        {
            get => GetField(1, (int)DataFields.PARAMETER_SET_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.PARAMETER_SET_ID).SetValue(_intConverter.Convert, value);
        }
        public int ParameterSetFileVersion
        {
            get => GetField(3, (int)DataFields.PSET_FILE_VERSION).GetValue(_intConverter.Convert);
            set => GetField(3, (int)DataFields.PSET_FILE_VERSION).SetValue(_intConverter.Convert, value);
        }

        public Mid0012(int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
        }

        /// <summary>
        /// Revision 1 and 2 Constructor
        /// </summary>
        /// <param name="parameterSetId">Parameter Set Id. Three ASCII digits. Range: 000-999</param>
        /// <param name="revision">Revision</param>
        public Mid0012(int parameterSetId, int revision) : this(revision)
        {
            ParameterSetId = parameterSetId;
        }

        /// <summary>
        /// Revision 3 and 4 Constructor
        /// </summary>
        /// <param name="parameterSetId">Parameter Set Id. Three ASCII digits. Range: 000-999</param>
        /// <param name="parameterSetFileVersion">00000000 (special usage see Toyota appendix)</param>
        /// <param name="revision">Revision</param>
        public Mid0012(int parameterSetId, int parameterSetFileVersion, int revision) : this(parameterSetId, revision)
        {
            ParameterSetFileVersion = parameterSetFileVersion;
        }

        internal Mid0012(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            List<string> failed = new List<string>();
            if (ParameterSetId < 1 || ParameterSetId > 999)
                failed.Add(new ArgumentOutOfRangeException(nameof(ParameterSetId), "Range: 000-999").Message);

            if (HeaderData.Revision > 2)
                if (ParameterSetFileVersion < 0 || ParameterSetFileVersion > 99999999)
                    failed.Add(new ArgumentOutOfRangeException(nameof(ParameterSetFileVersion), "Range: 00000000-99999999").Message);

            errors = failed;
            return failed.Count > 0;
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
                },
                { 2, new List<DataField>() },
                {
                    3, new  List<DataField>()
                            {
                                new DataField((int)DataFields.PSET_FILE_VERSION, 23, 8, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                            }
                },
                { 4, new List<DataField>() }
            };
        }

        public enum DataFields
        {
            //Revision 1-2
            PARAMETER_SET_ID,
            //Revision 3-4
            PSET_FILE_VERSION
        }
    }
}
