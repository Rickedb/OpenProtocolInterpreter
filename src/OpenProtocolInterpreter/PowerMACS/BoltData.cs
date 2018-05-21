namespace OpenProtocolInterpreter.PowerMACS
{
    public class BoltData
    {
        public int OrdinalBoltNumber { get; set; }
        public bool SimpleBoltStatus { get; set; }
        public TorqueStatus TorqueStatus { get; set; }
        public AngleStatus AngleStatus { get; set; }
        public decimal BoltTorque { get; set; }
        public decimal BoltAngle { get; set; }
        public decimal BoltTorqueHighLimit { get; set; }
        public decimal BoltTorqueLowLimit { get; set; }
        public decimal BoltAngleHighLimit { get; set; }
        public decimal BoltAngleLowLimit { get; set; }
    }
}
