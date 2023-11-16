using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Old tightening result upload reply
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0065 : Mid, ITightening, IController
    {
        public const int MID = 65;

        public long TighteningId
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.TighteningId).GetValue(OpenProtocolConvert.ToInt64);
            set => GetField(GetCurrentRevisionIndex(), DataFields.TighteningId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string VinNumber
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.VinNumber).Value;
            set => GetField(GetCurrentRevisionIndex(), DataFields.VinNumber).SetValue(value);
        }
        public int ParameterSetId
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.ParameterSetId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.ParameterSetId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int BatchCounter
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.BatchCounter).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.BatchCounter).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool TighteningStatus
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.TighteningStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(GetCurrentRevisionIndex(), DataFields.TighteningStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus TorqueStatus
        {
            get => (TighteningValueStatus)GetField(GetCurrentRevisionIndex(), DataFields.TorqueStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.TorqueStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus AngleStatus
        {
            get => (TighteningValueStatus)GetField(GetCurrentRevisionIndex(), DataFields.AngleStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.AngleStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public decimal Torque
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.Torque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(GetCurrentRevisionIndex(), DataFields.Torque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public int Angle
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.Angle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.Angle).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime Timestamp
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.Timestamp).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(GetCurrentRevisionIndex(), DataFields.Timestamp).SetValue(OpenProtocolConvert.ToString, value);
        }
        public BatchStatus BatchStatus
        {
            get => (BatchStatus)GetField(GetCurrentRevisionIndex(), DataFields.BatchStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.BatchStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        //Rev 2
        public int JobId
        {
            get => GetField(2, DataFields.JobId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.JobId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public Strategy Strategy
        {
            get => (Strategy)GetField(2, DataFields.Strategy).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.Strategy).SetValue(OpenProtocolConvert.ToString, value);
        }
        public StrategyOptions StrategyOptions { get; set; }
        public int BatchSize
        {
            get => GetField(2, DataFields.BatchSize).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.BatchSize).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus RundownAngleStatus
        {
            get => (TighteningValueStatus)GetField(2, DataFields.RundownAngleStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.RundownAngleStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus CurrentMonitoringStatus
        {
            get => (TighteningValueStatus)GetField(2, DataFields.CurrentMonitoringStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.CurrentMonitoringStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus SelftapStatus
        {
            get => (TighteningValueStatus)GetField(2, DataFields.SelftapStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.SelftapStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus PrevailTorqueMonitoringStatus
        {
            get => (TighteningValueStatus)GetField(2, DataFields.PrevailTorqueMonitoringStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.PrevailTorqueMonitoringStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus PrevailTorqueCompensateStatus
        {
            get => (TighteningValueStatus)GetField(2, DataFields.PrevaiTorqueMonitoringStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.PrevaiTorqueMonitoringStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningErrorStatus TighteningErrorStatus { get; set; }
        public int RundownAngle
        {
            get => GetField(2, DataFields.RundownAngle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.RundownAngle).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int CurrentMonitoringValue
        {
            get => GetField(2, DataFields.CurrentMonitoringValue).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.CurrentMonitoringValue).SetValue(OpenProtocolConvert.ToString, value);
        }
        public decimal SelftapTorque
        {
            get => GetField(2, DataFields.SelftapTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, DataFields.SelftapTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal PrevailTorque
        {
            get => GetField(2, DataFields.PrevailTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, DataFields.PrevailTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public int JobSequenceNumber
        {
            get => GetField(2, DataFields.JobSequenceNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.JobSequenceNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int SyncTighteningId
        {
            get => GetField(2, DataFields.SyncTighteningId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.SyncTighteningId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string ToolSerialNumber
        {
            get => GetField(2, DataFields.ToolSerialNumber).Value;
            set => GetField(2, DataFields.ToolSerialNumber).SetValue(value);
        }
        //Rev 3
        public TorqueValuesUnit TorqueValuesUnit
        {
            get => (TorqueValuesUnit)GetField(3, DataFields.TorqueValuesUnit).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(3, DataFields.TorqueValuesUnit).SetValue(OpenProtocolConvert.ToString, value);
        }
        public ResultType ResultType
        {
            get => (ResultType)GetField(3, DataFields.ResultType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(3, DataFields.ResultType).SetValue(OpenProtocolConvert.ToString, value);
        }
        //Rev 4
        public string IdentifierResultPart2
        {
            get => GetField(4, DataFields.IdentifierResulPart2).Value;
            set => GetField(4, DataFields.IdentifierResulPart2).SetValue(value);
        }
        public string IdentifierResultPart3
        {
            get => GetField(4, DataFields.IdentifierResulPart3).Value;
            set => GetField(4, DataFields.IdentifierResulPart3).SetValue(value);
        }
        public string IdentifierResultPart4
        {
            get => GetField(4, DataFields.IdentifierResulPart4).Value;
            set => GetField(4, DataFields.IdentifierResulPart4).SetValue(value);
        }
        //Rev 5
        public string CustomerTighteningErrorCode
        {
            get => GetField(5, DataFields.CustomerTighteningErrorCode).Value;
            set => GetField(5, DataFields.CustomerTighteningErrorCode).SetValue(value);
        }
        //Rev 6
        public decimal PrevailTorqueCompensateValue
        {
            get => GetField(6, DataFields.PrevailTorqueCompensateValue).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(6, DataFields.PrevailTorqueCompensateValue).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public TighteningErrorStatus2 TighteningErrorStatus2 { get; set; }
        //Rev 7
        public long StationId
        {
            get => GetField(7, DataFields.StationId).GetValue(OpenProtocolConvert.ToInt64);
            set => GetField(7, DataFields.StationId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string StationName
        {
            get => GetField(7, DataFields.StationName).Value;
            set => GetField(7, DataFields.StationName).SetValue(value);
        }
        //Rev 8
        public decimal StartFinalAngle
        {
            get => GetField(8, DataFields.StartFinalAngle).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(8, DataFields.StartFinalAngle).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public PostViewTorque PostViewTorqueActivated
        {
            get => (PostViewTorque)GetField(8, DataFields.PostViewTorqueActivated).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(8, DataFields.PostViewTorqueActivated).SetValue(OpenProtocolConvert.ToString, value);
        }
        public decimal PostViewTorqueHigh
        {
            get => GetField(8, DataFields.PostViewTorqueHigh).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(8, DataFields.PostViewTorqueHigh).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal PostViewTorqueLow
        {
            get => GetField(8, DataFields.PostViewTorqueLow).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(8, DataFields.PostViewTorqueLow).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        //Rev 9
        public decimal CurrentMonitoringAmpere
        {
            get => GetField(9, DataFields.CurrentMonitoringAmp).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(9, DataFields.CurrentMonitoringAmp).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal CurrentMonitoringAmpereMin
        {
            get => GetField(9, DataFields.CurrentMonitoringAmpMin).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(9, DataFields.CurrentMonitoringAmpMin).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal CurrentMonitoringAmpereMax
        {
            get => GetField(9, DataFields.CurrentMonitoringAmpMax).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(9, DataFields.CurrentMonitoringAmpMax).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        //Rev 10 addition
        public int AngleNumeratorScaleFactor
        {
            get => GetField(10, DataFields.AngleNumeratorScaleFactor).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, DataFields.AngleNumeratorScaleFactor).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int AngleDenominatorScaleFactor
        {
            get => GetField(10, DataFields.AngleDenominatorScaleFactor).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, DataFields.AngleDenominatorScaleFactor).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus OverallAngleStatus
        {
            get => (TighteningValueStatus)GetField(10, DataFields.OverallAngleStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, DataFields.OverallAngleStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int OverallAngleMin
        {
            get => GetField(10, DataFields.OverallAngleMin).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, DataFields.OverallAngleMin).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int OverallAngleMax
        {
            get => GetField(10, DataFields.OverallAngleMax).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, DataFields.OverallAngleMax).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int OverallAngle
        {
            get => GetField(10, DataFields.OverallAngle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, DataFields.OverallAngle).SetValue(OpenProtocolConvert.ToString, value);
        }
        public decimal PeakTorque
        {
            get => GetField(10, DataFields.PeakTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(10, DataFields.PeakTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal ResidualBreakawayTorque
        {
            get => GetField(10, DataFields.ResidualBreakawayTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(10, DataFields.ResidualBreakawayTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal StartRundownAngle
        {
            get => GetField(10, DataFields.StartRundownAngle).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(10, DataFields.StartRundownAngle).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal RundownAngleComplete
        {
            get => GetField(10, DataFields.RundownAngleComplete).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(10, DataFields.RundownAngleComplete).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        //Rev 11
        public decimal ClickTorque
        {
            get => GetField(11, DataFields.ClickTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(11, DataFields.ClickTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public int ClickAngle
        {
            get => GetField(11, DataFields.ClickAngle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(11, DataFields.ClickAngle).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0065() : this(DEFAULT_REVISION)
        {

        }

        public Mid0065(Header header) : base(header)
        {

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
            var builder = new StringBuilder(BuildHeader());
            int prefixIndex = 1;
            if (Header.Revision > 1)
            {
                GetField(2, DataFields.StrategyOptions).SetValue(StrategyOptions.Pack());
                GetField(2, DataFields.TighteningErrorStatus).SetValue(TighteningErrorStatus.Pack());

                if (Header.Revision > 5)
                {
                    GetField(6, DataFields.TighteningErrorStatus2).SetValue(TighteningErrorStatus2.Pack());
                }

                int processUntil = Header.Revision;
                for (int revision = 2; revision <= processUntil; revision++)
                {
                    builder.Append(Pack(revision, ref prefixIndex));
                }
            }
            else
            {
                builder.Append(Pack(Header.Revision, ref prefixIndex));
            }

            return builder.ToString();
        }

        protected override void ProcessDataFields(string package)
        {
            if (Header.Revision == 1)
            {
                ProcessDataFields(Header.Revision, package);
            }
            else
            {
                int processUntil = Header.Revision;
                for (int revision = 2; revision <= processUntil; revision++)
                    ProcessDataFields(revision, package);

                var strategyOptionsField = GetField(2, DataFields.StrategyOptions);
                StrategyOptions = StrategyOptions.Parse(strategyOptionsField.Value);

                var tighteningErrorStatusField = GetField(2, DataFields.TighteningErrorStatus);
                TighteningErrorStatus = TighteningErrorStatus.Parse(tighteningErrorStatusField.Value);

                if (Header.Revision > 5)
                {
                    var tighteningErrorStatus2Field = GetField(6, DataFields.TighteningErrorStatus2);
                    TighteningErrorStatus2 = TighteningErrorStatus2.Parse(tighteningErrorStatus2Field.Value);
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
                                DataField.Number(DataFields.TighteningId, 20, 10),
                                DataField.String(DataFields.VinNumber, 32, 25),
                                DataField.Number(DataFields.ParameterSetId, 59, 3),
                                DataField.Number(DataFields.BatchCounter, 64, 4),
                                DataField.Number(DataFields.TighteningStatus, 70, 1),
                                DataField.Number(DataFields.TorqueStatus, 73, 1),
                                DataField.Number(DataFields.AngleStatus, 76, 1),
                                DataField.Number(DataFields.Torque, 79, 6),
                                DataField.Number(DataFields.Angle, 87, 5),
                                DataField.Timestamp(DataFields.Timestamp, 94),
                                DataField.Number(DataFields.BatchStatus, 115, 1)
                            }
                },
                {
                    2, new List<DataField>()
                            {
                                DataField.Number(DataFields.TighteningId, 20, 10),
                                DataField.String(DataFields.VinNumber, 32, 25),
                                DataField.Number(DataFields.JobId, 59, 4),
                                DataField.Number(DataFields.ParameterSetId, 65, 3),
                                DataField.Number(DataFields.Strategy, 70, 2),
                                new(DataFields.StrategyOptions, 74, 5, '0', PaddingOrientation.LeftPadded),
                                DataField.Number(DataFields.BatchSize, 81, 4),
                                DataField.Number(DataFields.BatchCounter, 87, 4),
                                DataField.Number(DataFields.TighteningStatus, 93, 1),
                                DataField.Number(DataFields.BatchStatus, 96, 1),
                                DataField.Number(DataFields.TorqueStatus, 99, 1),
                                DataField.Number(DataFields.AngleStatus, 102, 1),
                                DataField.Number(DataFields.RundownAngleStatus, 105, 1),
                                DataField.Number(DataFields.CurrentMonitoringStatus, 108, 1),
                                DataField.Number(DataFields.SelftapStatus, 111, 1),
                                DataField.Number(DataFields.PrevailTorqueMonitoringStatus, 114, 1),
                                DataField.Number(DataFields.PrevaiTorqueMonitoringStatus, 117, 1),
                                new(DataFields.TighteningErrorStatus, 120, 10, '0', PaddingOrientation.LeftPadded),
                                DataField.Number(DataFields.Torque, 132, 6),
                                DataField.Number(DataFields.Angle, 140, 5),
                                DataField.Number(DataFields.RundownAngle, 147, 5),
                                DataField.Number(DataFields.CurrentMonitoringValue, 154, 3),
                                DataField.Number(DataFields.SelftapTorque, 159, 6),
                                DataField.Number(DataFields.PrevailTorque, 167, 6),
                                DataField.Number(DataFields.JobSequenceNumber, 175, 5),
                                DataField.Number(DataFields.SyncTighteningId, 182, 5),
                                DataField.String(DataFields.ToolSerialNumber, 189, 14),
                                DataField.Timestamp(DataFields.Timestamp, 205),
                            }
                },
                {
                    3, new List<DataField>()
                            {
                                DataField.Number(DataFields.TorqueValuesUnit, 226, 1),
                                DataField.Number(DataFields.ResultType, 229, 2)
                            }
                },
                {
                    4, new List<DataField>()
                            {
                                DataField.String(DataFields.IdentifierResulPart2, 233, 25),
                                DataField.String(DataFields.IdentifierResulPart3, 260, 25),
                                DataField.String(DataFields.IdentifierResulPart4, 287, 25)
                            }
                },
                {
                    5, new List<DataField>()
                            {
                                DataField.String(DataFields.CustomerTighteningErrorCode, 314, 4),
                            }
                },
                {
                    6, new List<DataField>()
                            {
                                DataField.Number(DataFields.PrevailTorqueCompensateValue, 320, 6),
                                new(DataFields.TighteningErrorStatus2, 328, 10, '0', PaddingOrientation.LeftPadded)
                            }
                },
                {
                    7, new List<DataField>()
                            {
                                DataField.Number(DataFields.StationId, 340, 10),
                                DataField.String(DataFields.StationName, 352, 25)
                            }
                },
                {
                    8, new List<DataField>()
                            {
                                DataField.Number(DataFields.StartFinalAngle, 379, 6),
                                DataField.Number(DataFields.PostViewTorqueActivated, 387, 1),
                                DataField.Number(DataFields.PostViewTorqueHigh, 390, 6),
                                DataField.Number(DataFields.PostViewTorqueLow, 398, 6),
                            }
                },
                {
                    9, new List<DataField>()
                            {
                                DataField.Number(DataFields.CurrentMonitoringAmp, 406, 5),
                                DataField.Number(DataFields.CurrentMonitoringAmpMin, 413, 5),
                                DataField.Number(DataFields.CurrentMonitoringAmpMax, 420, 5)
                            }
                },
                {
                    10, new List<DataField>()
                            {
                                DataField.Number(DataFields.AngleNumeratorScaleFactor, 427, 5),
                                DataField.Number(DataFields.AngleDenominatorScaleFactor, 434, 5),
                                DataField.Number(DataFields.OverallAngleStatus, 441, 1),
                                DataField.Number(DataFields.OverallAngleMin, 444, 5),
                                DataField.Number(DataFields.OverallAngleMax, 451, 5),
                                DataField.Number(DataFields.OverallAngle, 458, 5),
                                DataField.Number(DataFields.PeakTorque, 465, 6),
                                DataField.Number(DataFields.ResidualBreakawayTorque, 473, 6),
                                DataField.Number(DataFields.StartRundownAngle, 481, 6),
                                DataField.Number(DataFields.RundownAngleComplete, 489, 6)
                            }
                },
                {
                    11, new List<DataField>()
                            {
                                DataField.Number(DataFields.ClickTorque, 497, 6),
                                DataField.Number(DataFields.ClickAngle, 505, 5),
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
            PostViewTorqueLow,
            //Rev 9
            CurrentMonitoringAmp,
            CurrentMonitoringAmpMin,
            CurrentMonitoringAmpMax,
            //Rev 10
            AngleNumeratorScaleFactor,
            AngleDenominatorScaleFactor,
            OverallAngleStatus,
            OverallAngleMin,
            OverallAngleMax,
            OverallAngle,
            PeakTorque,
            ResidualBreakawayTorque,
            StartRundownAngle,
            RundownAngleComplete,
            //Rev 11
            ClickTorque,
            ClickAngle
        }
    }
}
