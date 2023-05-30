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
    public class Mid0071 : Mid, IAlarm, IController, IAcknowledgeable<Mid0072>
    {
        public const int MID = 71;

        public string ErrorCode
        {
            get => GetField(1, (int)DataFields.ErrorCode).Value;
            set => GetField(1, (int)DataFields.ErrorCode).SetValue(value);
        }
        public bool ControllerReadyStatus
        {
            get => GetField(1, (int)DataFields.ControllerReadyStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, (int)DataFields.ControllerReadyStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool ToolReadyStatus
        {
            get => GetField(1, (int)DataFields.ToolReadyStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, (int)DataFields.ToolReadyStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime Time
        {
            get => GetField(1, (int)DataFields.Time).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, (int)DataFields.Time).SetValue(OpenProtocolConvert.ToString, value);
        }
        //Rev 2
        public string AlarmText
        {
            get => GetField(2, (int)DataFields.AlarmText).Value;
            set => GetField(2, (int)DataFields.AlarmText).SetValue(value);
        }

        public Mid0071() : this(DEFAULT_REVISION)
        {

        }

        public Mid0071(Header header) : base(header)
        {
            HandleRevision();
        }

        public Mid0071(int revision) : this(new Header()
        {
            Revision = revision,
            Mid = MID
        })
        {

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
                                new DataField((int)DataFields.ErrorCode, 20, 4, ' ', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ControllerReadyStatus, 26, 1),
                                new DataField((int)DataFields.ToolReadyStatus, 29, 1, ' '),
                                new DataField((int)DataFields.Time, 32, 19)
                            }
                },
                {
                    2, new List<DataField>()
                    {
                        new DataField((int)DataFields.AlarmText, 54, 50, ' '),
                    }
                }
            };
        }

        private void HandleRevision()
        {
            var errorCodeField = GetField(1, (int)DataFields.ErrorCode);
            if (Header.Revision > 1)
            {
                errorCodeField.Size = 5;
            }
            else
            {
                errorCodeField.Size = 4;
            }

            int index = errorCodeField.Index + errorCodeField.Size;
            for (int i = (int)DataFields.ControllerReadyStatus; i < RevisionsByFields[1].Count; i++)
            {
                var field = GetField(1, i);
                field.Index = 2 + index;
                index = field.Index + field.Size;
            }
        }

        protected enum DataFields
        {
            ErrorCode,
            ControllerReadyStatus,
            ToolReadyStatus,
            Time,
            //Rev 2
            AlarmText
        }
    }
}
