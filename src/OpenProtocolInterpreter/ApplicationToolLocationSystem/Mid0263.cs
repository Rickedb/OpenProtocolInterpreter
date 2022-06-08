namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// Tool tag ID acknowledge
    /// <para>Acknowledgement of <see cref="Mid0262"/> Tool tag ID.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0263 : Mid, IApplicationToolLocationSystem, IIntegrator, IAcknowledge
    {
        private const int LAST_REVISION = 1;
        public const int MID = 263;

        public Mid0263() : base(MID, LAST_REVISION) { }

        public Mid0263(Header header) : base(header)
        {

        }
    }
}
