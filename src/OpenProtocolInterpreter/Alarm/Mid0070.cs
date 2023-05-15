using System.Collections.Generic;

namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Alarm subscribe
    /// <para>A subscription for the alarms that can appear in the controller.</para>
    /// <para>Message sent by Integrator</para>
    /// <para>Answers: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Alarm subscription already exists</para>
    /// </summary>
    public class Mid0070 : Mid, IAlarm, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 70;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.ALARM_SUBSCRIPTION_ALREADY_EXISTS };

        public Mid0070() : this(DEFAULT_REVISION)
        {

        }

        public Mid0070(Header header) : base(header)
        {

        }

        public Mid0070(int revision, bool noAckFlag = false) : base(MID, revision, noAckFlag)
        {

        }
    }
}
