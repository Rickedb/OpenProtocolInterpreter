using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Old tightening result upload reply
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0065 : Mid, ITightening, IController
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<long> _longConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<decimal> _decimalConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        private readonly IValueConverter<StrategyOptions> _strategyOptionsConverter;
        private readonly IValueConverter<TighteningErrorStatus> _tighteningErrorStatusConverter;
        private readonly IValueConverter<TighteningErrorStatus2> _tighteningErrorStatus2Converter;
        public const int MID = 65;

        public long TighteningId
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.TighteningId).GetValue(_longConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TighteningId).SetValue(_longConverter.Convert, value);
        }
        public string VinNumber
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.VinNumber).Value;
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.VinNumber).SetValue(value);
        }
        public int ParameterSetId
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.ParameterSetId).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.ParameterSetId).SetValue(_intConverter.Convert, value);
        }
        public int BatchCounter
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchCounter).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchCounter).SetValue(_intConverter.Convert, value);
        }
        public bool TighteningStatus
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.TighteningStatus).GetValue(_boolConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TighteningStatus).SetValue(_boolConverter.Convert, value);
        }
        public TighteningValueStatus TorqueStatus
        {
            get => (TighteningValueStatus)GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueStatus).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningValueStatus AngleStatus
        {
            get => (TighteningValueStatus)GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleStatus).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public decimal Torque
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.Torque).GetValue(_decimalConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.Torque).SetValue(_decimalConverter.Convert, value);
        }
        public int Angle
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.Angle).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.Angle).SetValue(_intConverter.Convert, value);
        }
        public DateTime Timestamp
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.Timestamp).GetValue(_dateConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.Timestamp).SetValue(_dateConverter.Convert, value);
        }
        public BatchStatus BatchStatus
        {
            get => (BatchStatus)GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchStatus).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchStatus).SetValue(_intConverter.Convert, (int)value);
        }
        //Rev 2
        public int JobId
        {
            get => GetField(2, (int)DataFields.JobId).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.JobId).SetValue(_intConverter.Convert, value);
        }
        public Strategy Strategy
        {
            get => (Strategy)GetField(2, (int)DataFields.Strategy).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.Strategy).SetValue(_intConverter.Convert, (int)value);
        }
        public StrategyOptions StrategyOptions { get; set; }
        public int BatchSize
        {
            get => GetField(2, (int)DataFields.BatchSize).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.BatchSize).SetValue(_intConverter.Convert, value);
        }
        public TighteningValueStatus RundownAngleStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.RundownAngleStatus).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.RundownAngleStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningValueStatus CurrentMonitoringStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.CurrentMonitoringStatus).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.CurrentMonitoringStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningValueStatus SelftapStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.SelftapStatus).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.SelftapStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningValueStatus PrevailTorqueMonitoringStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.PrevailTorqueMonitoringStatus).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.PrevailTorqueMonitoringStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningValueStatus PrevailTorqueCompensateStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.PrevaiTorqueMonitoringStatus).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.PrevaiTorqueMonitoringStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningErrorStatus TighteningErrorStatus { get; set; }
        public int RundownAngle
        {
            get => GetField(2, (int)DataFields.RundownAngle).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.RundownAngle).SetValue(_intConverter.Convert, value);
        }
        public int CurrentMonitoringValue
        {
            get => GetField(2, (int)DataFields.CurrentMonitoringValue).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.CurrentMonitoringValue).SetValue(_intConverter.Convert, value);
        }
        public decimal SelftapTorque
        {
            get => GetField(2, (int)DataFields.SelftapTorque).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.SelftapTorque).SetValue(_decimalConverter.Convert, value);
        }
        public decimal PrevailTorque
        {
            get => GetField(2, (int)DataFields.PrevailTorque).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.PrevailTorque).SetValue(_decimalConverter.Convert, value);
        }
        public int JobSequenceNumber
        {
            get => GetField(2, (int)DataFields.JobSequenceNumber).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.JobSequenceNumber).SetValue(_intConverter.Convert, value);
        }
        public int SyncTighteningId
        {
            get => GetField(2, (int)DataFields.SyncTighteningId).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.SyncTighteningId).SetValue(_intConverter.Convert, value);
        }
        public string ToolSerialNumber
        {
            get => GetField(2, (int)DataFields.ToolSerialNumber).Value;
            set => GetField(2, (int)DataFields.ToolSerialNumber).SetValue(value);
        }
        //Rev 3
        public TorqueValuesUnit TorqueValuesUnit
        {
            get => (TorqueValuesUnit)GetField(3, (int)DataFields.TorqueValuesUnit).GetValue(_intConverter.Convert);
            set => GetField(3, (int)DataFields.TorqueValuesUnit).SetValue(_intConverter.Convert, (int)value);
        }
        public ResultType ResultType
        {
            get => (ResultType)GetField(3, (int)DataFields.ResultType).GetValue(_intConverter.Convert);
            set => GetField(3, (int)DataFields.ResultType).SetValue(_intConverter.Convert, (int)value);
        }
        //Rev 4
        public string IdentifierResultPart2
        {
            get => GetField(4, (int)DataFields.IdentifierResulPart2).Value;
            set => GetField(4, (int)DataFields.IdentifierResulPart2).SetValue(value);
        }
        public string IdentifierResultPart3
        {
            get => GetField(4, (int)DataFields.IdentifierResulPart3).Value;
            set => GetField(4, (int)DataFields.IdentifierResulPart3).SetValue(value);
        }
        public string IdentifierResultPart4
        {
            get => GetField(4, (int)DataFields.IdentifierResulPart4).Value;
            set => GetField(4, (int)DataFields.IdentifierResulPart4).SetValue(value);
        }
        //Rev 5
        public string CustomerTighteningErrorCode
        {
            get => GetField(5, (int)DataFields.CustomerTighteningErrorCode).Value;
            set => GetField(5, (int)DataFields.CustomerTighteningErrorCode).SetValue(value);
        }
        //Rev 6
        public decimal PrevailTorqueCompensateValue
        {
            get => GetField(6, (int)DataFields.PrevailTorqueCompensateValue).GetValue(_decimalConverter.Convert);
            set => GetField(6, (int)DataFields.PrevailTorqueCompensateValue).SetValue(_decimalConverter.Convert, value);
        }
        public TighteningErrorStatus2 TighteningErrorStatus2 { get; set; }
        //Rev 7
        public long StationId
        {
            get => GetField(7, (int)DataFields.StationId).GetValue(_longConverter.Convert);
            set => GetField(7, (int)DataFields.StationId).SetValue(_longConverter.Convert, value);
        }
        public string StationName
        {
            get => GetField(7, (int)DataFields.StationName).Value;
            set => GetField(7, (int)DataFields.StationName).SetValue(value);
        }
        //Rev 8
        public decimal StartFinalAngle
        {
            get => GetField(8, (int)DataFields.StartFinalAngle).GetValue(_decimalConverter.Convert);
            set => GetField(8, (int)DataFields.StartFinalAngle).SetValue(_decimalConverter.Convert, value);
        }
        public PostViewTorque PostViewTorqueActivated
        {
            get => (PostViewTorque)GetField(8, (int)DataFields.PostViewTorqueActivated).GetValue(_intConverter.Convert);
            set => GetField(8, (int)DataFields.PostViewTorqueActivated).SetValue(_intConverter.Convert, (int)value);
        }
        public decimal PostViewTorqueHigh
        {
            get => GetField(8, (int)DataFields.PostViewTorqueHigh).GetValue(_decimalConverter.Convert);
            set => GetField(8, (int)DataFields.PostViewTorqueHigh).SetValue(_decimalConverter.Convert, value);
        }
        public decimal PostViewTorqueLow
        {
            get => GetField(8, (int)DataFields.PostViewTorqueLow).GetValue(_decimalConverter.Convert);
            set => GetField(8, (int)DataFields.PostViewTorqueLow).SetValue(_decimalConverter.Convert, value);
        }

        public Mid0065() : this(DEFAULT_REVISION)
        {

        }

        public Mid0065(Header header) : base(header)
        {
            var byteArrayConverter = new ByteArrayConverter();
            _intConverter = new Int32Converter();
            _longConverter = new Int64Converter();
            _boolConverter = new BoolConverter();
            _decimalConverter = new DecimalTrucatedConverter(2);
            _dateConverter = new DateConverter();
            _strategyOptionsConverter = new StrategyOptionsConverter(byteArrayConverter, _intConverter);
            _tighteningErrorStatusConverter = new TighteningErrorStatusConverter(byteArrayConverter, _longConverter);
            _tighteningErrorStatus2Converter = new TighteningErrorStatus2Converter(byteArrayConverter, _longConverter);
        }

        public Mid0065(int revision) : this(new Header()
        {
            Mid = MID, 
            Revision = revision
        })
        {
        }

        protected override string BuildHeader()
        {
            if (RevisionsByFields.Any())
            {
                Header.Length = 20;
                Header.Revision = Header.Revision > 0 ? Header.Revision : 1;
                if (Header.Revision > 1)
                {
                    for (int i = 2; i <= Header.Revision; i++)
                        foreach (var dataField in RevisionsByFields[i])
                            Header.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
                }
                else
                {
                    foreach (var dataField in RevisionsByFields[1])
                        Header.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
                }
            }
            return Header.ToString();
        }

        public override string Pack()
        {
            string package = BuildHeader();
            int prefixIndex = 1;
            if (Header.Revision > 1)
            {
                GetField(2, (int)DataFields.StrategyOptions).SetValue(_strategyOptionsConverter.Convert, StrategyOptions);
                GetField(2, (int)DataFields.TighteningErrorStatus).SetValue(_tighteningErrorStatusConverter.Convert, TighteningErrorStatus);

                if (Header.Revision > 5)
                {
                    GetField(6, (int)DataFields.TighteningErrorStatus2).SetValue(_tighteningErrorStatus2Converter.Convert, TighteningErrorStatus2);
                }

                int processUntil = Header.Revision;
                for (int i = 2; i <= processUntil; i++)
                {
                    package += Pack(RevisionsByFields[i], ref prefixIndex);
                }
            }
            else
            {
                package += Pack(RevisionsByFields[Header.Revision], ref prefixIndex);
            }

            return package;
        }

        protected override void ProcessDataFields(string package)
        {
            if (Header.Revision == 1)
            {
                ProcessDataFields(RevisionsByFields[Header.Revision], package);
            }
            else
            {
                int processUntil = Header.Revision;
                for (int i = 2; i <= processUntil; i++)
                    ProcessDataFields(RevisionsByFields[i], package);

                var strategyOptionsField = GetField(2, (int)DataFields.StrategyOptions);
                StrategyOptions = _strategyOptionsConverter.Convert(strategyOptionsField.Value);

                var tighteningErrorStatusField = GetField(2, (int)DataFields.TighteningErrorStatus);
                TighteningErrorStatus = _tighteningErrorStatusConverter.Convert(tighteningErrorStatusField.Value);

                if (Header.Revision > 5)
                {
                    var tighteningErrorStatus2Field = GetField(6, (int)DataFields.TighteningErrorStatus2);
                    TighteningErrorStatus2 = _tighteningErrorStatus2Converter.Convert(tighteningErrorStatus2Field.Value);
                }
            }
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            //opted to work with a different approuch (since it would need to modify too much fields)
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.TighteningId, 20, 10, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.VinNumber, 32, 25, ' '),
                                new DataField((int)DataFields.ParameterSetId, 59, 3, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.BatchCounter, 64, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TighteningStatus, 70, 1),
                                new DataField((int)DataFields.TorqueStatus, 73, 1),
                                new DataField((int)DataFields.AngleStatus, 76, 1),
                                new DataField((int)DataFields.Torque, 79, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.Angle, 87, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.Timestamp, 94, 19),
                                new DataField((int)DataFields.BatchStatus, 115, 1)
                            }
                },
                {
                    2, new List<DataField>()
                            {
                                new DataField((int)DataFields.TighteningId, 20, 10, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.VinNumber, 32, 25, ' '),
                                new DataField((int)DataFields.JobId, 59, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ParameterSetId, 65, 3, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.Strategy, 70, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.StrategyOptions, 74, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.BatchSize, 81, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.BatchCounter, 87, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TighteningStatus, 93, 1),
                                new DataField((int)DataFields.BatchStatus, 96, 1),
                                new DataField((int)DataFields.TorqueStatus, 99, 1),
                                new DataField((int)DataFields.AngleStatus, 102, 1),
                                new DataField((int)DataFields.RundownAngleStatus, 105, 1),
                                new DataField((int)DataFields.CurrentMonitoringStatus, 108, 1),
                                new DataField((int)DataFields.SelftapStatus, 111, 1),
                                new DataField((int)DataFields.PrevailTorqueMonitoringStatus, 114, 1),
                                new DataField((int)DataFields.PrevaiTorqueMonitoringStatus, 117, 1),
                                new DataField((int)DataFields.TighteningErrorStatus, 120, 10, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.Torque, 132, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.Angle, 140, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.RundownAngle, 147, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.CurrentMonitoringValue, 154, 3, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.SelftapTorque, 159, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.PrevailTorque, 167, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.JobSequenceNumber, 175, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.SyncTighteningId, 182, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ToolSerialNumber, 189, 14, ' '),
                                new DataField((int)DataFields.Timestamp, 205, 19),
                            }
                },
                {
                    3, new List<DataField>()
                            {
                                new DataField((int)DataFields.TorqueValuesUnit, 226, 1),
                                new DataField((int)DataFields.ResultType, 229, 2, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                },
                {
                    4, new List<DataField>()
                            {
                                new DataField((int)DataFields.IdentifierResulPart2, 233, 25, ' '),
                                new DataField((int)DataFields.IdentifierResulPart3, 260, 25, ' '),
                                new DataField((int)DataFields.IdentifierResulPart4, 287, 25, ' ')
                            }
                },
                {
                    5, new List<DataField>()
                            {
                                new DataField((int)DataFields.CustomerTighteningErrorCode, 314, 4, ' '),
                            }
                },
                {
                    6, new List<DataField>()
                            {
                                new DataField((int)DataFields.PrevailTorqueCompensateValue, 320, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TighteningErrorStatus2, 328, 10, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                },
                {
                    7, new List<DataField>()
                            {
                                new DataField((int)DataFields.StationId, 340, 10, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.StationName, 352, 25)
                            }
                },
                {
                    8, new List<DataField>()
                            {
                                new DataField((int)DataFields.StartFinalAngle, 379, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.PostViewTorqueActivated, 387, 1),
                                new DataField((int)DataFields.PostViewTorqueHigh, 390, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.PostViewTorqueLow, 398, 6, '0', DataField.PaddingOrientations.LeftPadded),
                            }
                }
            };
        }

        private int GetCurrentRevisionIndex() => (Header.Revision > 1) ? 2 : 1;

        protected enum DataFields
        {
            TighteningId,
            VinNumber,
            ParameterSetId,
            BatchCounter,
            TighteningStatus,
            TorqueStatus,
            AngleStatus,
            Torque,
            Angle,
            Timestamp,
            BatchStatus,
            //Rev 2 Additions
            JobId,
            Strategy,
            StrategyOptions,
            BatchSize,
            RundownAngleStatus,
            CurrentMonitoringStatus,
            SelftapStatus,
            PrevailTorqueMonitoringStatus,
            PrevaiTorqueMonitoringStatus,
            TighteningErrorStatus,
            RundownAngle,
            CurrentMonitoringValue,
            SelftapTorque,
            PrevailTorque,
            JobSequenceNumber,
            SyncTighteningId,
            ToolSerialNumber,
            //Rev 3 Additions
            TorqueValuesUnit,
            ResultType,
            //Rev 4 Additions
            IdentifierResulPart2,
            IdentifierResulPart3,
            IdentifierResulPart4,
            //Rev 5 Additions
            CustomerTighteningErrorCode,
            //Rev 6 Additions
            PrevailTorqueCompensateValue,
            TighteningErrorStatus2,
            //Rev 7 Additions
            StationId,
            StationName,
            //Rev 8 Additions
            StartFinalAngle,
            PostViewTorqueActivated,
            PostViewTorqueHigh,
            PostViewTorqueLow
    }
    }
}
