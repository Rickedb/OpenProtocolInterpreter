namespace OpenProtocolInterpreter.Vin
{
    /// <summary>
    /// Vehicle ID Number unsubscribe
    /// <para>Reset the subscription for the current tightening identifiers.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///             <see cref="Communication.Mid0004"/> Command error, VIN subscription does not exist
    /// </para>
    /// </summary>
    public class Mid0054 : Mid, IVin, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 54;

        public Mid0054() : this(LAST_REVISION)
        {

        }

        public Mid0054(int revision = LAST_REVISION) : base(MID, revision)
        {

        }

        public Mid0054(Header header) : base(header)
        {
        }
    }
}
