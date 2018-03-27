﻿using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// MID: Application Communication negative acknowledge
    /// Description: 
    ///     This message is used by the controller when a request, command or subscription for any reason has 
    ///     not been performed. 
    ///     The data field contains the message ID of the message request that failed as well as an error code.
    ///     It can also be used by the integrator to acknowledge received subscribed data/events upload and will
    ///     then do all the special subscription data acknowledges obsolete.
    ///     When using the communication acknowledgement of MID 0007 and MID 0006 together with sequence 
    ///     numbering this is an application level message only.
    /// 
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0004 : MID, ICommunication
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 4;

        public int FailedMid
        {
            get => RevisionsByFields[1][(int)DataFields.MID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.MID].SetValue(_intConverter.Convert, value);
        }
        public Errors ErrorCode
        {
            get => (Errors)RevisionsByFields[1][(int)DataFields.ERROR_CODE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.ERROR_CODE].SetValue(_intConverter.Convert, (int)value);
        }

        public MID_0004() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="failedMid">Failed Mid. Range: 0000-9999</param>
        /// <param name="errorCode"></param>
        public MID_0004(int failedMid, Errors errorCode) : this()
        {
            FailedMid = failedMid;
            ErrorCode = errorCode;
        }

        internal MID_0004(IMID nextTemplate) : this() => NextTemplate = nextTemplate;

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            List<string> failed = new List<string>();
            if (FailedMid < 1 || FailedMid > 9999)
                failed.Add(new ArgumentOutOfRangeException(nameof(FailedMid), "Range: 0000-9999").Message);

            errors = failed;
            return failed.Count > 0;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.MID, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.ERROR_CODE, 26, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                            }
                }
            };
        }


        public enum DataFields
        {
            MID,
            ERROR_CODE
        }

        /// <summary>
        /// Enum that contains ALL MID 0004 errors
        /// </summary>
        public enum Errors
        {
            NO_ERROR = 00,
            INVALID_DATA = 01,
            PARAMETER_SET_ID_NOT_PRESENT = 02,
            PARAMETER_SET_CANNOT_BE_SET = 03,
            PARAMETER_SET_NOT_RUNNING = 04,
            VIN_UPLOAD_SUBSCRIPTION_ALREADY_EXISTS = 06,
            VIN_UPLOAD_SUBSCRIPTION_DOESNT_EXISTS = 07,
            VIN_INPUT_SOURCE_NOT_GRANTED = 08,
            LAST_TIGHTENING_RESULT_SUBSCRIPTION_ALREADY_EXISTS = 09,
            LAST_TIGHTENING_RESULT_SUBSCRIPTION_DOESNT_EXISTS = 10,
            ALARM_SUBSCRIPTION_ALREADY_EXISTS = 11,
            ALARM_SUBSCRIPTION_DOESNT_EXISTS = 12,
            PARAMETER_SET_SELECTION_SUBSCRIPTION_ALREADY_EXISTS = 13,
            PARAMETER_SET_SELECTION_SUBSCRIPTION_DOESNT_EXISTS = 14,
            TIGHTENING_ID_REQUESTED_NOT_FOUND = 15,
            CONNECTION_REJECTED_PROTOCOL_BUSY = 16,
            JOB_ID_NOT_PRESENT = 17,
            JOB_INFO_SUBSCRIPTION_ALREADY_EXISTS = 18,
            JOB_INFO_SUBSCRIPTION_DOESNT_EXISTS = 19,
            JOB_CANNOT_BE_SET = 20,
            JOB_NOT_RUNNING = 21,
            NOT_POSSIBLE_TO_EXECUTE_DYNAMIC_JOB_REQUEST = 22,
            JOB_BATCH_DECREMENT_FAILED = 23,
            NOT_POSSIBLE_TO_CREATE_PSET = 24,
            PROGRAMMING_CONTROL_NOT_GRANTED = 25,
            CONTROLLER_IS_NOT_A_SYNC_MASTER_OR_STATION_CONTROLLER = 30,
            MULTI_SPINDLE_STATUS_SUBSCRIPTION_ALREADY_EXISTS = 31,
            MULTI_SPINDLE_STATUS_SUBSCRIPTION_DOESNT_EXISTS = 32,
            MULTI_SPINDLE_RESULT_SUBSCRIPTION_ALREADY_EXISTS = 33,
            MULTI_SPINDLE_RESULT_SUBSCRIPTION_DOESNT_EXISTS = 34,
            JOB_LINE_CONTROL_INFO_SUBSCRIPTION_ALREADY_EXISTS = 40,
            JOB_LINE_CONTROL_INFO_SUBSCRIPTION_DOESNT_EXISTS = 41,
            IDENTIFIER_INPUT_SOURCE_NOT_GRANTED = 42,
            MULTIPLE_IDENTIFIERS_WORK_ORDER_SUBSCRIPTION_ALREADY_EXISTS = 43,
            MULTIPLE_IDENTIFIERS_WORK_ORDER_SUBSCRIPTION_DOESNT_EXISTS = 44,
            STATUS_EXTERNAL_MONITORED_INPUTS_SUBSCRIPTION_ALREADY_EXISTS = 50,
            STATUS_EXTERNAL_MONITORED_INPUTS_SUBSCRIPTION_DOESNT_EXISTS = 51,
            IO_DEVICE_NOT_CONNECTED = 52,
            FAULTY_IO_DEVICE_ID = 53,
            TOOL_TAG_ID_UNKNOWN = 54,
            TOOL_TAG_ID_SUBSCRIPTION_ALREADY_EXISTS = 55,
            TOOL_TAG_ID_SUBSCRIPTION_DOESNT_EXISTS = 56,
            TOOL_MOTOR_TUNING_FAILED = 57,
            NO_ALARM_PRESENT = 58,
            TOOL_CURRENTLY_IN_USE = 59,
            NO_HISTOGRAM_AVAILABLE = 60,
            CALIBRATION_FAILED = 70,
            SUBSCRIPTION_ALREADY_EXISTS = 71,
            SUBSCRIPTION_DOESNT_EXISTS = 72,
            COMMAND_FAILED = 79,
            AUTOMATIC_MANUAL_MODE_SUBSCRIBE_ALREADY_EXISTS = 82,
            AUTOMATIC_MANUAL_MODE_SUBSCRIBE_DOESNT_EXISTS = 83,
            RELAY_FUNCTION_SUBSCRIPTION_ALREADY_EXISTS = 84,
            RELAY_FUNCTION_SUBSCRIPTION_DOESNT_EXISTS = 85,
            SELECTOR_SOCKET_INFO_SUBSCRIPTION_ALREADY_EXISTS = 86,
            SELECTOR_SOCKET_INFO_SUBSCRIPTION_DOESNT_EXISTS = 87,
            DIGIN_INFO_SUBSCRIPTION_ALREADY_EXISTS = 88,
            DIGIN_INFO_SUBSCRIPTION_DOESNT_EXISTS = 89,
            LOCK_AT_BATCH_DONE_SUBSCRIPTION_ALREADY_EXISTS = 90,
            LOCK_AT_BATCH_DONE_SUBSCRIPTION_DOESNT_EXISTS = 91,
            OPEN_PROTOCOL_COMMANDS_DISABLED = 92,
            OPEN_PROTOCOL_COMMANDS_DISABLED_SUBSCRIPTION_ALREADY_EXISTS = 93,
            OPEN_PROTOCOL_COMMANDS_DISABLED_SUBSCRIPTION_DOESNT_EXISTS = 94,
            REJECT_REQUEST_POWER_MACS_IS_IN_MANUAL_MODE = 95,
            CLIENT_ALREADY_CONNECTED = 96,
            MID_REVISION_UNSUPPORTED = 97,
            CONTROLLER_INTERNAL_REQUEST_TIMEOUT = 98,
            UNKNOWN_MID = 99
        }
    }
}
