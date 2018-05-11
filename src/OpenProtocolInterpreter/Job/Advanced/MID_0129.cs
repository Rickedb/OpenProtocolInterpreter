using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job batch increment
    /// Description: Decrement the Job batch if there is a current running Job. 
    /// Two revisions are available for this MID.
    /// The default revision or revision 1 does not contain any argument and always decrement the last
    /// tightening completed in a Job.
    /// 
    /// The revision 2 contains two parameters; the channel ID and parameter set ID to be decremented.
    /// 
    /// The MID is always sent to the cell master/reference.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    /// MID 0004 Command error, Job batch decrement failed (only for MID revision 2)
    /// </summary>
    public class MID_0129 : Mid, IAdvancedJob
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 2;
        public const int MID = 129;

        public int ChannelId
        {
            get => RevisionsByFields[2][(int)DataFields.CHANNEL_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.CHANNEL_ID].SetValue(_intConverter.Convert, value);
        }
        public int ParameterSetId
        {
            get => RevisionsByFields[2][(int)DataFields.PARAMETER_SET_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.PARAMETER_SET_ID].SetValue(_intConverter.Convert, value);
        }

        public MID_0129(int revision = LAST_REVISION) : base(MID, LAST_REVISION) { }

        public MID_0129(int channelId, int parameterSetId, int revision = 2) : this(revision)
        {
            ChannelId = channelId;
            ParameterSetId = parameterSetId;
        }

        internal MID_0129(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                },
                {
                    2, new List<DataField>()
                            {
                                new DataField((int)DataFields.CHANNEL_ID, 23, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
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
