namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Last tightening result data unsubscribe
    /// <para>Reset the last tightening result subscription.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///             <see cref="Communication.Mid0004"/> Command error, Last tightening result subscription does not exist
    /// </para>
    /// </summary>
    public class Mid0063 : Mid, ITightening, IIntegrator
    {
        private const int LAST_REVISION = 6;
        public const int MID = 63;

        public Mid0063() : this(LAST_REVISION)
        {

        }

        public Mid0063(int revision = LAST_REVISION) : base(MID, revision)
        {

        }

        public Mid0063(Header header) : base(header)
        {
        }
    }
}
