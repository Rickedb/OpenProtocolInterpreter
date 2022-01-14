﻿namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Relay Numbers. Used in <see cref="IOInterface.Mid0216"/>, <see cref="IOInterface.Mid0217"/>, <see cref="IOInterface.Mid0219"/> and <see cref="IOInterface.Relay"/>
    /// </summary>
    public enum RelayNumber
    {
        OFF = 0,
        OK = 1,
        NOK = 2,
        LOW = 3,
        HIGH = 4,
        LOW_TORQUE = 5,
        HIGH_TORQUE = 6,
        LOW_ANGLE = 7,
        HIGH_ANGLE = 8,
        CYCLE_COMPLETE = 9,
        ALARM = 10,
        BATCH_NXOK = 11,
        JOB_OK = 12,
        JOB_NOK = 13,
        JOB_RUNNING = 14,

        TOOL_HEALTH_OK = 17,
        POWER_FOCUS_READY = 18,
        TOOL_READY = 19,
        TOOL_START_SWITCH = 20,
        DIR_SWITCH_CLOCKWISE = 21,
        DIR_SWITCH_COUNTER_CLOCKWISE = 22,
        TIGHTENING_DIRECTION_COUNTER_CLOCKWISE = 23,
        TOOL_TIGHTENING = 24,
        TOOL_LOOSENING = 25,
        TOOL_RUNNING = 26,
        TOOL_RUNNING_CLOCKWISE = 27,
        TOOL_RUNNING_COUNTER_CLOCKWISE = 28,
        STATISTIC_ALARM = 29,
        TOOL_LOCKED = 30,
        RECEIVED_IDENTIFIER = 31,
        RUNNING_PSET_BIT_0 = 32,
        RUNNING_PSET_BIT_1 = 33,
        RUNNING_PSET_BIT_2 = 34,
        RUNNING_PSET_BIT_3 = 35,
        RUNNING_JOB_BIT_0 = 36,
        RUNNING_JOB_BIT_1 = 37,
        RUNNING_JOB_BIT_2 = 38,
        RUNNING_JOB_BIT_3 = 39,

        LINE_OK = 44,
        LINE_CONTROL_ALERT_1 = 45,
        LINE_CONTROL_ALERT_2 = 46,
        SERVICE_INDICATOR = 47,
        FIELDBUS_RELAY_1 = 48,
        FIELDBUS_RELAY_2 = 49,
        FIELDBUS_RELAY_3 = 50,
        FIELDBUS_RELAY_4 = 51,
        TOOL_RED_LIGHT = 52,
        TOOL_GREEN_LIGHT = 53,
        TOOL_YELLOW_LIGHT = 54,

        RUNNING_PSET_BIT_4 = 59,
        RUNNING_PSET_BIT_5 = 60,
        RUNNING_PSET_BIT_6 = 61,
        RUNNING_PSET_BIT_7 = 62,
        RUNNING_JOB_BIT_4 = 63,
        RUNNING_JOB_BIT_5 = 64,
        RUNNING_JOB_BIT_6 = 65,
        RUNNING_JOB_BIT_7 = 66,
        SYNC_OK = 67,
        SYNC_NOK = 68,
        SYNC_SPINDLE_1_OK = 69,
        SYNC_SPINDLE_1_NOK = 70,
        SYNC_SPINDLE_2_OK = 71,
        SYNC_SPINDLE_2_NOK = 72,
        SYNC_SPINDLE_3_OK = 73,
        SYNC_SPINDLE_3_NOK = 74,
        SYNC_SPINDLE_4_OK = 75,
        SYNC_SPINDLE_4_NOK = 76,
        SYNC_SPINDLE_5_OK = 77,
        SYNC_SPINDLE_5_NOK = 78,
        SYNC_SPINDLE_6_OK = 79,
        SYNC_SPINDLE_6_NOK = 80,
        SYNC_SPINDLE_7_OK = 81,
        SYNC_SPINDLE_7_NOK = 82,
        SYNC_SPINDLE_8_OK = 83,
        SYNC_SPINDLE_8_NOK = 84,
        SYNC_SPINDLE_9_OK = 85,
        SYNC_SPINDLE_9_NOK = 86,
        SYNC_SPINDLE_10_OK = 87,
        SYNC_SPINDLE_10_NOK = 88,

        LINE_CONTROL_START = 91,
        JOB_ABORTED = 92,
        EXTERNAL_CONTROLLED_1 = 93,
        EXTERNAL_CONTROLLED_2 = 94,
        EXTERNAL_CONTROLLED_3 = 95,
        EXTERNAL_CONTROLLED_4 = 96,
        EXTERNAL_CONTROLLED_5 = 97,
        EXTERNAL_CONTROLLED_6 = 98,
        EXTERNAL_CONTROLLED_7 = 99,
        EXTERNAL_CONTROLLED_8 = 100,
        EXTERNAL_CONTROLLED_9 = 101,
        EXTERNAL_CONTROLLED_10 = 102,
        TOOLSNET_CONNECTION_LOST = 103,
        OPEN_PROTOCOL_CONNECTION_LOST = 104,
        FIELDBUS_OFFLINE = 105,
        HOME_POSITION = 106,
        BATCH_NOK = 107,
        SELECTED_CHANNEL_IN_JOB = 108,
        SAFE_TO_DISCONNECT_TOOL = 109,
        RUNNING_JOB_BIT_8 = 110,
        RUNNING_PSET_BIT_8 = 111,
        CALIBRATION_ALARM = 112,
        CYCLE_START = 113,
        LOW_CURRENT = 114,
        HIGH_CURRENT = 115,
        LOW_PVT_MONITORING = 116,
        HIGH_PVT_MONITORING = 117,
        LOW_PVT_SELF_TAP = 118,
        HIGH_PVT_SELF_TAP = 119,
        LOW_TIGHTENING_ANGLE = 120,
        HIGH_TIGHTENING_ANGLE = 121,
        IDENTIFIER_IDENTIFIED = 122,
        IDENTIFIER_TYPE_1_RECEIVED = 123,
        IDENTIFIER_TYPE_2_RECEIVED = 124,
        IDENTIFIER_TYPE_3_RECEIVED = 125,
        IDENTIFIER_TYPE_4_RECEIVED = 126,

        RING_BUTTON_ACK = 129,
        DIGIN_CONTROLLED_1 = 130,
        DIGIN_CONTROLLED_2 = 131,
        DIGIN_CONTROLLED_3 = 132,
        DIGIN_CONTROLLED_4 = 133,
        FIELDBUS_CARRIED_SIGNALS_DISABLED = 134,
        ILLUMINATOR = 135,
        NEW_PARAMETER_SET_SELECTED = 136,
        NEW_JOB_SELECTED = 137,
        JOB_OFF_RELAY = 138,
        LOGIC_RELAY_1 = 139,
        LOGIC_RELAY_2 = 140,
        LOGIC_RELAY_3 = 141,
        LOGIC_RELAY_4 = 142,
        MAX_COHERENT_NOK_REACHED = 143,
        BATCH_DONE = 144,
        START_TRIGGER_ACTIVE = 145,

        COMPLETED_BATCH_BIT_0 = 251,
        COMPLETED_BATCH_BIT_1 = 252,
        COMPLETED_BATCH_BIT_2 = 253,
        COMPLETED_BATCH_BIT_3 = 254,
        COMPLETED_BATCH_BIT_4 = 255,
        COMPLETED_BATCH_BIT_5 = 256,
        COMPLETED_BATCH_BIT_6 = 257,

        REMAINING_BATCH_BIT_0 = 259,
        REMAINING_BATCH_BIT_1 = 260,
        REMAINING_BATCH_BIT_2 = 261,
        REMAINING_BATCH_BIT_3 = 262,
        REMAINING_BATCH_BIT_4 = 263,
        REMAINING_BATCH_BIT_5 = 264,
        REMAINING_BATCH_BIT_6 = 265,

        OPEN_PROTOCOL_COMMANDS_DISABLED = 275,
        CYCLE_ABORT = 276,
        EFFECTIVE_LOOSENING = 277,

        LOGIC_RELAY_5 = 278,
        LOGIC_RELAY_6 = 279,
        LOGIC_RELAY_7 = 280,
        LOGIC_RELAY_8 = 281,
        LOGIC_RELAY_9 = 282,
        LOGIC_RELAY_10 = 283,
        LOCK_AT_BATCH_DONE = 284,

        BATTERY_LOW = 287,
        BATTERY_EMPTY = 288,
        TOOL_CONNECTED = 289,
        NO_TOOL_CONNECTED = 290,

        FUNCTION_BUTTON = 293,
        REHIT = 294,
        TIGHTENING_DISABLED = 295,
        LOOSENING_DISABLED = 296,
        POSITIONING_DISABLED = 297,
        MOTOR_TUNING_DISABLED = 298,
        OPEN_END_TUNING_DISABLED = 299,
        TRACKING_DISABLED = 300,

        AUTOMATIC_MODE = 302,
        PLUS_EMERGENCY_MODE = 303,
        WEAR_INDICATOR = 304,
        DIRECTION_ALERT = 305,
        PLUS_BOLT_REWORKED = 306,
        LINE_STOP = 307,
        RUNNING_PSET_BIT_9 = 308,
        ACTIVE_XML_RESULT_ACK = 309,
        TOOL_IN_WORK_SPACE = 310,
        TOOL_IN_PRODUCT_SPACE = 311,
        XML_PROTOCOL_ACTIVE = 312,
        TOOL_ENABLED_BY_XML = 313,
        NECKING_FAILURE = 314,
        PLUS_PROTOCOL_NOT_ACTIVE = 315,
        PLUS_NO_TIGHTENING = 316,
        TAG_ID_ERROR = 317,
        JOB_ABORTION_IN_PROGRESS = 318,
        STOP_TIGHTENING = 319,
        SLOW_DOWN_TIGHTENING = 320,

        MIDDLE_COURSE_TRIGGER_ACTIVE = 351,
        FRONT_TRIGGER_ACTIVE = 352,
        REVERSE_TRIGGER_ACTIVE = 353,
        RUNNING_JOB_BIT_9 = 354,
        TOOL_UNLOCKED = 355,
        /// <summary>
        /// Indicates that the connection to the Atlas Copco license server has been lost or the synchronization has failed. 
        /// The signal is cleared when the License manager synchronization has been done successfully
        /// </summary>
        LICENSE_SERVER_CONNECTION_LOST = 356,
        /// <summary>
        /// Tightening not disabled by external source
        /// </summary>
        TIGHTENING_EXTERNALLY_ENABLED = 357,
        /// <summary>
        /// Tightening disabled by external source
        /// </summary>
        TIGHTENING_EXTERNALLY_DISABLED = 358,
        /// <summary>
        /// Loosening not disabled by external source
        /// </summary>
        LOOSENING_EXTERNALLY_ENABLED = 359,
        /// <summary>
        /// Loosening disabled by external source
        /// </summary>
        LOOSENING_EXTERNALLY_DISABLED = 360,
        /// <summary>
        /// Multistep tightening program has ended, torque has fallen below Program end torque configured.
        /// </summary>
        PROGRAM_END = 361,
        /// <summary>
        /// Oil level supervision configured in the tool maintenance to remind the users when it is time to fill up oil in a pulse tool.
        /// </summary>
        PULSE_TOOL_ALARM_OIL_LEVEL_EMPTY = 362,
        /// <summary>
        /// Indicates high tightening time resulting in NOK tightening
        /// </summary>
        TIGHTENING_TIME_HIGH = 363,
        /// <summary>
        /// Indicates low tightening time resulting in NOK tightening
        /// </summary>
        TIGHTENING_TIME_LOW = 364,
        /// <summary>
        /// Output signal tracking the function button state. The signal is set when the function button is pressed and is cleared when the function button is released.
        /// </summary>
        TOOL_FUNCTION_BUTTON_PRESSED = 365
    }
}
