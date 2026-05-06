using System.Collections.Generic;

namespace OpenProtocolInterpreter.RexrothJob
{
    /// <summary>
    /// Start job sequence
    /// <para>
    ///     Start or stop the job function of the tightening channel.
    ///     Requires the JobStart signal to be applied to the OP module in the PLC assignment table.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error, request timeout or PLC signal not assigned
    /// </para>
    /// </summary>
    public class Mid0571 : Mid, IRexrothJob, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 571;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.ControllerInternalRequestTimeout };

        /// <summary>
        /// <para>Job Stop = false (0)</para>
        /// <para>Job Start = true (1)</para>
        /// </summary>
        public bool JobStart
        {
            get => GetField(1, DataFields.JobStart).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, DataFields.JobStart).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0571() : this(DEFAULT_REVISION) { }

        public Mid0571(Header header) : base(header) { }

        public Mid0571(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        DataField.Boolean(DataFields.JobStart, 20)
                    }
                }
            };
        }

        protected enum DataFields
        {
            JobStart
        }
    }
}
