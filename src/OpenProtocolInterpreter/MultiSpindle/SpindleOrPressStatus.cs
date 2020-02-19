namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Represents a Spindle or a Press status entity, depending on <see cref="SystemSubType"/>
    /// </summary>
    public class SpindleOrPressStatus
    {
        public int SpindleOrPressNumber { get; set; }
        public int ChannelId { get; set; }
        public bool OverallStatus { get; set; }
        public TighteningValueStatus TorqueOrForceStatus { get; set; }
        public decimal TorqueOrForce { get; set; }
        public bool AngleOrStrokeStatus { get; set; }
        public int AngleOrStroke { get; set; }
    }
}
