using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// MID: Alarm
    /// Description: 
    ///      An alarm has appeared in the controller. 
    ///      The current alarm is uploaded from the controller to the integrator.
    /// 
    /// Message sent by: Controller
    /// Answer: MID 0072 Alarm acknowledge
    /// </summary>
    public class MID_0071 : Mid, IAlarm
    {
        private IValueConverter<bool> _boolConverter;
        private IValueConverter<DateTime> _dateConverter;
        private const int LAST_REVISION = 2;
        public const int MID = 71;

        public string ErrorCode
        {
            get => RevisionsByFields[1][(int)DataFields.ERROR_CODE].Value;
            set => RevisionsByFields[1][(int)DataFields.ERROR_CODE].SetValue(value);
        }
        public bool ControllerReadyStatus
        {
            get => RevisionsByFields[1][(int)DataFields.CONTROLLER_READY_STATUS].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.CONTROLLER_READY_STATUS].SetValue(_boolConverter.Convert, value);
        }
        public bool ToolReadyStatus
        {
            get => RevisionsByFields[1][(int)DataFields.TOOL_READY_STATUS].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.TOOL_READY_STATUS].SetValue(_boolConverter.Convert, value);
        }
        public DateTime Time
        {
            get => RevisionsByFields[1][(int)DataFields.TIME].GetValue(_dateConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.TIME].SetValue(_dateConverter.Convert, value);
        }
        //Rev 2
        public string AlarmText
        {
            get => RevisionsByFields[2][(int)DataFields.TIME].Value;
            set => RevisionsByFields[2][(int)DataFields.TIME].SetValue(value);
        }

        public MID_0071(int revision = LAST_REVISION, int? noAckFlag = 0) : base(MID, revision, noAckFlag)
        {
            UpdateFieldsIndexBasedOnRevision(revision);
            _boolConverter = new BoolConverter();
            _dateConverter = new DateConverter();
        }

        /// <summary>
        /// Constructor for Revision 1
        /// </summary>
        /// <param name="errorCode">The error code is specified by 4 ASCII characters. The error code begins with E and is followed by three digits. <para>Example E851.</para></param>
        /// <param name="controllerReadyStatus">Controller ready status</param>
        /// <param name="toolReadyStatus">Tool ready status</param>
        /// <param name="time">Time stamp for the alarm</param>
        /// <param name="revision">Revision (Default revision = 1)</param>
        /// <param name="ackflag">Acknowledge flag (Default = 1)</param>
        public MID_0071(string errorCode, bool controllerReadyStatus, bool toolReadyStatus, DateTime time, int revision = 1, int? noAckFlag = 0) : this(revision, noAckFlag)
        {
            ErrorCode = errorCode;
            ControllerReadyStatus = controllerReadyStatus;
            ToolReadyStatus = toolReadyStatus;
            Time = time;
        }

        /// <summary>
        /// Constructor for Revision 2
        /// </summary>
        /// <param name="errorCode">The error code is specified by 5 ASCII characters. The error code begins with E and is followed by four digits. <para>Example E1021.</para></param>
        /// <param name="controllerReadyStatus">Controller ready status</param>
        /// <param name="toolReadyStatus">Tool ready status</param>
        /// <param name="time">Time stamp for the alarm</param>
        /// <param name="alarmText">Alarm text. 50 ASCII characters</param>
        /// <param name="revision">Revision (Default revision = 1)</param>
        /// <param name="ackflag">Acknowledge flag (Default = 1)</param>
        public MID_0071(string errorCode, bool controllerReadyStatus, bool toolReadyStatus, DateTime time, string alarmText, int revision = 2, int? noAckFlag = 0) 
            : this(errorCode, controllerReadyStatus, toolReadyStatus, time, revision, noAckFlag)
        {
            AlarmText = alarmText;
        }

        internal MID_0071(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                ProcessHeader(package);
                UpdateFieldsIndexBasedOnRevision(HeaderData.Revision);
                ProcessDataFields(package);
                return this;
            }

            return NextTemplate.Parse(package);
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.ERROR_CODE, 20, 4, ' ', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.CONTROLLER_READY_STATUS, 26, 1),
                                new DataField((int)DataFields.TOOL_READY_STATUS, 29, 1, ' '),
                                new DataField((int)DataFields.TIME, 32, 19)
                            }
                },
                {
                    2, new List<DataField>()
                    {
                        new DataField((int)DataFields.ALARM_TEXT, 54, 50, ' '),
                    }
                }
            };
        }

        private void UpdateFieldsIndexBasedOnRevision(int? revision)
        {
            if (revision > 1)
            {
                RevisionsByFields[1][(int)DataFields.ERROR_CODE].Size = 5;
                for (int i = (int)DataFields.CONTROLLER_READY_STATUS; i < (int)DataFields.TIME + 1; i++)
                    RevisionsByFields[1][i].Index++;
            }
        }

        public enum DataFields
        {
            ERROR_CODE,
            CONTROLLER_READY_STATUS,
            TOOL_READY_STATUS,
            TIME,
            //Rev 2
            ALARM_TEXT
        }
    }
}
