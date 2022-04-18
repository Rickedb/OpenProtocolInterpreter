namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// Tool tag ID subscribe
    /// <para>Used by the integrator to order a Tool tag ID subscription from the controller.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0262"/> Tool tag ID or <see cref="Communication.Mid0004"/> Command error, Tool tag ID unknown, Tool tag ID subscription already exist or MID revision unsupported.</para>
    /// </summary>
    public class Mid0261 : Mid, IApplicationToolLocationSystem, IController
    {
        private const int LAST_REVISION = 1;
        public const int MID = 261;

        public Mid0261() : this(false)
        {

        }

        public Mid0261(bool noAckFlag = false) : base(MID, LAST_REVISION, noAckFlag) { }
    }
}
