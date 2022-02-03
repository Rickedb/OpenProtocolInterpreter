namespace OpenProtocolInterpreter.Emulator.Controller.Events
{
    public struct MidMessageEvent
    {
        public string ClientIpPort { get; set; }
        public Mid Mid { get; set; }
    }
}
