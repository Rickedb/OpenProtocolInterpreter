using System.Collections.Generic;

namespace OpenProtocolInterpreter.RexrothJob
{
    /// <summary>
    /// Activate job
    /// <para>
    ///     Enable or disable the job function of the tightening channel.
    ///     Requires the JobEnable signal to be applied to the OP module in the PLC assignment table.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error, request timeout or PLC signal not assigned
    /// </para>
    /// </summary>
    public class Mid0570 : Mid, IRexrothJob, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 570;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.ControllerInternalRequestTimeout };

        /// <summary>
        /// <para>Job Deactivated = false (0)</para>
        /// <para>Job Activated = true (1)</para>
        /// </summary>
        public bool JobStatus
        {
            get => GetField(1, DataFields.JobStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, DataFields.JobStatus).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0570() : this(DEFAULT_REVISION) { }

        public Mid0570(Header header) : base(header) { }

        public Mid0570(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        DataField.Boolean(DataFields.JobStatus, 20)
                    }
                }
            };
        }

        protected enum DataFields
        {
            JobStatus
        }
    }
}
