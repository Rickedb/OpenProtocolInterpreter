using System.Collections.Generic;

namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// Automatic/Manual mode subscribe
    /// <para>    
    ///     A subscription for Automatic/Manual mode. When the mode changes the <see cref="Mid0401"/> is sent to the integrator.
    ///     After a successful subscription the message <see cref="Mid0401"/> upload with the current mode status is sent to the integrator.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, 
    ///     Automatic/Manual mode subscribe already exists
    /// </para>
    /// </summary>
    public class Mid0400 : Mid, IAutomaticManualMode, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        private const int LAST_REVISION = 1;
        public const int MID = 400;

        public IEnumerable<Error> PossibleErrors => new Error[] { Error.AUTOMATIC_MANUAL_MODE_SUBSCRIBE_ALREADY_EXISTS };

        public Mid0400() : this(false)
        {

        }

        public Mid0400(bool noAckFlag = false) : this(new Header()
        {
            Mid = MID,
            Revision = LAST_REVISION, 
            NoAckFlag = noAckFlag
        }) 
        { 
        }

        public Mid0400(Header header) : base(header)
        {

        }
    }
}
