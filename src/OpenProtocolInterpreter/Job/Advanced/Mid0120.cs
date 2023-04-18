using System.Collections.Generic;

namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Job line control info subscribe
    /// <para>
    ///     A subscription for the Job line control information.
    ///     A message is sent to the integrator when the Job line control is started, for alert level 1, 
    ///     for alert level 2, or when the Job is finished before the alert level 2 (Job line control done).
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> or <see cref="Communication.Mid0004"/> Command error, Job line control info subscription already exists</para>
    /// </summary>
    public class Mid0120 : Mid, IAdvancedJob, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 120;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.JOB_LINE_CONTROL_INFO_SUBSCRIPTION_ALREADY_EXISTS };

        public Mid0120() : this(false)
        {

        }

        public Mid0120(bool noAckFlag = false) : base(MID, DEFAULT_REVISION, noAckFlag)
        {
        }

        public Mid0120(Header header) : base(header)
        {
        }
    }
}
