using System.Collections.Generic;

namespace OpenProtocolInterpreter.Vin
{
    /// <summary>
    /// Vehicle ID Number subscribe
    /// <para>
    ///     This message is used by the integrator to set a subscription for the current 
    ///     identifiers of the tightening result.
    /// </para>    
    /// <para>The tightening result can be stamped with up to four identifiers:</para>
    /// <list type="bullet">
    ///     <item>VIN number (identifier result part 1)</item>
    ///     <item>Identifier result part 2</item>
    ///     <item>Identifier result part 3</item>
    ///     <item>Identifier result part 4</item>
    /// </list>
    /// <para>
    ///     The identifiers are received by the controller from several input sources, 
    ///     for example serial, Ethernet, or field bus.
    /// </para>
    /// <para>In revision 1 of the <see cref="Mid0052"/> Vehicle ID Number, only the VIN number is transmitted.</para>
    /// <para>In revision 2, all four possible identifiers are transmitted.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///             <see cref="Communication.Mid0004"/> Command error, VIN subscription already exists
    /// </para>
    /// </summary>
    public class Mid0051 : Mid, IVin, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        private const int LAST_REVISION = 2;
        public const int MID = 51;

        public IEnumerable<Error> PossibleErrors => new Error[] { Error.VIN_UPLOAD_SUBSCRIPTION_ALREADY_EXISTS };

        public Mid0051() : this(LAST_REVISION)
        {

        }

        public Mid0051(int revision = LAST_REVISION, bool noAckFlag = false) : base(MID, revision, noAckFlag)
        {

        }

        public Mid0051(Header header) : base(header)
        {
        }
    }
}
