using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.MultiSpindle.Result
{
    /// <summary>
    /// MID: Multi-spindle result
    /// Description:
    ///     The multi-spindle result is sent after each sync tightening and if it is subscribed. The multiple results
    ///     contain the common status of the multiple as well as the individual tightening result(torque and angle)
    ///     of each spindle.
    ///     This telegram is also used for PowerMACS systems running a Press.The layout of the telegram is
    ///     exactly the same but some of the fields have slightly different definitions.The fields for Torque are
    ///     used for Force values and the fields for Angle are used for Stroke values. A press system always uses
    ///     revision 4 or higher of the telegram.
    /// Message sent by: Controller
    /// Answer: MID 0102 Multi-spindle result acknowledge
    /// </summary>
    public class MID_0101 : MID, IMultiSpindle
    {
        public const int MID = 101;
        private const int length = 193;
        private const int revision = 1;

        public int NumberOfSpindles { get; set; }
        public string VINNumber { get; set; }
        public int JobId { get; set; }
        public int ParameterSetId { get; set; }
        public int BatchSize { get; set; }
        public int BatchCounter { get; set; }
        public double TorqueMinLimit { get; set; }
        public double TorqueMaxLimit { get; set; }
        public double TorqueFinalTarget { get; set; }
        public int AngleMin { get; set; }
        public int AngleMax { get; set; }
        public int FinalAngleTarget { get; set; }
        public DateTime LastChangeInParameterSet { get; set; }
        public DateTime TimeStamp { get; set; }
        public int SyncTighteningId { get; set; }
        public bool SyncOverallStatus { get; set; }
        public List<SpindleStatuses> SpindleStatus { get; set; }


        public MID_0101(bool ackFlag) : base(length, MID, revision, Convert.ToInt32(ackFlag)) { }

        internal MID_0101(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            string package = base.buildHeader();
            package += this.JobId.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.JOB_ID].Size, '0');
            return package;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                this.HeaderData = base.processHeader(package);

                var datafield = this.RegisteredDataFields[(int)DataFields.JOB_ID];
                this.JobID = Convert.ToInt32(package.Substring(datafield.Index, datafield.Size));

                return this;
            }

            return this.nextTemplate.processPackage(package);
        }


        protected override void registerDatafields()
        {
            this.RegisteredDataFields.AddRange(new DataField[] {
                new DataField((int)DataFields.NUMBER_OF_SPINDLES, 20, 2),
                new DataField((int)DataFields.VIN_NUMBER, 24, 25),
                new DataField((int)DataFields.JOB_ID, 51, 2),
                new DataField((int)DataFields.PARAMETER_SET_ID, 55, 3),
                new DataField((int)DataFields.BATCH_SIZE, 60, 4),
                new DataField((int)DataFields.BATCH_COUNTER, 67, 4),
                new DataField((int)DataFields.BATCH_STATUS, 72, 1),
                new DataField((int)DataFields.TORQUE_MIN_LIMIT, 75, 6),
                new DataField((int)DataFields.TORQUE_MAX_LIMIT, 83, 6),
                new DataField((int)DataFields.TORQUE_FINAL_TARGET, 91, 6),
                new DataField((int)DataFields.ANGLE_MIN, 99, 5),
                new DataField((int)DataFields.ANGLE_MAX, 106, 5),
                new DataField((int)DataFields.FINAL_ANGLE_TARGET, 113, 5),
                new DataField((int)DataFields.DATETIME_OF_LAST_CHANGE_IN_PARAMETER_SET, 120, 19),
                new DataField((int)DataFields.TIMESTAMP, 141, 19),
                new DataField((int)DataFields.SYNC_TIGHTENING_ID, 162, 5),
                new DataField((int)DataFields.SYNC_OVERALL_STATUS, 169, 1),
                new DataField((int)DataFields.SPINDLE_STATUS, 172, 18)
            });
        }

        public enum DataFields
        {
            NUMBER_OF_SPINDLES,
            VIN_NUMBER,
            JOB_ID,
            PARAMETER_SET_ID,
            BATCH_SIZE,
            BATCH_COUNTER,
            BATCH_STATUS,
            TORQUE_MIN_LIMIT,
            TORQUE_MAX_LIMIT,
            TORQUE_FINAL_TARGET,
            ANGLE_MIN,
            ANGLE_MAX,
            FINAL_ANGLE_TARGET,
            DATETIME_OF_LAST_CHANGE_IN_PARAMETER_SET,
            TIMESTAMP,
            SYNC_TIGHTENING_ID,
            SYNC_OVERALL_STATUS,
            SPINDLE_STATUS
        }

        public class SpindleStatuses
        {
            private List<DataField> fields;
            public int SpindleNumber { get; set; }
            public bool TighteningStatus { get; set; }
            public TorqueStatuses TorqueStatus { get; set; }
            public double Torque { get; set; }
            public bool AngleStatus { get; set; }
            public int Angle { get; set; }

            public SpindleStatuses()
            {
                this.registerDatafields();
            }

            private void registerDatafields()
            {
                this.fields = new List<DataField>();
                this.fields.AddRange(new DataField[] {
                new DataField((int)DataFields.SPINDLE_NUMBER, 174, 2),
                new DataField((int)DataFields.TIGHTENING_STATUS, 178, 1),
                new DataField((int)DataFields.TORQUE_STATUS, 179, 1),
                new DataField((int)DataFields.TORQUE, 180, 6),
                new DataField((int)DataFields.ANGLE_STATUS, 186, 1),
                new DataField((int)DataFields.ANGLE, 187, 5)
            });
            }

            public enum TorqueStatuses
            {
                LOW = 0,
                OK = 1,
                NOK = 2
            }

            public enum DataFields
            {
                SPINDLE_NUMBER,
                TIGHTENING_STATUS,
                TORQUE_STATUS,
                TORQUE,
                ANGLE_STATUS,
                ANGLE
            }
        }
    }
}
