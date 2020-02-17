namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// User data acknowledge
    /// <para>Acknowledgement of user data.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0243 : Mid, IPLCUserData, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 243;

        public Mid0243() : base(MID, LAST_REVISION) { }
    }
}
