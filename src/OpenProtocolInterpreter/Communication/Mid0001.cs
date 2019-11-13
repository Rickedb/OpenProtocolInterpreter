namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// <para>Application communication start</para>
    /// <para>This message enables the communication. The controller does not respond to any other command
    ///     before this</para>
    /// <para>Message sent by Integrator</para>
    /// <para>Answers:</para> 
    /// <para>- MID 0002 Communication start acknowledge</para> 
    /// <para>- MID 0004 Command error: Client already connected or MID revision unsupported</para>
    /// </summary>
    public class Mid0001 : Mid, ICommunication, IIntegrator
    {
        private const int LAST_REVISION = 5;
        public const int MID = 1;

        public Mid0001() : this(LAST_REVISION)
        {

        }

        public Mid0001(int revision = LAST_REVISION) : base(MID, revision) { }
    }
}
