using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Reset Parameter set batch counter
    /// <para>This message gives the possibility to reset the batch counter of the running parameter set, at run time.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///     <see cref="Communication.Mid0004"/> Command error, Invalid data, or Parameter set not running
    /// </para>
    /// </summary>
    public class Mid0020 : Mid, IParameterSet, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 20;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.InvalidData, Error.ParameterSetNotRunning };

        public int ParameterSetId
        {
            get => GetField(1, (int)DataFields.ParameterSetId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.ParameterSetId).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0020() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0020(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.ParameterSetId, 20, 3, '0', PaddingOrientation.LeftPadded, false)
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
