namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    /// <summary>
    /// MID: Open Protocol commands disabled subscribe
    /// Description: 
    ///     Set the subscription for the Open Protocol commands disable digital input. This command will result in
    ///     transmission of the Open Protocol commands disable input status.When a subscription is set the Open
    ///     Protocol commands disable digital input status is once uploaded(MID 0421) automatically.Thereafter,
    ///     the status is uploaded each time the digital input status changes(push function).
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    ///         MID 0004 Command error, Open Protocol commands disabled
    ///         subscription already exists
    /// </summary>
    public class Mid0420 : Mid, IOpenProtocolCommandsDisabled, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 420;

        public Mid0420() : this(0)
        {

        }

        public Mid0420(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag) { }
    }
}
