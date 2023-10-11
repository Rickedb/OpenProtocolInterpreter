using System.Text;

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

        public string Pack()
        {
            byte[] bytes = PackBytes();
            return Encoding.ASCII.GetString(bytes);
        }

        public byte[] PackBytes()
        {
            byte[] bytes = new byte[10];
            bytes[0] = OpenProtocolConvert.ToByte(
            [
                RundownAngleMaxShutOff,
                RundownAngleMinShutOff,
                TorqueMaxShutOff,
                AngleMaxShutOff,
                SelftapTorqueMaxShutOff,
                SelftapTorqueMinShutOff,
                PrevailTorqueMaxShutOff,
                PrevailTorqueMinShutOff
            ]);
            bytes[1] = OpenProtocolConvert.ToByte(
            [
                 PrevailTorqueCompensateOverflow ,
                 CurrentMonitoringMaxShutOff,
                 PostViewTorqueMinTorqueShutOff,
                 PostViewTorqueMaxTorqueShutOff,
                 PostViewTorqueAngleTooSmall,
                 TriggerLost,
                 TorqueLessThanTarget,
                 ToolHot
            ]);
            bytes[2] = OpenProtocolConvert.ToByte(
            [
                MultistageAbort,
                Rehit,
                DsMeasureFailed,
                CurrentLimitReached,
                EndTimeOutShutOff,
                RemoveFastenerLimitExceeded,
                DisableDrive,
                TransducerLost
            ]);
            bytes[3] = OpenProtocolConvert.ToByte(
            [
                TransducerShorted,
                TransducerCorrupt,
                SyncTimeout,
                DynamicCurrentMonitoringMin,
                DynamicCurrentMonitoringMax,
                AngleMaxMonitor,
                YieldNutOff,
                YieldTooFewSamples
            ]);

            var asciiLong = System.BitConverter.ToInt64(bytes, 0).ToString("D10");
            return Encoding.ASCII.GetBytes(asciiLong);
        }

        public static TighteningErrorStatus Parse(string value)
        {
            var longValue = OpenProtocolConvert.ToInt64(value);
            var bytes = System.BitConverter.GetBytes(longValue);
            return Parse(bytes);
        }

        public static TighteningErrorStatus Parse(byte[] value)
        {
            return new TighteningErrorStatus
            {
                //byte 0
                RundownAngleMaxShutOff = OpenProtocolConvert.GetBit(value[0], 1),
                RundownAngleMinShutOff = OpenProtocolConvert.GetBit(value[0], 2),
                TorqueMaxShutOff = OpenProtocolConvert.GetBit(value[0], 3),
                AngleMaxShutOff = OpenProtocolConvert.GetBit(value[0], 4),
                SelftapTorqueMaxShutOff = OpenProtocolConvert.GetBit(value[0], 5),
                SelftapTorqueMinShutOff = OpenProtocolConvert.GetBit(value[0], 6),
                PrevailTorqueMaxShutOff = OpenProtocolConvert.GetBit(value[0], 7),
                PrevailTorqueMinShutOff = OpenProtocolConvert.GetBit(value[0], 8),
                //byte 1
                PrevailTorqueCompensateOverflow = OpenProtocolConvert.GetBit(value[1], 1),
                CurrentMonitoringMaxShutOff = OpenProtocolConvert.GetBit(value[1], 2),
                PostViewTorqueMinTorqueShutOff = OpenProtocolConvert.GetBit(value[1], 3),
                PostViewTorqueMaxTorqueShutOff = OpenProtocolConvert.GetBit(value[1], 4),
                PostViewTorqueAngleTooSmall = OpenProtocolConvert.GetBit(value[1], 5),
                TriggerLost = OpenProtocolConvert.GetBit(value[1], 6),
                TorqueLessThanTarget = OpenProtocolConvert.GetBit(value[1], 7),
                ToolHot = OpenProtocolConvert.GetBit(value[1], 8),
                //byte 2
                MultistageAbort = OpenProtocolConvert.GetBit(value[2], 1),
                Rehit = OpenProtocolConvert.GetBit(value[2], 2),
                DsMeasureFailed = OpenProtocolConvert.GetBit(value[2], 3),
                CurrentLimitReached = OpenProtocolConvert.GetBit(value[2], 4),
                EndTimeOutShutOff = OpenProtocolConvert.GetBit(value[2], 5),
                RemoveFastenerLimitExceeded = OpenProtocolConvert.GetBit(value[2], 6),
                DisableDrive = OpenProtocolConvert.GetBit(value[2], 7),
                TransducerLost = OpenProtocolConvert.GetBit(value[2], 8),
                //byte 3
                TransducerShorted = OpenProtocolConvert.GetBit(value[3], 1),
                TransducerCorrupt = OpenProtocolConvert.GetBit(value[3], 2),
                SyncTimeout = OpenProtocolConvert.GetBit(value[3], 3),
                DynamicCurrentMonitoringMin = OpenProtocolConvert.GetBit(value[3], 4),
                DynamicCurrentMonitoringMax = OpenProtocolConvert.GetBit(value[3], 5),
                AngleMaxMonitor = OpenProtocolConvert.GetBit(value[3], 6),
                YieldNutOff = OpenProtocolConvert.GetBit(value[3], 7),
                YieldTooFewSamples = OpenProtocolConvert.GetBit(value[3], 8)
            };
        }
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

        public TighteningErrorStatus2()
        {
            Reserved = new byte[10];
        }
        public string Pack()
        {
            byte[] bytes = PackBytes();
            return Encoding.ASCII.GetString(bytes);
        }

        public byte[] PackBytes()
        {
            byte[] bytes =
            [
                OpenProtocolConvert.ToByte(
                [
                    DriveDeactivated,
                    ToolStall,
                    DriveHot,
                    GradientMonitoringHigh,
                    GradientMonitoringLow,
                    ReactionBarFailed,
                    SnugMax,
                    CycleAbort,
                ]),
                OpenProtocolConvert.ToByte(
                [
                    NeckingFailure,
                    EffectiveLoosening,
                    OverSpeed,
                    NoResidualTorque,
                    PositioningFail,
                    SnugMonLow,
                    SnugMonHigh,
                    DynamicMinCurrent,
                ]),
                OpenProtocolConvert.ToByte(
                [
                    DynamicMaxCurrent,
                    LatentResult,
                    OpenProtocolConvert.GetBit(Reserved[2], 3),
                    OpenProtocolConvert.GetBit(Reserved[2], 4),
                    OpenProtocolConvert.GetBit(Reserved[2], 5),
                    OpenProtocolConvert.GetBit(Reserved[2], 6),
                    OpenProtocolConvert.GetBit(Reserved[2], 7),
                    OpenProtocolConvert.GetBit(Reserved[2], 8)
                ]),
                Reserved[3],
                Reserved[4],
                Reserved[5],
                Reserved[6],
                Reserved[7],
                Reserved[8],
                Reserved[9]
            ];

            var asciiLong = System.BitConverter.ToInt64(bytes, 0).ToString().PadLeft(10, '0');
            return Encoding.ASCII.GetBytes(asciiLong);
        }

        public static TighteningErrorStatus2 Parse(string value)
        {
            var longValue = OpenProtocolConvert.ToInt64(value);
            var bytes = System.BitConverter.GetBytes(longValue);
            return Parse(bytes);
        }

        public static TighteningErrorStatus2 Parse(byte[] value)
        {
            var obj = new TighteningErrorStatus2()
            {
                //byte 0
                DriveDeactivated = OpenProtocolConvert.GetBit(value[0], 1),
                ToolStall = OpenProtocolConvert.GetBit(value[0], 2),
                DriveHot = OpenProtocolConvert.GetBit(value[0], 3),
                GradientMonitoringHigh = OpenProtocolConvert.GetBit(value[0], 4),
                GradientMonitoringLow = OpenProtocolConvert.GetBit(value[0], 5),
                ReactionBarFailed = OpenProtocolConvert.GetBit(value[0], 6),
                SnugMax = OpenProtocolConvert.GetBit(value[0], 7),
                CycleAbort = OpenProtocolConvert.GetBit(value[0], 8),
                //byte 1
                NeckingFailure = OpenProtocolConvert.GetBit(value[1], 1),
                EffectiveLoosening = OpenProtocolConvert.GetBit(value[1], 2),
                OverSpeed = OpenProtocolConvert.GetBit(value[1], 3),
                NoResidualTorque = OpenProtocolConvert.GetBit(value[1], 4),
                PositioningFail = OpenProtocolConvert.GetBit(value[1], 5),
                SnugMonLow = OpenProtocolConvert.GetBit(value[1], 6),
                SnugMonHigh = OpenProtocolConvert.GetBit(value[1], 7),
                DynamicMinCurrent = OpenProtocolConvert.GetBit(value[1], 8),
                //byte 2
                DynamicMaxCurrent = OpenProtocolConvert.GetBit(value[2], 1),
                LatentResult = OpenProtocolConvert.GetBit(value[2], 2),
                Reserved = new byte[10]
            };

            //set only 19 and 20 bytes to reserved
            obj.Reserved[0] = OpenProtocolConvert.ToByte([OpenProtocolConvert.GetBit(value[2], 3), OpenProtocolConvert.GetBit(value[2], 4), false, false, false, false, false, false]);

            return obj;
        }
    }
}
