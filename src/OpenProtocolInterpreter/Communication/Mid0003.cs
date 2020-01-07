namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// Application Communication stop
    /// <para>
    ///     This message disables the communication. The controller will stop to respond to any commands
    ///     except for <see cref="Mid0001"/> Communication start after receiving this command.
    /// </para>    
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0003 : Mid, ICommunication, IController
    {
        private const int LAST_REVISION = 1;
        public const int MID = 3;

        public Mid0003() : base(MID, LAST_REVISION) { }
    }
}
