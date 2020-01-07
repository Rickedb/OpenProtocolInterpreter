namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Status externally monitored inputs unsubscribe
    /// <para>Unsubscribe for the <see cref="Mid0211"/> Status externally monitored inputs.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, 
    ///             Status externally monitored inputs subscription does not exist
    /// </para>
    /// </summary>
    public class Mid0213 : Mid, IIOInterface, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 213;

        public Mid0213() : base(MID, LAST_REVISION) { }
    }
}
