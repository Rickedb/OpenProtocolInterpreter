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
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.TighteningId).GetValue(OpenProtocolConvert.ToInt64);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TighteningId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string VinNumber
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.VinNumber).Value;
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.VinNumber).SetValue(value);
        }
        public int ParameterSetId
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.ParameterSetId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.ParameterSetId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int BatchCounter
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchCounter).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchCounter).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool TighteningStatus
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.TighteningStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TighteningStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus TorqueStatus
        {
            get => (TighteningValueStatus)GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public TighteningValueStatus AngleStatus
        {
            get => (TighteningValueStatus)GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public decimal Torque
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.Torque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.Torque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public int Angle
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.Angle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.Angle).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime Timestamp
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.Timestamp).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.Timestamp).SetValue(OpenProtocolConvert.ToString, value);
        }
        public BatchStatus BatchStatus
        {
            get => (BatchStatus)GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        //Rev 2
        public int JobId
        {
            get => GetField(2, (int)DataFields.JobId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.JobId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public Strategy Strategy
        {
            get => (Strategy)GetField(2, (int)DataFields.Strategy).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.Strategy).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public StrategyOptions StrategyOptions { get; set; }
        public int BatchSize
        {
            get => GetField(2, (int)DataFields.BatchSize).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.BatchSize).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus RundownAngleStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.RundownAngleStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.RundownAngleStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public TighteningValueStatus CurrentMonitoringStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.CurrentMonitoringStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.CurrentMonitoringStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public TighteningValueStatus SelftapStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.SelftapStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.SelftapStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public TighteningValueStatus PrevailTorqueMonitoringStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.PrevailTorqueMonitoringStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.PrevailTorqueMonitoringStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public TighteningValueStatus PrevailTorqueCompensateStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.PrevaiTorqueMonitoringStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.PrevaiTorqueMonitoringStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public TighteningErrorStatus TighteningErrorStatus { get; set; }
        public int RundownAngle
        {
            get => GetField(2, (int)DataFields.RundownAngle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.RundownAngle).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int CurrentMonitoringValue
        {
            get => GetField(2, (int)DataFields.CurrentMonitoringValue).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.CurrentMonitoringValue).SetValue(OpenProtocolConvert.ToString, value);
        }
        public decimal SelftapTorque
        {
            get => GetField(2, (int)DataFields.SelftapTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, (int)DataFields.SelftapTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal PrevailTorque
        {
            get => GetField(2, (int)DataFields.PrevailTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, (int)DataFields.PrevailTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public int JobSequenceNumber
        {
            get => GetField(2, (int)DataFields.JobSequenceNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.JobSequenceNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int SyncTighteningId
        {
            get => GetField(2, (int)DataFields.SyncTighteningId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.SyncTighteningId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string ToolSerialNumber
        {
            get => GetField(2, (int)DataFields.ToolSerialNumber).Value;
            set => GetField(2, (int)DataFields.ToolSerialNumber).SetValue(value);
        }
        //Rev 3
        public TorqueValuesUnit TorqueValuesUnit
        {
            get => (TorqueValuesUnit)GetField(3, (int)DataFields.TorqueValuesUnit).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(3, (int)DataFields.TorqueValuesUnit).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public ResultType ResultType
        {
            get => (ResultType)GetField(3, (int)DataFields.ResultType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(3, (int)DataFields.ResultType).SetValue(OpenProtocolConvert.ToString, (int)value);
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
            get => GetField(6, (int)DataFields.PrevailTorqueCompensateValue).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(6, (int)DataFields.PrevailTorqueCompensateValue).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public TighteningErrorStatus2 TighteningErrorStatus2 { get; set; }
        //Rev 7
        public long StationId
        {
            get => GetField(7, (int)DataFields.StationId).GetValue(OpenProtocolConvert.ToInt64);
            set => GetField(7, (int)DataFields.StationId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string StationName
        {
            get => GetField(7, (int)DataFields.StationName).Value;
            set => GetField(7, (int)DataFields.StationName).SetValue(value);
        }
        //Rev 8
        public decimal StartFinalAngle
        {
            get => GetField(8, (int)DataFields.StartFinalAngle).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(8, (int)DataFields.StartFinalAngle).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public PostViewTorque PostViewTorqueActivated
        {
            get => (PostViewTorque)GetField(8, (int)DataFields.PostViewTorqueActivated).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(8, (int)DataFields.PostViewTorqueActivated).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public decimal PostViewTorqueHigh
        {
            get => GetField(8, (int)DataFields.PostViewTorqueHigh).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(8, (int)DataFields.PostViewTorqueHigh).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal PostViewTorqueLow
        {
            get => GetField(8, (int)DataFields.PostViewTorqueLow).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(8, (int)DataFields.PostViewTorqueLow).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        //Rev 9
        public decimal CurrentMonitoringAmpere
        {
            get => GetField(9, (int)DataFields.CurrentMonitoringAmp).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(9, (int)DataFields.CurrentMonitoringAmp).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal CurrentMonitoringAmpereMin
        {
            get => GetField(9, (int)DataFields.CurrentMonitoringAmpMin).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(9, (int)DataFields.CurrentMonitoringAmpMin).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal CurrentMonitoringAmpereMax
        {
            get => GetField(9, (int)DataFields.CurrentMonitoringAmpMax).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(9, (int)DataFields.CurrentMonitoringAmpMax).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        //Rev 10 addition
        public int AngleNumeratorScaleFactor
        {
            get => GetField(10, (int)DataFields.AngleNumeratorScaleFactor).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, (int)DataFields.AngleNumeratorScaleFactor).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int AngleDenominatorScaleFactor
        {
            get => GetField(10, (int)DataFields.AngleDenominatorScaleFactor).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, (int)DataFields.AngleDenominatorScaleFactor).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus OverallAngleStatus
        {
            get => (TighteningValueStatus)GetField(10, (int)DataFields.OverallAngleStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, (int)DataFields.OverallAngleStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public int OverallAngleMin
        {
            get => GetField(10, (int)DataFields.OverallAngleMin).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, (int)DataFields.OverallAngleMin).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int OverallAngleMax
        {
            get => GetField(10, (int)DataFields.OverallAngleMax).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, (int)DataFields.OverallAngleMax).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int OverallAngle
        {
            get => GetField(10, (int)DataFields.OverallAngle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, (int)DataFields.OverallAngle).SetValue(OpenProtocolConvert.ToString, value);
        }
        public decimal PeakTorque
        {
            get => GetField(10, (int)DataFields.PeakTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(10, (int)DataFields.PeakTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal ResidualBreakawayTorque
        {
            get => GetField(10, (int)DataFields.ResidualBreakawayTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(10, (int)DataFields.ResidualBreakawayTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal StartRundownAngle
        {
            get => GetField(10, (int)DataFields.StartRundownAngle).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(10, (int)DataFields.StartRundownAngle).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal RundownAngleComplete
        {
            get => GetField(10, (int)DataFields.RundownAngleComplete).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(10, (int)DataFields.RundownAngleComplete).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
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
                GetField(2, (int)DataFields.StrategyOptions).SetValue(StrategyOptions.Pack());
                GetField(2, (int)DataFields.TighteningErrorStatus).SetValue(TighteningErrorStatus.Pack());

                if (Header.Revision > 5)
                {
                    GetField(6, (int)DataFields.TighteningErrorStatus2).SetValue(TighteningErrorStatus2.Pack());
                }

                int processUntil = Header.Revision;
                for (int i = 2; i <= processUntil; i++)
                {
                    builder.Append(Pack(RevisionsByFields[i], ref prefixIndex));
                }
            }
            else
            {
                builder.Append(Pack(RevisionsByFields[Header.Revision], ref prefixIndex));
            }

            return builder.ToString();
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
                StrategyOptions = StrategyOptions.Parse(strategyOptionsField.Value);

                var tighteningErrorStatusField = GetField(2, (int)DataFields.TighteningErrorStatus);
                TighteningErrorStatus = TighteningErrorStatus.Parse(tighteningErrorStatusField.Value);

                if (Header.Revision > 5)
                {
                    var tighteningErrorStatus2Field = GetField(6, (int)DataFields.TighteningErrorStatus2);
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
                                new((int)DataFields.TighteningId, 20, 10, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.VinNumber, 32, 25, ' '),
                                new((int)DataFields.ParameterSetId, 59, 3, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.BatchCounter, 64, 4, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.TighteningStatus, 70, 1),
                                new((int)DataFields.TorqueStatus, 73, 1),
                                new((int)DataFields.AngleStatus, 76, 1),
                                new((int)DataFields.Torque, 79, 6, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.Angle, 87, 5, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.Timestamp, 94, 19),
                                new((int)DataFields.BatchStatus, 115, 1)
                            }
                },
                {
                    2, new List<DataField>()
                            {
                                new((int)DataFields.TighteningId, 20, 10, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.VinNumber, 32, 25, ' '),
                                new((int)DataFields.JobId, 59, 4, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.ParameterSetId, 65, 3, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.Strategy, 70, 2, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.StrategyOptions, 74, 5, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.BatchSize, 81, 4, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.BatchCounter, 87, 4, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.TighteningStatus, 93, 1),
                                new((int)DataFields.BatchStatus, 96, 1),
                                new((int)DataFields.TorqueStatus, 99, 1),
                                new((int)DataFields.AngleStatus, 102, 1),
                                new((int)DataFields.RundownAngleStatus, 105, 1),
                                new((int)DataFields.CurrentMonitoringStatus, 108, 1),
                                new((int)DataFields.SelftapStatus, 111, 1),
                                new((int)DataFields.PrevailTorqueMonitoringStatus, 114, 1),
                                new((int)DataFields.PrevaiTorqueMonitoringStatus, 117, 1),
                                new((int)DataFields.TighteningErrorStatus, 120, 10, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.Torque, 132, 6, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.Angle, 140, 5, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.RundownAngle, 147, 5, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.CurrentMonitoringValue, 154, 3, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.SelftapTorque, 159, 6, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.PrevailTorque, 167, 6, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.JobSequenceNumber, 175, 5, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.SyncTighteningId, 182, 5, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.ToolSerialNumber, 189, 14, ' '),
                                new((int)DataFields.Timestamp, 205, 19),
                            }
                },
                {
                    3, new List<DataField>()
                            {
                                new((int)DataFields.TorqueValuesUnit, 226, 1),
                                new((int)DataFields.ResultType, 229, 2, '0', PaddingOrientation.LeftPadded)
                            }
                },
                {
                    4, new List<DataField>()
                            {
                                new((int)DataFields.IdentifierResulPart2, 233, 25, ' '),
                                new((int)DataFields.IdentifierResulPart3, 260, 25, ' '),
                                new((int)DataFields.IdentifierResulPart4, 287, 25, ' ')
                            }
                },
                {
                    5, new List<DataField>()
                            {
                                new((int)DataFields.CustomerTighteningErrorCode, 314, 4, ' '),
                            }
                },
                {
                    6, new List<DataField>()
                            {
                                new((int)DataFields.PrevailTorqueCompensateValue, 320, 6, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.TighteningErrorStatus2, 328, 10, '0', PaddingOrientation.LeftPadded)
                            }
                },
                {
                    7, new List<DataField>()
                            {
                                new((int)DataFields.StationId, 340, 10, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.StationName, 352, 25)
                            }
                },
                {
                    8, new List<DataField>()
                            {
                                new((int)DataFields.StartFinalAngle, 379, 6, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.PostViewTorqueActivated, 387, 1),
                                new((int)DataFields.PostViewTorqueHigh, 390, 6, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.PostViewTorqueLow, 398, 6, '0', PaddingOrientation.LeftPadded),
                            }
                },
                {
                    9, new List<DataField>()
                            {
                                new((int)DataFields.CurrentMonitoringAmp, 406, 5, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.CurrentMonitoringAmpMin, 413, 5, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.CurrentMonitoringAmpMax, 420, 5, '0', PaddingOrientation.LeftPadded)
                            }
                },
                {
                    10, new List<DataField>()
                            {
                                new((int)DataFields.AngleNumeratorScaleFactor, 427, 5, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.AngleDenominatorScaleFactor, 434, 5, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.OverallAngleStatus, 441, 1),
                                new((int)DataFields.OverallAngleMin, 444, 5, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.OverallAngleMax, 451, 5, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.OverallAngle, 458, 5, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.PeakTorque, 465, 6, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.ResidualBreakawayTorque, 473, 6, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.StartRundownAngle, 481, 6, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.RundownAngleComplete, 489, 6, '0', PaddingOrientation.LeftPadded)
                            }
                },
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
        }
    }
}
