namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// Reset latest Identifier
    /// <para>
    ///    This message is used by the integrator to reset the latest identifier 
    ///    or bypassed identifier in the work order.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0156 : Mid, IMultipleIdentifier, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 156;

        public Mid0156() : base(MID, LAST_REVISION) 
        { 
        }

        public Mid0156(Header header) : base(header)
        {
        }
    }
}
