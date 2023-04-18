namespace OpenProtocolInterpreter.KeepAlive
{
    /// <summary>
    /// Keep alive message
    /// <para>
    ///   The integrator sends a keep alive to the controller. The controller should only mirror and return the 
    ///   received keep alive to the integrator.
    /// </para>
    /// <para>
    ///   The controller has a communication timeout equal to 15s. This means that if no message has been 
    ///   exchanged between the integrator and the controller for the last 15s, then the controller considers 
    ///   the connection lost and closes it;
    /// </para>
    /// <para>
    ///   In order to keep the communication alive the integrator must send a keep alive to the controller with a
    ///   time interval lower than 15s.
    /// </para>
    /// <para>
    ///   Note: An inactivity timeout is suggested to integrator i.e. if no message has been exchanged (sent or 
    ///   received) during the last 10s, send a keep alive.
    /// </para>  
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: The same message (<see cref="Mid9999"/>) mirrored by the controller.</para>
    /// </summary>
    public class Mid9999 : Mid, IIntegrator, IController
    {
        protected new const int DEFAULT_REVISION = 0;
        public const int MID = 9999;

        public Mid9999() : base(MID, DEFAULT_REVISION) { }

        public Mid9999(Header header) : base(header)
        {
        }
    }
}
