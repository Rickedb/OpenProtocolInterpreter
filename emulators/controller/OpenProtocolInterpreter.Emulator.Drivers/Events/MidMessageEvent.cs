namespace OpenProtocolInterpreter.Emulator.Drivers.Events
{
    public struct MidMessageEvent
    {
        public AtlasCopcoControllerDriver Driver { get; set; }
        public string ClientIpPort { get; set; }
        public int ServerPort { get; set; }
        public Mid Mid { get; set; }
    }
}
