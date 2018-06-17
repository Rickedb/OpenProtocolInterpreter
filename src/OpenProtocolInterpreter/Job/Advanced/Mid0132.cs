namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Set Job line alert 1
    /// Description: The integrator can set the line control alert 1 in the controller with this message.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class Mid0132 : Mid, IAdvancedJob
    {
        private const int LAST_REVISION = 1;
        public const int MID = 132;

        public Mid0132() : base(MID, LAST_REVISION) { }

        internal Mid0132(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
