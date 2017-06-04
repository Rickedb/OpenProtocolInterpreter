using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.IOInterface
{
    public class DigitalInput
    {
        private List<DataField> fields;
        public DigitalInputNumber Number { get; set; }
        public bool Status { get; set; }

        public DigitalInput()
        {
            this.fields = new List<DataField>();
            this.registerDatafields();
        }

        public string buildPackage()
        {
            string pkg = string.Empty;
            pkg += ((int)this.Number).ToString().PadLeft(3, '0');
            pkg += Convert.ToInt32(this.Status).ToString();
            return pkg;
        }

        public IEnumerable<DigitalInput> getDigitalInputsFromPackage(string package)
        {
            List<DigitalInput> digIns = new List<DigitalInput>();
            for (int i = 0; i < package.Length; i += 4)
                digIns.Add(this.getDigIn(package.Substring(i, i + 4)));
            return digIns;
        }

        private DigitalInput getDigIn(string package)
        {
            DigitalInput obj = new DigitalInput();
            obj.Number = (DigitalInputNumber)Convert.ToInt32(package.Substring(this.fields[(int)DataFields.DIGITAL_INPUT_NUMBER].Index, this.fields[(int)DataFields.DIGITAL_INPUT_NUMBER].Size));
            obj.Status = Convert.ToBoolean(Convert.ToInt32(package.Substring(this.fields[(int)DataFields.DIGITAL_INPUT_STATUS].Index, this.fields[(int)DataFields.DIGITAL_INPUT_STATUS].Size)));
            return obj;
        }

        private void registerDatafields()
        {
            this.fields.AddRange(
                new DataField[]
                {
                            new DataField((int)DataFields.DIGITAL_INPUT_NUMBER, 0, 3),
                            new DataField((int)DataFields.DIGITAL_INPUT_STATUS, 2, 1)
                });
        }

        public enum DataFields
        {
            DIGITAL_INPUT_NUMBER,
            DIGITAL_INPUT_STATUS
        }

        public enum DigitalInputNumber
        {
            OFF = 0,
            RESET_BATCH = 1,
            UNLOCK_TOOL = 2,
            TOOL_DISABLE_NO = 3,
            TOOL_DISABLE_NC = 4,
            TOOL_TIGHTENING_DISABLE = 5,
            TOOL_LOOSENING_DISABLE = 6,
            REMOTE_START_PULSE = 7,
            REMOTE_START_CONT = 8,
            TOOL_START_LOOSENING = 9,
            BATCH_INCREMENT = 10,
            BYPASS_PSET = 11,
            ABORT_JOB = 12,
            JOB_OFF = 13,
            PARAMETER_SET_TOGGLE = 14,
            RESET_RELAYS = 15,
            PARAMETER_SET_SELECT_BIT_0 = 16,
            PARAMETER_SET_SELECT_BIT_1 = 17,
            PARAMETER_SET_SELECT_BIT_2 = 18,
            PARAMETER_SET_SELECT_BIT_3 = 19,
            JOB_SELECT_BIT_0 = 20,
            JOB_SELECT_BIT_1 = 21,
            JOB_SELECT_BIT_2 = 22,
            JOB_SELECT_BIT_3 = 23,

            LINE_CONTROL_START = 28,
            LINE_CONTROL_ALERT_1 = 29,
            LINE_CONTROL_ALERT_2 = 30,
            ACK_ERROR_MESSAGE = 31,
            FIELDBUS_DIGIN_1 = 32,
            FIELDBUS_DIGIN_2 = 33,
            FIELDBUS_DIGIN_3 = 34,
            FIELDBUS_DIGIN_4 = 35,
            FLASH_TOOL_GREEN_LIGHT = 36,

            PARAMETER_SET_SELECT_BIT_4 = 45,
            PARAMETER_SET_SELECT_BIT_5 = 46,
            PARAMETER_SET_SELECT_BIT_6 = 47,
            PARAMETER_SET_SELECT_BIT_7 = 48,
            JOB_SELECT_BIT_4 = 49,
            JOB_SELECT_BIT_5 = 50,
            JOB_SELECT_BIT_6 = 51,
            JOB_SELECT_BIT_7 = 52,
            BATCH_DECREMENT = 53,
            JOB_RESTART = 54,
            END_OF_CYCLE = 55,

            CLICK_WRENCH_1 = 62,
            CLICK_WRENCH_2 = 63,
            CLICK_WRENCH_3 = 64,
            CLICK_WRENCH_4 = 65,
            ID_CARD = 66,
            AUTOMATIC_MODE = 67,
            EXTERNAL_MONITORED_1 = 68,
            EXTERNAL_MONITORED_2 = 69,
            EXTERNAL_MONITORED_3 = 70,
            EXTERNAL_MONITORED_4 = 71,
            EXTERNAL_MONITORED_5 = 72,
            EXTERNAL_MONITORED_6 = 73,
            EXTERNAL_MONITORED_7 = 74,
            EXTERNAL_MONITORED_8 = 75,
            SELECT_NEXT_PARAMETER_SET = 76,
            SELECT_PREVIOUS_PARAMETER_SET = 77,

            TIMER_ENABLE_TOOL = 79,
            MASTER_UNLOCK_TOOL = 80,
            ST_SCAN_REQUEST = 81,
            DISCONNECT_TOOL = 82,
            JOB_SELECT_BIT_8 = 83,
            PARAMETER_SET_SELECT_BIT_8 = 84,
            REQUEST_ST_SCAN = 85,
            RESET_NOK_COUNTER = 86,
            BYPASS_IDENTIFIER = 87,
            RESET_LATEST_IDENTIFIER = 88,
            RESET_ALL_IDENTIFIER = 89,
            SET_HOME_POSITION = 90,
            DIGOUT_MONITORED_1 = 91,
            DIGOUT_MONITORED_2 = 92,
            DIGOUT_MONITORED_3 = 93,
            DIGOUT_MONITORED_4 = 94,
            DISABLE_ST_SCANNER = 95,
            DISABLE_FIELDBUS_CARRIED_SIGNALS = 96,
            TOGGLE_CW_CCW = 97,
            TOGGLE_CW_CCW_FOR_NEXT_RUN = 98,
            SET_CCW = 99,

            OPEN_PROTOCOL_COMMANDS_DISABLE = 104,
            LOGIC_DIG_IN_1 = 105,
            LOGIC_DIG_IN_2 = 106,
            LOGIC_DIG_IN_3 = 107,
            LOGIC_DIG_IN_4 = 108,
            LOGIC_DIG_IN_5 = 109,
            LOGIC_DIG_IN_6 = 110,
            LOGIC_DIG_IN_7 = 111,
            LOGIC_DIG_IN_8 = 112,
            LOGIC_DIG_IN_9 = 113,
            LOGIC_DIG_IN_10 = 114,

            FORCED_CCW_ONCE = 120,
            FORCED_CCW_TOGGLE = 121,
            FORCED_CW_ONCE = 122,
            FORCED_CW_TOGGLE = 123,

            PSET_SELECT_BIT_9 = 129,
            STORE_CURRENT_TIGHTENING_PROGRAM_IN_THE_TOOL = 130,
            ACTIVE_XML_RESULT_SEND = 131,
            TOOL_IN_WORK_SPACE = 132,
            TOOL_IN_PRODUCT_SPACE = 133,
            FLASH_TOOL_YELLOW_LIGHT = 134,
            XML_EMERGENCY_MODE = 135,
            MFU_TEST = 136,
            TOOL_IN_PARK_POSITION = 137,

            PULSOR_TOOL_ENABLE = 150,
            PERFORM_AIR_HOSE_TEST = 151,
            LAST_DIGIN = 152,

            TOOL_BLUE_LIGHT_IO_CONTROLLED = 201,
            TOOL_BLUE_LIGHT = 202,
            TOOL_GREEN_LIGHT_IO_CONTROLLED = 203,
            TOOL_GREEN_LIGHT = 204,
            TOOL_RED_LIGHT_IO_CONTROLLED = 205,
            TOOL_RED_LIGHT = 206,
            TOOL_YELLOW_LIGHT_IO_CONTROLLED = 207,
            TOOL_YELLOW_LIGHT = 208,
            TOOL_WHITE_LIGHT_IO_CONTROLLED = 209,
            TOOL_WHITE_LIGHT = 210
        }
    }
}
