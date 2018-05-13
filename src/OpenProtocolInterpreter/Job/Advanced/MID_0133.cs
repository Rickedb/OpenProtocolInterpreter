namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Set Job line alert 2
    /// Description: The integrator can set the line control alert 2 in the controller with this message.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0133 : Mid, IAdvancedJob
    {
        private const int LAST_REVISION = 1;
        public const int MID = 133;

        public MID_0133() : base(MID, LAST_REVISION) { }

        internal MID_0133(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
