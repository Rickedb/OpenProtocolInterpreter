using OpenProtocolInterpreter.Tightening;

namespace OpenProtocolInterpreter.Converters
{
    internal class TighteningErrorStatusConverter : BitConverter, IValueConverter<TighteningErrorStatus>
    {
        private readonly IValueConverter<byte[]> _byteArrayConverter;

        public TighteningErrorStatusConverter(IValueConverter<byte[]> byteArrayConverter)
        {
            _byteArrayConverter = byteArrayConverter;
        }

        public TighteningErrorStatus Convert(string value)
        {
            var bytes = _byteArrayConverter.Convert(value);
            return new TighteningErrorStatus
            {
                //byte 0
                RundownAngleMaxShutOff = GetBit(bytes[0], 1),
                RundownAngleMinShutOff = GetBit(bytes[0], 2),
                TorqueMaxShutOff = GetBit(bytes[0], 3),
                AngleMaxShutOff = GetBit(bytes[0], 4),
                SelftapTorqueMaxShutOff = GetBit(bytes[0], 5),
                SelftapTorqueMinShutOff = GetBit(bytes[0], 6),
                PrevailTorqueMaxShutOff = GetBit(bytes[0], 7),
                PrevailTorqueMinShutOff = GetBit(bytes[0], 8),
                //byte 1
                PrevailTorqueCompensateOverflow = GetBit(bytes[1], 1),
                CurrentMonitoringMaxShutOff = GetBit(bytes[1], 2),
                PostViewTorqueMinTorqueShutOff = GetBit(bytes[1], 3),
                PostViewTorqueMaxTorqueShutOff = GetBit(bytes[1], 4),
                PostViewTorqueAngleTooSmall = GetBit(bytes[1], 5),
                TriggerLost = GetBit(bytes[1], 6),
                TorqueLessThanTarget = GetBit(bytes[1], 7),
                ToolHot = GetBit(bytes[1], 8),
                //byte 2
                MultistageAbort = GetBit(bytes[2], 1),
                Rehit = GetBit(bytes[2], 2),
                DsMeasureFailed = GetBit(bytes[2], 3),
                CurrentLimitReached = GetBit(bytes[2], 4),
                EndTimeOutShutOff = GetBit(bytes[2], 5),
                RemoveFastenerLimitExceeded = GetBit(bytes[2], 6),
                DisableDrive = GetBit(bytes[2], 7),
                TransducerLost = GetBit(bytes[2], 8),
                //byte 3
                TransducerShorted = GetBit(bytes[3], 1),
                TransducerCorrupt = GetBit(bytes[3], 2),
                SyncTimeout = GetBit(bytes[3], 3),
                DynamicCurrentMonitoringMin = GetBit(bytes[3], 4),
                DynamicCurrentMonitoringMax = GetBit(bytes[3], 5),
                AngleMaxMonitor = GetBit(bytes[3], 6),
                YieldNutOff = GetBit(bytes[3], 7),
                YieldTooFewSamples = GetBit(bytes[3], 8)
            };
        }

        public string Convert(TighteningErrorStatus value)
        {
            byte[] bytes = new byte[10];
            bytes[0] = SetByte(new bool[]
            {
                value.RundownAngleMaxShutOff,
                value.RundownAngleMinShutOff,
                value.TorqueMaxShutOff,
                value.AngleMaxShutOff,
                value.SelftapTorqueMaxShutOff,
                value.SelftapTorqueMinShutOff,
                value.PrevailTorqueMaxShutOff,
                value.PrevailTorqueMinShutOff
            });
            bytes[1] = SetByte(new bool[]
            {
                 value.PrevailTorqueCompensateOverflow ,
                 value.CurrentMonitoringMaxShutOff,
                 value.PostViewTorqueMinTorqueShutOff,
                 value.PostViewTorqueMaxTorqueShutOff,
                 value.PostViewTorqueAngleTooSmall,
                 value.TriggerLost,
                 value.TorqueLessThanTarget,
                 value.ToolHot
            });
            bytes[2] = SetByte(new bool[]
            {
                value.MultistageAbort,
                value.Rehit,
                value.DsMeasureFailed,
                value.CurrentLimitReached,
                value.EndTimeOutShutOff,
                value.RemoveFastenerLimitExceeded,
                value.DisableDrive,
                value.TransducerLost
            });
            bytes[3] = SetByte(new bool[]
            {
                value.TransducerShorted,
                value.TransducerCorrupt,
                value.SyncTimeout,
                value.DynamicCurrentMonitoringMin,
                value.DynamicCurrentMonitoringMax,
                value.AngleMaxMonitor,
                value.YieldNutOff,
                value.YieldTooFewSamples
            });
            bytes[4] = bytes[5] = bytes[6] = bytes[7] = bytes[8] = bytes[9] = 0;

            return _byteArrayConverter.Convert(bytes);
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, TighteningErrorStatus value) => Convert(value);
    }
    internal class TighteningErrorStatus2Converter : BitConverter, IValueConverter<TighteningErrorStatus2>
    {
        private readonly IValueConverter<byte[]> _byteArrayConverter;

        public TighteningErrorStatus2Converter(IValueConverter<byte[]> byteArrayConverter)
        {
            _byteArrayConverter = byteArrayConverter;
        }

        public TighteningErrorStatus2 Convert(string value)
        {
            var bytes = _byteArrayConverter.Convert(value);
            var obj = new TighteningErrorStatus2()
            {
                DriveDeactivated = GetBit(bytes[0], 1),
                ToolStall = GetBit(bytes[0], 2),
                DriveHot = GetBit(bytes[0], 3),
                GradientMonitoringHigh = GetBit(bytes[0], 4),
                GradientMonitoringLow = GetBit(bytes[0], 5),
                ReactionBarFailed = GetBit(bytes[0], 6),
                Reserved = bytes
            };

            //set only 7 and 8 bytes to reserved
            obj.Reserved[0] = SetByte(new bool[] { false, false, false, false, false, false, GetBit(bytes[0], 7), GetBit(bytes[0], 8) });

            return obj;
        }

        public string Convert(TighteningErrorStatus2 value)
        {
            byte[] bytes = new byte[10];
            bytes[0] = SetByte(new bool[]
            {
                value.DriveDeactivated,
                value.ToolStall,
                value.DriveHot,
                value.GradientMonitoringHigh,
                value.GradientMonitoringLow,
                value.ReactionBarFailed,
                GetBit(value.Reserved[0], 7),
                GetBit(value.Reserved[0], 8)
            });
            bytes[1] = bytes[2] = bytes[3] = bytes[4] = bytes[5] = bytes[6] = bytes[7] = bytes[8] = bytes[9] = 0;

            return _byteArrayConverter.Convert(bytes);
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, TighteningErrorStatus2 value) => Convert(value);
    }
}
