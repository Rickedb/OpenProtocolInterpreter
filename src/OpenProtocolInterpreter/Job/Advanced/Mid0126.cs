using System.Collections.Generic;

namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Job line control info unsubscribe
    /// <para>Unsubscribe for the Job line control info messages.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Job line control info subscription does not exist</para>
    /// </summary>
    public class Mid0126 : Mid, IAdvancedJob, IIntegrator, IUnsubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 126;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.JobLineControlInfoSubscriptionDoesntExists };

        public Mid0126() : base(MID, DEFAULT_REVISION) { }

        public Mid0126(Header header) : base(header)
        {
        }
    }
}
