namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Represents a Strategy Options entity
    /// </summary>
    public class StrategyOptions
    {
        //Byte 0
        public bool Torque { get; set; }
        public bool Angle { get; set; }
        public bool Batch { get; set; }
        public bool PvtMonitoring { get; set; }
        public bool PvtCompensate { get; set; }
        public bool Selftap { get; set; }
        public bool Rundown { get; set; }
        public bool CM { get; set; }
        //Byte 1
        public bool DsControl { get; set; }
        public bool ClickWrench { get; set; }
        public bool RbwMonitoring { get; set; }
    }
}
