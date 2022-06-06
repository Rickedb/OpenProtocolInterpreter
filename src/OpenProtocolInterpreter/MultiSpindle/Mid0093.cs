namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Multi-spindle status unsubscribe
    /// <para>Reset the subscription for the multi-spindle status.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    /// Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    /// <see cref="Communication.Mid0004"/> Command error, Multi-spindle status subscription does not exist
    /// </para>
    /// </summary>
    public class Mid0093 : Mid, IMultiSpindle, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 93;

        public Mid0093() : base(MID, LAST_REVISION)
        {

        }

        public Mid0093(Header header) : base(header)
        {
        }
    }
}
