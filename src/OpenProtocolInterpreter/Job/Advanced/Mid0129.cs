using System.Collections.Generic;

namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Job batch increment
    /// <para>
    ///     Decrement the Job batch if there is a current running Job. 
    ///     Two revisions are available for this MID.
    ///     The default revision or revision 1 does not contain any argument and always decrement the last
    ///     tightening completed in a Job.
    /// </para>
    /// <para>The revision 2 contains two parameters; the channel ID and parameter set ID to be decremented.</para>
    /// <para>The MID is always sent to the cell master/reference.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Job batch decrement failed (only for MID revision 2)</para>
    /// </summary>
    public class Mid0129 : Mid, IAdvancedJob, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 129;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.JobBatchDecrementFailed };

        public int ChannelId
        {
            get => GetField(2, (int)DataFields.ChannelId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.ChannelId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int ParameterSetId
        {
            get => GetField(2, (int)DataFields.ParameterSetId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.ParameterSetId).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0129() : this(DEFAULT_REVISION)
        {

        }

        public Mid0129(Header header) : base(header)
        {
        }

        public Mid0129(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
            
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    2, new List<DataField>()
                            {
                                new DataField((int)DataFields.ChannelId, 20, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ParameterSetId, 24, 3, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                }
            };
        }

        protected enum DataFields
        {
            ChannelId,
            ParameterSetId
        }
    }
}
