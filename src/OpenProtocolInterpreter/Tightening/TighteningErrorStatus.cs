namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Represents a Tightening Error Status entity
    /// </summary>
    public class TighteningErrorStatus
    {
        //Byte 0
        public bool RundownAngleMaxShutOff { get; set; }
        public bool RundownAngleMinShutOff { get; set; }
        public bool TorqueMaxShutOff { get; set; }
        public bool AngleMaxShutOff { get; set; }
        public bool SelftapTorqueMaxShutOff { get; set; }
        public bool SelftapTorqueMinShutOff { get; set; }
        public bool PrevailTorqueMaxShutOff { get; set; }
        public bool PrevailTorqueMinShutOff { get; set; }
        //Byte 1
        public bool PrevailTorqueCompensateOverflow { get; set; }
        public bool CurrentMonitoringMaxShutOff { get; set; }
        public bool PostViewTorqueMinTorqueShutOff { get; set; }
        public bool PostViewTorqueMaxTorqueShutOff { get; set; }
        public bool PostViewTorqueAngleTooSmall { get; set; }
        public bool TriggerLost { get; set; }
        public bool TorqueLessThanTarget { get; set; }
        public bool ToolHot { get; set; }
        //Byte 2
        public bool MultistageAbort { get; set; }
        public bool Rehit { get; set; }
        public bool DsMeasureFailed { get; set; }
        public bool CurrentLimitReached { get; set; }
        public bool EndTimeOutShutOff { get; set; }
        public bool RemoveFastenerLimitExceeded { get; set; }
        public bool DisableDrive { get; set; }
        public bool TransducerLost { get; set; }
        //Byte 3
        public bool TransducerShorted { get; set; }
        public bool TransducerCorrupt { get; set; }
        public bool SyncTimeout { get; set; }
        public bool DynamicCurrentMonitoringMin { get; set; }
        public bool DynamicCurrentMonitoringMax { get; set; }
        public bool AngleMaxMonitor { get; set; }
        public bool YieldNutOff { get; set; }
        public bool YieldTooFewSamples { get; set; }
    }

    public class TighteningErrorStatus2
    {
        public bool DriveDeactivated { get; set; }
        public bool ToolStall { get; set; }
        public bool DriveHot { get; set; }
        public bool GradientMonitoringHigh { get; set; }
        public bool GradientMonitoringLow { get; set; }
        public bool ReactionBarFailed { get; set; }
        public bool SnugMax { get; set; }
        public bool CycleAbort { get; set; }
        public bool NeckingFailure { get; set; }
        public bool EffectiveLoosening { get; set; }
        public bool OverSpeed { get; set; }
        public bool NoResidualTorque { get; set; }
        public bool PositioningFail { get; set; }
        public bool SnugMonLow { get; set; }
        public bool SnugMonHigh { get; set; }
        public bool DynamicMinCurrent { get; set; }
        public bool DynamicMaxCurrent { get; set; }
        public bool LatentResult { get; set; }

        //Bit 19-31
        public byte[] Reserved { get; set; }
    }
}
