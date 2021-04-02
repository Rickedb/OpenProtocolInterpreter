using OpenProtocolInterpreter.Tightening;

namespace OpenProtocolInterpreter.Converters
{
    public class TighteningErrorStatusConverter : BitConverter, IValueConverter<TighteningErrorStatus>
    {
        private readonly IValueConverter<byte[]> _byteArrayConverter;

        public TighteningErrorStatusConverter(IValueConverter<byte[]> byteArrayConverter)
        {
            _byteArrayConverter = byteArrayConverter;
        }

        public TighteningErrorStatus Convert(string value)
        {
            var bytes = _byteArrayConverter.Convert(value);
            return ConvertFromBytes(bytes);
        }

        public string Convert(TighteningErrorStatus value)
        {
            byte[] bytes = ConvertToBytes(value);
            return _byteArrayConverter.Convert(bytes);
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, TighteningErrorStatus value) => Convert(value);

        public TighteningErrorStatus ConvertFromBytes(byte[] value)
        {
            return new TighteningErrorStatus
            {
                //byte 0
                RundownAngleMaxShutOff = GetBit(value[0], 1),
                RundownAngleMinShutOff = GetBit(value[0], 2),
                TorqueMaxShutOff = GetBit(value[0], 3),
                AngleMaxShutOff = GetBit(value[0], 4),
                SelftapTorqueMaxShutOff = GetBit(value[0], 5),
                SelftapTorqueMinShutOff = GetBit(value[0], 6),
                PrevailTorqueMaxShutOff = GetBit(value[0], 7),
                PrevailTorqueMinShutOff = GetBit(value[0], 8),
                //byte 1
                PrevailTorqueCompensateOverflow = GetBit(value[1], 1),
                CurrentMonitoringMaxShutOff = GetBit(value[1], 2),
                PostViewTorqueMinTorqueShutOff = GetBit(value[1], 3),
                PostViewTorqueMaxTorqueShutOff = GetBit(value[1], 4),
                PostViewTorqueAngleTooSmall = GetBit(value[1], 5),
                TriggerLost = GetBit(value[1], 6),
                TorqueLessThanTarget = GetBit(value[1], 7),
                ToolHot = GetBit(value[1], 8),
                //byte 2
                MultistageAbort = GetBit(value[2], 1),
                Rehit = GetBit(value[2], 2),
                DsMeasureFailed = GetBit(value[2], 3),
                CurrentLimitReached = GetBit(value[2], 4),
                EndTimeOutShutOff = GetBit(value[2], 5),
                RemoveFastenerLimitExceeded = GetBit(value[2], 6),
                DisableDrive = GetBit(value[2], 7),
                TransducerLost = GetBit(value[2], 8),
                //byte 3
                TransducerShorted = GetBit(value[3], 1),
                TransducerCorrupt = GetBit(value[3], 2),
                SyncTimeout = GetBit(value[3], 3),
                DynamicCurrentMonitoringMin = GetBit(value[3], 4),
                DynamicCurrentMonitoringMax = GetBit(value[3], 5),
                AngleMaxMonitor = GetBit(value[3], 6),
                YieldNutOff = GetBit(value[3], 7),
                YieldTooFewSamples = GetBit(value[3], 8)
            };
        }

        public byte[] ConvertToBytes(TighteningErrorStatus value)
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

            return bytes;
        }

        public byte[] ConvertToBytes(char paddingChar, int size, DataField.PaddingOrientations orientation, TighteningErrorStatus value) => ConvertToBytes(value);
    }

    public class TighteningErrorStatus2Converter : BitConverter, IValueConverter<TighteningErrorStatus2>
    {
        private readonly IValueConverter<byte[]> _byteArrayConverter;

        public TighteningErrorStatus2Converter(IValueConverter<byte[]> byteArrayConverter)
        {
            _byteArrayConverter = byteArrayConverter;
        }

        public TighteningErrorStatus2 Convert(string value)
        {
            var bytes = _byteArrayConverter.Convert(value);
            return ConvertFromBytes(bytes);
        }

        public string Convert(TighteningErrorStatus2 value)
        {
            byte[] bytes = ConvertToBytes(value);
            return _byteArrayConverter.Convert(bytes);
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, TighteningErrorStatus2 value) => Convert(value);

        public TighteningErrorStatus2 ConvertFromBytes(byte[] value)
        {
            var obj = new TighteningErrorStatus2()
            {
                //byte 0
                DriveDeactivated = GetBit(value[0], 1),
                ToolStall = GetBit(value[0], 2),
                DriveHot = GetBit(value[0], 3),
                GradientMonitoringHigh = GetBit(value[0], 4),
                GradientMonitoringLow = GetBit(value[0], 5),
                ReactionBarFailed = GetBit(value[0], 6),
                SnugMax = GetBit(value[0], 7),
                CycleAbort = GetBit(value[0], 8),
                //byte 1
                NeckingFailure = GetBit(value[1], 1),
                EffectiveLoosening = GetBit(value[1], 2),
                OverSpeed = GetBit(value[1], 3),
                NoResidualTorque = GetBit(value[1], 4),
                PositioningFail = GetBit(value[1], 5),
                SnugMonLow = GetBit(value[1], 6),
                SnugMonHigh = GetBit(value[1], 7),
                DynamicMinCurrent = GetBit(value[1], 8),
                //byte 2
                DynamicMaxCurrent = GetBit(value[2], 1),
                LatentResult = GetBit(value[2], 2),
                Reserved = new byte[10]
            };

            //set only 19 and 20 bytes to reserved
            obj.Reserved[0] = SetByte(new bool[] { GetBit(value[2], 3), GetBit(value[2], 4), false, false, false, false, false, false });

            return obj;
        }

        public byte[] ConvertToBytes(TighteningErrorStatus2 value)
        {
            byte[] bytes = new byte[]
            {
                SetByte(new bool[]
                {
                    value.DriveDeactivated,
                    value.ToolStall,
                    value.DriveHot,
                    value.GradientMonitoringHigh,
                    value.GradientMonitoringLow,
                    value.ReactionBarFailed,
                    value.SnugMax,
                    value.CycleAbort,
                }),
                SetByte(new bool[]
                {
                    value.NeckingFailure,
                    value.EffectiveLoosening,
                    value.OverSpeed,
                    value.NoResidualTorque,
                    value.PositioningFail,
                    value.SnugMonLow,
                    value.SnugMonHigh,
                    value.DynamicMinCurrent,
                }),
                SetByte(new bool[]
                {
                    value.DynamicMaxCurrent,
                    value.LatentResult,
                    GetBit(value.Reserved[2], 3),
                    GetBit(value.Reserved[2], 4),
                    GetBit(value.Reserved[2], 5),
                    GetBit(value.Reserved[2], 6),
                    GetBit(value.Reserved[2], 7),
                    GetBit(value.Reserved[2], 8)
                }),
                value.Reserved[3],
                value.Reserved[4],
                value.Reserved[5],
                value.Reserved[6],
                value.Reserved[7],
                value.Reserved[8],
                value.Reserved[9]
            };

            return bytes;
        }

        public byte[] ConvertToBytes(char paddingChar, int size, DataField.PaddingOrientations orientation, TighteningErrorStatus2 value) => ConvertToBytes(value);
    }
}