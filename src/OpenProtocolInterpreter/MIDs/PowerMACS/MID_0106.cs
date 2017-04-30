using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.PowerMACS
{
    /// <summary>
    /// MID: Last PowerMACS tightening result Station data
    /// Description: 
    ///    This MID contains the station part and some of the Bolt data of the last result data. After this message
    ///    has been sent the integrator selects if it also wants to have the Bolt and step data.If this data is
    ///    requested, then the integrator sends the message MID 0108 Last PowerMACS tightening result data
    ///    acknowledge, with the parameter Bolt Data set to TRUE. If only the station data is wanted the
    ///    parameter Bolt Data is set to FALSE.
    ///    This telegram is also used for Power MACS systems running a Press. The layout of the telegram is
    ///    exactly the same but some of the fields have slightly different definitions. The fields for Torque are
    ///    used for Force values and the fields for Angle are used for Stroke values. Press systems also use
    ///    different identifiers for the optional data on bolt and step level. A press system always use revision 4
    ///    or higher of the telegram
    ///    Note: All values that are undefined in the results will be sent as all spaces (ASCII 0x20). This will for
    ///    instance happen with the Torque Status if no measuring value for Bolt T was available for the
    ///    tightening.
    /// Message sent by: Controller
    /// Answer: MID 0108 Last Power MACS tightening result data acknowledge
    /// </summary>
    internal class MID_0106 : MID, IPowerMACS
    {
        public const int MID = 106;
        private const int length = 9999;
        private const int revision = 1;

        public MID_0106() : base(length, MID, revision) { }

        internal MID_0106(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {

            }

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }

        public enum DataFields
        {
            TOTAL_NUMBER_OF_MESSAGES,
            MESSAGE_NUMBER,
            DATA_NUMBER_SYSTEM,
            STATION_NUMBER,
            STATION_NAME,
            TIME,
            MODE_NUMBER,
            MODE_NAME,
            SIMPLE_STATUS,
            PM_STATUS,
            WP_ID,
            NUMBER_OF_BOLTS,
            BOLT_DATA
        }

        public class BoltData
        {
            private List<DataField> fields;
            public int OrdinalBoltNumber { get; set; }
            public bool SimpleBoltStatus { get; set; }
            public int TorqueStatus { get; set; }
            public int AngleStatus { get; set; }
            public float BoltTorque { get; set; }
            public float BoltAngle { get; set; }
            public float BoltTorqueHighLimit { get; set; }
            public float BoltTorqueLowLimit { get; set; }
            public float BoltAngleHighLimit { get; set; }
            public float BoltAngleLowLimit { get; set; }
            public int NumberOfSpecialValues { get; set; }
            public List<SpecialValue> SpecialValues { get; set; }

            public IEnumerable<BoltData> getBoltDatasFromPackage(string package)
            {
                List<BoltData> obj = new List<BoltData>();


                return obj;
            }

            private void registerDatafields()
            {
                this.fields.AddRange(
                    new DataField[]
                    {
                            new DataField((int)DataFields.ORDINAL_BOLT_NUMBER, 0, 2),
                            new DataField((int)DataFields.SIMPLE_BOLT_STATUS, 4, 1),
                            new DataField((int)DataFields.TORQUE_STATUS, 7, 1),
                            new DataField((int)DataFields.ANGLE_STATUS, 10, 1),
                            new DataField((int)DataFields.BOLT_TORQUE, 23, 7),
                            new DataField((int)DataFields.BOLT_ANGLE, 32, 7),
                            new DataField((int)DataFields.BOLT_TORQUE_HIGH_LIMIT, 41, 7),
                            new DataField((int)DataFields.BOLT_TORQUE_LOW_LIMIT, 50, 7),
                            new DataField((int)DataFields.BOLT_ANGLE_HIGH_LIMIT, 59, 7),
                            new DataField((int)DataFields.BOLT_ANGLE_LOW_LIMIT, 68, 7),
                            new DataField((int)DataFields.NUMBER_OF_SPECIAL_VALUES, 77, 2)
                    });
            }

            public enum TorqueStatuses
            {
                UNDEFINED = - 1,
                BOLT_TORQUE_LOW = 0,
                BOLT_TORQUE_OK = 1,
                BOLT_TORQUE_HIGH = 2
            }

            public enum AngleStatuses
            {
                UNDEFINED = -1,
                BOLT_ANGLE_LOW = 0,
                BOLT_ANGLE_OK = 1,
                BOLT_ANGLE_HIGH = 2
            }

            public enum DataFields
            {
                ORDINAL_BOLT_NUMBER,
                SIMPLE_BOLT_STATUS,
                TORQUE_STATUS,
                ANGLE_STATUS,
                BOLT_TORQUE,
                BOLT_ANGLE,
                BOLT_TORQUE_HIGH_LIMIT,
                BOLT_TORQUE_LOW_LIMIT,
                BOLT_ANGLE_HIGH_LIMIT,
                BOLT_ANGLE_LOW_LIMIT,
                NUMBER_OF_SPECIAL_VALUES
            }

            public class SpecialValue
            {
                private List<DataField> fields;
                public string VariableName { get; set; }
                public int Type { get; set; }
                public int Length { get; set; }
                public object Value { get; set; }

                public SpecialValue()
                {
                    this.registerDatafields();
                }

                public IEnumerable<SpecialValue> getSpecialValuesFromPackage(string package)
                {
                    List<SpecialValue> obj = new List<SpecialValue>();


                    return obj;
                }

                private void registerDatafields()
                {
                    this.fields.AddRange(
                        new DataField[]
                        {
                            new DataField((int)DataFields.VARIABLE_NAME, 0, 20),
                            new DataField((int)DataFields.TYPE, 20, 2),
                            new DataField((int)DataFields.LENGTH, 22, 2),
                            new DataField((int)DataFields.VALUE, 24, 0)
                        });
                }

                public enum DataFields
                {
                    VARIABLE_NAME,
                    TYPE,
                    LENGTH,
                    VALUE
                }
            }
        }
    }
}
