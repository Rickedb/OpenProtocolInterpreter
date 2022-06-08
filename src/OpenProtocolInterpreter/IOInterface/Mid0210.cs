using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Status externally monitored inputs subscribe
    /// <para>
    ///     By using this message the integrator can set a subscription to monitor the status 
    ///     for the eight externally monitored digital inputs. After the subscription the station 
    ///     will directly receive a status message and then every time the status of at least one of 
    ///     the inputs has changed.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    /// Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///     <see cref="Communication.Mid0004"/> Command error, Status externally monitored inputs subscription already exists or 
    ///     <see cref="Mid0211"/> Status externally monitored inputs.
    /// </para>
    /// </summary>
    public class Mid0210 : Mid, IIOInterface, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        private const int LAST_REVISION = 1;
        public const int MID = 210;

        public IEnumerable<Error> PossibleErrors => new Error[] { Error.STATUS_EXTERNAL_MONITORED_INPUTS_SUBSCRIPTION_ALREADY_EXISTS };

        public Mid0210() : this(false)
        {

        }

        public Mid0210(bool noAckFlag = false) : base(MID, LAST_REVISION, noAckFlag) { }

        public Mid0210(Header header) : base(header)
        {
        }
    }
}
