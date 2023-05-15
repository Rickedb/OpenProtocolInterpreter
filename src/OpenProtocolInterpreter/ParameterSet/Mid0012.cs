using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Parameter set data upload request
    /// <para>Request to upload parameter set data from the controller.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    /// Answer: <see cref="Mid0013"/> Parameter set data upload reply, or 
    ///         <see cref="Communication.Mid0004"/> Command error, Parameter set not present
    /// </para>
    /// </summary>
    public class Mid0012 : Mid, IParameterSet, IIntegrator, IAnswerableBy<Mid0013>, IDeclinableCommand
    {
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 12;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.PARAMETER_SET_ID_NOT_PRESENT };

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

        public Mid0012() : this(DEFAULT_REVISION)
        {

        }

        public Mid0012(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        public Mid0012(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
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
                {
                    3, new  List<DataField>()
                            {
                                new DataField((int)DataFields.PSET_FILE_VERSION, 23, 8, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                            }
                },
            };
        }

        protected enum DataFields
        {
            //Revision 1-2
            PARAMETER_SET_ID,
            //Revision 3-4
            PSET_FILE_VERSION
        }
    }
}
