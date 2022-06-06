using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Alarm
    /// <para>An alarm has appeared in the controller. The current alarm is uploaded from the controller to the integrator.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0072"/> Alarm acknowledge</para>
    /// </summary>
    public class Mid0071 : Mid, IAlarm, IController
    {
        private IValueConverter<bool> _boolConverter;
        private IValueConverter<DateTime> _dateConverter;
        private const int LAST_REVISION = 2;
        public const int MID = 71;

        public string ErrorCode
        {
            get => GetField(1, (int)DataFields.ERROR_CODE).Value;
            set => GetField(1, (int)DataFields.ERROR_CODE).SetValue(value);
        }
        public bool ControllerReadyStatus
        {
            get => GetField(1, (int)DataFields.CONTROLLER_READY_STATUS).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.CONTROLLER_READY_STATUS).SetValue(_boolConverter.Convert, value);
        }
        public bool ToolReadyStatus
        {
            get => GetField(1, (int)DataFields.TOOL_READY_STATUS).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.TOOL_READY_STATUS).SetValue(_boolConverter.Convert, value);
        }
        public DateTime Time
        {
            get => GetField(1, (int)DataFields.TIME).GetValue(_dateConverter.Convert);
            set => GetField(1, (int)DataFields.TIME).SetValue(_dateConverter.Convert, value);
        }
        //Rev 2
        public string AlarmText
        {
            get => GetField(2, (int)DataFields.ALARM_TEXT).Value;
            set => GetField(2, (int)DataFields.ALARM_TEXT).SetValue(value);
        }

        public Mid0071() : this(LAST_REVISION)
        {

        }

        public Mid0071(Header header) : base(header)
        {
            _boolConverter = new BoolConverter();
            _dateConverter = new DateConverter();
            HandleRevision();
        }

        public Mid0071(int revision = LAST_REVISION) : this(new Header()
        {
            Revision = revision,
            Mid = MID
        })
        {
            _boolConverter = new BoolConverter();
            _dateConverter = new DateConverter();
            HandleRevision();
        }

        /// <summary>
        /// Constructor for Revision 1
        /// </summary>
        /// <param name="errorCode">The error code is specified by 4 ASCII characters. The error code begins with E and is followed by three digits. <para>Example E851.</para></param>
        /// <param name="controllerReadyStatus">Controller ready status</param>
        /// <param name="toolReadyStatus">Tool ready status</param>
        /// <param name="time">Time stamp for the alarm</param>
        /// <param name="revision">Revision (Default revision = 1)</param>
        public Mid0071(string errorCode, bool controllerReadyStatus, bool toolReadyStatus, DateTime time, int revision = 1) : this(revision)
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
        public Mid0071(string errorCode, bool controllerReadyStatus, bool toolReadyStatus, DateTime time, string alarmText, int revision = 2)
            : this(errorCode, controllerReadyStatus, toolReadyStatus, time, revision)
        {
            AlarmText = alarmText;
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            HandleRevision();
            ProcessDataFields(package);
            return this;
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

        private void HandleRevision()
        {
            var errorCodeField = GetField(1, (int)DataFields.ERROR_CODE);
            if (Header.Revision > 1)
            {
                errorCodeField.Size = 5;
            }
            else
            {
                errorCodeField.Size = 4;
            }

            int index = errorCodeField.Index + errorCodeField.Size;
            for (int i = (int)DataFields.CONTROLLER_READY_STATUS; i < RevisionsByFields[1].Count; i++)
            {
                var field = GetField(1, i);
                field.Index = 2 + index;
                index = field.Index + field.Size;
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
