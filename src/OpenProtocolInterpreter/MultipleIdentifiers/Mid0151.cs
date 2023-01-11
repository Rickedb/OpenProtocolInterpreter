using System.Collections.Generic;

namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// Multiple identifier and result parts subscribe
    /// <para>
    ///    This message is used by the integrator to set a subscription for the work order status, optional
    ///    identifiers and result parts extracted from the identifiers received and accepted by the controller.
    /// </para>   
    /// <para>
    ///    The identifiers may have been received by the controller from one 
    ///    or several input sources (Serial, Ethernet, Field bus, ST scanner etc.).
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///       <see cref="Communication.Mid0004"/> Command error, Multiple identifier and result parts subscription already exists
    /// </para>        
    /// </summary>
    public class Mid0151 : Mid, IMultipleIdentifier, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        private const int LAST_REVISION = 1;
        public const int MID = 151;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.SUBSCRIPTION_ALREADY_EXISTS };

        public Mid0151() : this(false)
        {

        }

        public Mid0151(bool noAckFlag = false) : base(MID, LAST_REVISION, noAckFlag) { }

        public Mid0151(Header header) : base(header)
        {
        }
    }
}
