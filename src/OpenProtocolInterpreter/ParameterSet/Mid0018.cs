using System.Collections.Generic;

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
    public class Mid0018 : Mid, IParameterSet, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 18;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.ParameterSetCannotBeSet };

        public int ParameterSetId
        {
            get => GetField(1,(int)DataFields.ParameterSetId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.ParameterSetId).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0018() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0018(Header header) : base(header)
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
