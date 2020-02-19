namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Lock at batch done unsubscribe
    /// <para>Reset the subscription for Lock at batch done.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///     <see cref="Communication.Mid0004"/> Command error
    /// </para>
    /// </summary>
    public class Mid0024 : Mid, IParameterSet, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 24;

        public Mid0024() : base(MID, LAST_REVISION) { }
    }
}
