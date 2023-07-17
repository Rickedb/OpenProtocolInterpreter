using System.Collections.Generic;

namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    /// <summary>
    /// Open Protocol commands disabled unsubscribe
    /// <para>Reset the subscription for the Open Protocol commands disabled digital input.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    /// Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///         <see cref="Communication.Mid0004"/> Command error, Open Protocol commands disabled
    ///         subscription does not exist
    /// </para>
    /// </summary>
    public class Mid0423 : Mid, IOpenProtocolCommandsDisabled, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 423;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.OpenProtocolCommandsDisabledSubscriptionDoesntExists };

        public Mid0423() : base(MID, DEFAULT_REVISION) { }

        public Mid0423(Header header) : base(header)
        {
        }
    }
}
