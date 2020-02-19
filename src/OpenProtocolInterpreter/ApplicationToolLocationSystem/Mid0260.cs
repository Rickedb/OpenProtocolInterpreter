namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// Tool tag ID request
    /// <para>Used by the integrator to request Tool tag ID information.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0262"/> Tool tag ID or <see cref="Communication.Mid0004"/> Command error, Tool tag ID unknown or MID revision unsupported.</para>
    /// </summary>
    public class Mid0260 : Mid, IApplicationToolLocationSystem, IController
    {
        private const int LAST_REVISION = 1;
        public const int MID = 260;

        public Mid0260() : base(MID, LAST_REVISION) { }

    }
}
