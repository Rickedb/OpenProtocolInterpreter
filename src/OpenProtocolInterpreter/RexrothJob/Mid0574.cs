using System.Collections.Generic;

namespace OpenProtocolInterpreter.RexrothJob
{
    /// <summary>
    /// Job manipulate (abort/increment/decrement)
    /// <para>
    ///     Manipulate the current job: abort, increment, or decrement.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0574 : Mid, IRexrothJob, IIntegrator
    {
        public const int MID = 574;

        /// <summary>
        /// Action code:
        /// <para>01 = Abort job</para>
        /// <para>02 = Increment job</para>
        /// <para>03 = Decrement job</para>
        /// </summary>
        public int ActionCode
        {
            get => GetField(1, DataFields.ActionCode).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.ActionCode).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0574() : this(DEFAULT_REVISION) { }

        public Mid0574(Header header) : base(header) { }

        public Mid0574(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        DataField.Number(DataFields.ActionCode, 20, 2)
                    }
                }
            };
        }

        protected enum DataFields
        {
            ActionCode
        }
    }
}
