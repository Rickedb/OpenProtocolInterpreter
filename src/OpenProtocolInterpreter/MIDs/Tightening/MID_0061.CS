using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.Tightening
{
    /// <summary>
    /// MID: Last tightening result data
    /// Description: Upload the last tightening result.
    /// Message sent by: Controller
    /// Answer: MID 0062 Last tightening result data acknowledge
    /// </summary>
    public class MID_0061 : MID
    {
        private readonly IMID nextTemplate;

        private const int length = 231;
        private const int mid = 61;
        private const int revision = 1;

        public MID_0061() : base(length, mid, revision)
        {

        }

        public MID_0061(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if(base.isCorrectType(package))
            {

            }

            return this.nextTemplate.processPackage(package);
        }

        private void registerDatafields()
        {
            this.RegisteredDataFields.AddRange(
                new DataField[]
                {
                    new DataField((int)DataFields.CELL_ID, 20, 4),
                    new DataField((int)DataFields.CHANNEL_ID, 26, 2),
                    new DataField((int)DataFields.TORQUE_CONTROLLER_NAME, 30, 25),
                    new DataField((int)DataFields.VIN_NUMBER, 57, 25),
                    new DataField((int)DataFields.JOB_ID, 84, 2),
                    new DataField((int)DataFields.PARAMETER_SET_ID, 88, 3),
                    new DataField((int)DataFields.BATCH_SIZE, 93, 4),
                    new DataField((int)DataFields.BATCH_COUNTER, 99, 4),
                    new DataField((int)DataFields.TIGHTENING_STATUS, 105, 1),
                    new DataField((int)DataFields.TORQUE_STATUS, 108, 1),
                    new DataField((int)DataFields.ANGLE_STATUS, 111, 1),
                    new DataField((int)DataFields.TORQUE_MIN_LIMIT, 114, 6),
                    new DataField((int)DataFields.TORQUE_MAX_LIMIT, 122, 6),
                    new DataField((int)DataFields.TORQUE_FINAL_TARGET, 130, 6),
                    new DataField((int)DataFields.TORQUE, 138, 6),
                    new DataField((int)DataFields.ANGLE_MIN_LIMIT, 146, 5),
                    new DataField((int)DataFields.ANGLE_MAX_LIMIT, 153, 5),
                    new DataField((int)DataFields.ANGLE_FINAL_TARGET, 160, 5),
                    new DataField((int)DataFields.ANGLE, 167, 5),
                    new DataField((int)DataFields.TIMESTAMP, 174, 19),
                    new DataField((int)DataFields.LAST_CHANGE_IN_PARAMETER_SET, 195, 19),
                    new DataField((int)DataFields.BATCH_STATUS, 216, 1),
                    new DataField((int)DataFields.TIGHTENING_ID, 219, 10)
                });
        }

        public enum DataFields
        {
            CELL_ID,
            CHANNEL_ID,
            TORQUE_CONTROLLER_NAME,
            VIN_NUMBER,
            JOB_ID,
            PARAMETER_SET_ID,
            BATCH_SIZE,
            BATCH_COUNTER,
            TIGHTENING_STATUS,
            TORQUE_STATUS,
            ANGLE_STATUS,
            TORQUE_MIN_LIMIT,
            TORQUE_MAX_LIMIT,
            TORQUE_FINAL_TARGET,
            TORQUE,
            ANGLE_MIN_LIMIT,
            ANGLE_MAX_LIMIT,
            ANGLE_FINAL_TARGET,
            ANGLE,
            TIMESTAMP,
            LAST_CHANGE_IN_PARAMETER_SET,
            BATCH_STATUS,
            TIGHTENING_ID
        }
    }
}
