namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    /// <summary>
    /// Open Protocol commands disabled subscribe
    /// <para>
    ///     Set the subscription for the Open Protocol commands disable digital input. This command will result in
    ///     transmission of the Open Protocol commands disable input status.When a subscription is set the Open
    ///     Protocol commands disable digital input status is once uploaded(<see cref="Mid0421"/>) automatically.Thereafter,
    ///     the status is uploaded each time the digital input status changes(push function).
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///         <see cref="Communication.Mid0004"/> Command error, Open Protocol commands disabled
    ///         subscription already exists
    /// </para>
    /// </summary>
    public class Mid0420 : Mid, IOpenProtocolCommandsDisabled, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 420;

        public Mid0420() : this(false)
        {

        }

        public Mid0420(bool noAckFlag = false) : base(MID, LAST_REVISION, noAckFlag) { }
    }
}
