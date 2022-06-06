namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Multi-spindle status subscribe
    /// <para>A subscription for the multi-spindle status. For Power Focus, the subscription must be addressed to the sync Master.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    /// Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///         <see cref="Communication.Mid0004"/> Command error, Controller is not a sync master/station controller, 
    ///         or Multi-spindle status subscription already exists
    /// </para>
    /// </summary>
    public class Mid0090 : Mid, IMultiSpindle, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 90;

        public Mid0090() : this(false)
        {

        }

        public Mid0090(bool noAckFlag = false) : base(MID, LAST_REVISION, noAckFlag)
        {

        }

        public Mid0090(Header header) : base(header)
        {
        }
    }
}
