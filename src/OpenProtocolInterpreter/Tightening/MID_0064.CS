using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// MID: Old tightening result upload request
    /// Description: This message is a request to upload a particular tightening result from the controller. The requested
    ///              result is specified by its unique ID(tightening ID). This message is useful after a failure of the
    ///              network in order to retrieve the missing result during the communication interruption.The integrator
    ///              can see the missing results by always comparing the last tightening IDs of the two last received
    ///              tightenings packets (parameter 23 in the result message).
    ///              Requesting tightening ID zero is the same as requesting the latest tightening performed.
    /// Message sent by: Integrator
    /// Answer: MID 0065 Old tightening result upload reply 
    ///         or MID 0004 Command error, Tightening ID requested not found,
    ///         or MID revision not supported
    /// </summary>
    public class MID_0064 : MID, ITightening
    {
        private readonly IValueConverter<long> _longConverter;
        private const int LAST_REVISION = 6;
        public const int MID = 64;

        public long TighteningId
        {
            get => RevisionsByFields[1][(int)DataFields.TIGHTENING_ID].GetValue(_longConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.TIGHTENING_ID].SetValue(_longConverter.Convert, value);
        }

        public MID_0064(int revision = LAST_REVISION) : base(MID, LAST_REVISION) { }

        public MID_0064(int tighteningId, int revision = LAST_REVISION) : this(revision)
        {
            TighteningId = tighteningId;
        }

        internal MID_0064(IMID nextTemplate) : this() => NextTemplate = nextTemplate;

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            //opted to work with a different approuch (since it would need to modify too much fields)
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.TIGHTENING_ID, 20, 10, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                            }
                }
            };
        }

        public enum DataFields
        {
            TIGHTENING_ID
        }
    }
}
