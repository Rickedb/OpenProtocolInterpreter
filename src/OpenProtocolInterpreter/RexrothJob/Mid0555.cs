using System.Collections.Generic;

namespace OpenProtocolInterpreter.RexrothJob
{
    /// <summary>
    /// Rexroth job result data upload
    /// <para>
    ///     The controller reports a job result including the job result number and result value.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0556"/> Rexroth job result acknowledge</para>
    /// </summary>
    public class Mid0555 : Mid, IRexrothJob, IController, IAcknowledgeable<Mid0556>
    {
        public const int MID = 555;

        /// <summary>
        /// Job result number (3 digits, 000-999).
        /// </summary>
        public int JobResultNumber
        {
            get => GetField(1, DataFields.JobResultNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.JobResultNumber).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>
        /// Job result value (single digit).
        /// </summary>
        public int JobResultValue
        {
            get => GetField(1, DataFields.JobResultValue).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.JobResultValue).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0555() : this(DEFAULT_REVISION) { }

        public Mid0555(Header header) : base(header) { }

        public Mid0555(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        DataField.Number(DataFields.JobResultNumber, 20, 3),
                        DataField.Number(DataFields.JobResultValue, 25, 1)
                    }
                }
            };
        }

        protected enum DataFields
        {
            JobResultNumber,
            JobResultValue
        }
    }
}
