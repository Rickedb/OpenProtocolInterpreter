namespace OpenProtocolInterpreter.UserInterface
{
    /// <summary>
    /// Flash green light on tool
    /// <para>
    ///     By sending this message the integrator can make the green light on the tool flash. 
    ///     The light on the tool will flash until the operator pushes the tool trigger.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0113 : Mid, IUserInterface, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 113;

        public Mid0113() : base(MID, LAST_REVISION)
        {

        }
    }
}
