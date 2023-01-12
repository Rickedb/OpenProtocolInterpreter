namespace OpenProtocolInterpreter.ApplicationSelector
{
    /// <summary>
    /// Selector socket info acknowledge
    /// <para>Acknowledgement of the <see cref="Mid0251"/> Selector socket info.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0252 : Mid, IApplicationSelector, IIntegrator, IAcknowledge
    {
        private const int LAST_REVISION = 1;
        public const int MID = 252;
        
        public Mid0252() : base(MID, LAST_REVISION) { }

        public Mid0252(Header header) : base(header)
        {

        }
    }
}
