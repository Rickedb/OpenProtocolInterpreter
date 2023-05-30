using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Select Parameter set, Dynamic Job Included
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error, Dynamic Job cannot be created, non-existing pset
    /// </para>
    /// </summary>
    public class Mid2504 : Mid, IParameterSet, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 2504;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.ParameterSetIdNotPresent };

        public int ParameterSetId
        {
            get => GetField(1,(int)DataFields.ParameterSetId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.ParameterSetId).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid2504() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid2504(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.ParameterSetId, 20, 3, '0', DataField.PaddingOrientations.LeftPadded, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            ParameterSetId
        }
    }
}
