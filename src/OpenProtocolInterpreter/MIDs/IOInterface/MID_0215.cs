using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.IOInterface
{
    /// <summary>
    /// MID: IO device status reply
    /// Description: 
    ///     This message is sent as an answer to the MID 0214 IO device status request.
    ///     MID 0215 revision 1 should only be used to get the status of IO devices with max 8 relays/digital
    ///     inputs.
    ///     For external I/O devices each list contain up to 8 relays/digital inputs. For the internal device the lists
    ///     contain up to 4 relays/digital inputs and the remaining 4 will be empty.
    ///     MID 0215 revision 2 can be used to get the status of all types of IO devices with up to 48 relays/digital
    ///     inputs.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    internal class MID_0215 : MID, IIOInterface
    {
        private const int length = 104;
        public const int MID = 13;
        private const int revision = 1;


        public MID_0215() : base(length, MID, revision) { }

        internal MID_0215(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            return base.buildPackage();
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processPackage(package);


                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields()
        {
            this.RegisteredDataFields.AddRange(
                new DataField[]
                {
                    new DataField((int)DataFields.IO_DEVICE_ID, 20, 3),
                    new DataField((int)DataFields.RELAY_LIST, 25, 25),
                    new DataField((int)DataFields.DIGITAL_INPUT_LIST, 52, 1)
                });
        }

        public enum DataFields
        {
            IO_DEVICE_ID,
            RELAY_LIST,
            DIGITAL_INPUT_LIST
        }

        public class Relay
        {
            public enum RelayNumbers
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
                RESERVED1 = 15,
                RESERVED2 = 16,
                NOT_USED1 = 17,
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
                NOT_USED2 = 40,
                NOT_USED3 = 41,
                NOT_USED4 = 42,
                NOT_USED5 = 43,
                LINE_OK = 44,
                LINE_CONTROL_ALERT_1 = 45,
                LINE_CONTROL_ALERT_2 = 46,
                SERVICE_INDICATOR = 47,
                FIELDBUS_RELAY_1 = 48,
                FIELDBUS_RELAY_2 = 49,
                FIELDBUS_RELAY_3 = 50,
                FIELDBUS_RELAY_4 = 51
            }
        }
    }
}
