using System.Collections.Generic;

namespace OpenProtocolInterpreter.RexrothJob
{
    /// <summary>
    /// Select job number
    /// <para>
    ///     Select a job by its number on the tightening channel.
    ///     Requires JobEnable, JobStart, and Job0-7 signals to be applied to the OP module.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error, request timeout or PLC signal not assigned
    /// </para>
    /// </summary>
    public class Mid0573 : Mid, IRexrothJob, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 573;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.ControllerInternalRequestTimeout };

        /// <summary>
        /// Job number to select (000-999).
        /// </summary>
        public int JobNumber
        {
            get => GetField(1, DataFields.JobNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.JobNumber).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0573() : this(DEFAULT_REVISION) { }

        public Mid0573(Header header) : base(header) { }

        public Mid0573(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        DataField.Number(DataFields.JobNumber, 20, 3, false)
                    }
                }
            };
        }

        protected enum DataFields
        {
            JobNumber
        }
    }
}
