using System.Collections.Generic;

namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// User data subscribe
    /// <para>
    ///     Subscribe for user data. This command will activate the <see cref="Mid0242"/> User data message to be sent when a
    ///     change in the user data output has been detected.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///         <see cref="Communication.Mid0004"/> Command error, Subscription already exists, or
    ///         Controller is not a sync master/station controller
    /// </para>
    /// </summary>
    public class Mid0241 : Mid, IPLCUserData, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 241;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.SUBSCRIPTION_ALREADY_EXISTS, Error.CONTROLLER_IS_NOT_A_SYNC_MASTER_OR_STATION_CONTROLLER };

        public Mid0241() : this(false)
        {

        }

        public Mid0241(bool noAckFlag = false) : base(MID, DEFAULT_REVISION, noAckFlag) 
        { 
        }

        public Mid0241(Header header) : base(header)
        {
        }
    }
}