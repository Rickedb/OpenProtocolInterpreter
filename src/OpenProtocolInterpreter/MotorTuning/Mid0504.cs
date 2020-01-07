namespace OpenProtocolInterpreter.MotorTuning
{
    /// <summary>
    /// Motor tuning request
    /// <para>Request the start of the motor tuning.</para>
    /// <para>Warning!: This command must be implemented during hard restrictions and customer dependent requirements.</para>    
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Tool motor tuning failed</para>
    /// </summary>
    public class Mid0504 : Mid, IMotorTuning, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 504;

        public Mid0504() : base(MID, LAST_REVISION) { }
    }
}
