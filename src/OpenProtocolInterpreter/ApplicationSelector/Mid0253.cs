namespace OpenProtocolInterpreter.ApplicationSelector
{
    /// <summary>
    /// Selector socket info unsubscribe
    /// <para>Unsubscribe for the selector socket info. The subscription is reset for all selector devices.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, The selector socket info subscription does not exist</para>
    /// </summary>
    public class Mid0253 : Mid, IApplicationSelector, IIntegrator
    {
        public const int MID = 253;
        private const int LAST_REVISION = 1;

        public Mid0253() : base(MID, LAST_REVISION) { }
    }
}
