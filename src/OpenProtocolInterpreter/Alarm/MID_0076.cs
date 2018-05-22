using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// MID: Alarm status
    /// Description: 
    ///      The alarm status is sent after an accepted subscription of the controller alarms. 
    ///      This message is used to inform the integrator that an alarm is active on the controller at subscription time.
    /// Message sent by: Controller
    /// Answer : MID 0077 Alarm status acknowledge
    /// </summary>
    public class MID_0076 : Mid, IAlarm
    {
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 76;

        public bool AlarmStatus
        {
            get => RevisionsByFields[1][(int)DataFields.ALARM_STATUS].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.ALARM_STATUS].SetValue(_boolConverter.Convert, value);
        }
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

        public MID_0076() : base(MID, LAST_REVISION)
        {
            _boolConverter = new BoolConverter();
            _dateConverter = new DateConverter();
        }

        /// <summary>
        /// Revision 1 constructor
        /// </summary>
        /// <param name="alarmStatus">0=no alarm is active, 1=an alarm is currently active</param>
        /// <param name="errorCode">The error code is specified by 4 ASCII characters. The error code begins with E and is followed by three digits. <para>Example: E851.</para></param>
        /// <param name="controllerReadyStatus">Controller ready status 1=OK, 0=NOK</param>
        /// <param name="toolReadyStatus">Tool ready status 1=OK, 0=NOK</param>
        /// <param name="time">Time stamp for the alarm</param>
        public MID_0076(bool alarmStatus, string errorCode, bool controllerReadyStatus, bool toolReadyStatus, DateTime time) : this()
        {
            AlarmStatus = alarmStatus;
            ErrorCode = errorCode;
            ControllerReadyStatus = controllerReadyStatus;
            ToolReadyStatus = toolReadyStatus;
            Time = time;
        }

        internal MID_0076(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.ALARM_STATUS, 20, 1),
                                new DataField((int)DataFields.ERROR_CODE, 23, 4, ' ', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.CONTROLLER_READY_STATUS, 29, 1),
                                new DataField((int)DataFields.TOOL_READY_STATUS, 32, 1),
                                new DataField((int)DataFields.TIME, 35, 19)
                            }
                }
            };
        }

        public enum DataFields
        {
            ALARM_STATUS,
            ERROR_CODE,
            CONTROLLER_READY_STATUS,
            TOOL_READY_STATUS,
            TIME
        }
    }
}
