namespace OpenProtocolInterpreter.Emulator.AutomaticControllers
{
    internal class ControllerConfiguration
    {
        public string ControllerName { get; set; }
        public int Port { get; set; }
        public Strategy TighteningStrategy { get; set; }
        public Strategy JobStrategy { get; set; }
        public int TotalTightenings { get; set; }
        public int MinTighteningDelay { get; set; }
        public int MaxTighteningDelay { get; set; }
        public bool Enabled { get; set; }
    }

    internal enum Strategy
    {
        Random,
        OnlyOk,
        OnlyNok
    }
}
