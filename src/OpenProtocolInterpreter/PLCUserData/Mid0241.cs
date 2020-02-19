namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// User data subscribe
    /// <para>
    ///     Subscribe for user data. This command will activate the <see cref="Mid0242"/> User data message to be sent when a
    ///     change in the user data output has been detected.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///         <see cref="Communication.Mid0004"/> Command error, Subscription already exists, or
    ///         Controller is not a sync master/station controller
    /// </para>
    /// </summary>
    public class Mid0241 : Mid, IPLCUserData, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 241;

        public Mid0241() : this(0)
        {

        }

        public Mid0241(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag) { }
    }
}