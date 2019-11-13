namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Status externally monitored inputs subscribe
    /// Description: 
    ///     By using this message the integrator can set a subscription to monitor the status 
    ///     for the eight externally monitored digital inputs. After the subscription the station 
    ///     will directly receive a status message and then every time the status of at least one of 
    ///     the inputs has changed.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    /// MID 0004 Command error, 
    /// Status externally monitored inputs subscription already exists or 
    /// MID 0211 Status externally monitored inputs.
    /// </summary>
    public class Mid0210 : Mid, IIOInterface, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 210;

        public Mid0210() : this(0)
        {

        }

        public Mid0210(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag) { }
    }
}
