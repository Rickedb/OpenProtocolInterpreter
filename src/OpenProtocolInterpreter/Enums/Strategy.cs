namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Strategies. Used in <see cref="Tightening.Mid0061"/> and <see cref="Tightening.Mid0065"/>.
    /// </summary>
    public enum Strategy
    {
        TorqueControl = 1,
        TorqueControlAndAngleMonitoring = 2,
        TorqueControlAndAngleControl = 3,
        AngleControlAndTorqueMonitoring = 4,
        DSControl = 5,
        DSControlTorqueMonitoring = 6,
        ReverseAngle = 7,
        ReverseTorque = 8,
        ClickWrench = 9,
        RotateSpindleForward = 10,
        TorqueControlOrAngleControle = 11,
        RotateSpindleReverse = 12,
        HomePositionForward = 13,
        EPMonitoring = 14,
        Yield = 15,
        EPFixed = 16,
        EPControl = 17,
        EPAngleShutoff = 18,
        YieldOrTorqueControl = 19,
        SnugGradient = 20,
        ResidualTorqueAndTime = 21,
        ResidualAngleAndTime = 22,
        BreakawayPeak = 23,
        LoosAndTightening= 24,
        HomePositionReverse = 25,
        PVTCompWithSnug = 26,
        NoStrategy = 99
    }
}
