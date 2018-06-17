namespace OpenProtocolInterpreter.UserInterface
{
    /// <summary>
    /// MID: Flash green light on tool
    /// Description: 
    ///     By sending this message the integrator can make the green light on the tool flash. The light on the tool
    ///     will flash until the operator pushes the tool trigger.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class Mid0113 : Mid, IUserInterface
    {
        private const int LAST_REVISION = 1;
        public const int MID = 113;

        public Mid0113() : base(MID, LAST_REVISION)
        {

        }

        internal Mid0113(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

    }
}
