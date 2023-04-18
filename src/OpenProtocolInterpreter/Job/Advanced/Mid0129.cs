using OpenProtocolInterpreter.Converters;
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
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 129;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.JOB_BATCH_DECREMENT_FAILED };

        public int ChannelId
        {
            get => GetField(2, (int)DataFields.CHANNEL_ID).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.CHANNEL_ID).SetValue(_intConverter.Convert, value);
        }
        public int ParameterSetId
        {
            get => GetField(2, (int)DataFields.PARAMETER_SET_ID).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.PARAMETER_SET_ID).SetValue(_intConverter.Convert, value);
        }

        public Mid0129() : this(DEFAULT_REVISION)
        {

        }

        public Mid0129(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        public Mid0129(int revision = DEFAULT_REVISION) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
            
        }

        public Mid0129(int channelId, int parameterSetId, int revision = 2) : this(revision)
        {
            ChannelId = channelId;
            ParameterSetId = parameterSetId;
        }


        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    2, new List<DataField>()
                            {
                                new DataField((int)DataFields.CHANNEL_ID, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.PARAMETER_SET_ID, 24, 3, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                }
            };
        }

        public enum DataFields
        {
            CHANNEL_ID,
            PARAMETER_SET_ID
        }
    }
}
