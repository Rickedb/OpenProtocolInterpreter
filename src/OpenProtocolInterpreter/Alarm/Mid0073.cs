using System.Collections.Generic;

namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Alarm unsubscribe
    /// <para>Reset the subscription for the controller alarms.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Alarm subscription does not exist</para>
    /// </summary>
    public class Mid0073 : Mid, IAlarm, IIntegrator, IUnsubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 73;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.ALARM_SUBSCRIPTION_DOESNT_EXISTS };

        public Mid0073() : this(DEFAULT_REVISION)
        {

        }

        public Mid0073(int revision = DEFAULT_REVISION) : base(MID, revision)
        {

        }

        public Mid0073(Header header) : base(header)
        {

        }
    }
}
