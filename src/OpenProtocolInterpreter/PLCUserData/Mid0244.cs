using System.Collections.Generic;

namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// User data unsubscribe
    /// <para>Unsubscribe for the user data.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///         <see cref="Communication.Mid0004"/> Command error, Subscription already exists
    /// </para>
    /// </summary>
    public class Mid0244 : Mid, IPLCUserData, IIntegrator, IUnsubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 244;
        
        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.SubscriptionDoesntExists };

        public Mid0244() : base(MID, DEFAULT_REVISION) { }

        public Mid0244(Header header) : base(header)
        {
        }
    }
}
