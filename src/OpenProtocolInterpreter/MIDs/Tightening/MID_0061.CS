using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCX.ITLC.UMI.AtlasCopco.OpenProtocol.MIDs.Tightening
{
    /// <summary>
    /// MID: Last tightening result data
    /// Description: Upload the last tightening result.
    /// Message sent by: Controller
    /// Answer: MID 0062 Last tightening result data acknowledge
    /// </summary>
    public class MID_0061 : MID
    {
        private readonly Interfaces.IMID nextTemplate;

        private const int length = 231;
        private const int mid = 61;
        private const int revision = 1;

        public MID_0061() : base(length, mid, revision)
        {

        }

        public MID_0061(Interfaces.IMID nextTemplate) : base(length, mid, revision)
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
                    new DataField((int)DataFields.CELL_ID, 0, 4),
                    new DataField((int)DataFields.CHANNEL_ID, 4, 2),
                    new DataField((int)DataFields.TORQUE_CONTROLLER_NAME, 6, 25),
                    new DataField((int)DataFields.VIN_NUMBER, 31, 25),
                    new DataField((int)DataFields.JOB_ID, 56, 2),
                    new DataField((int)DataFields.PARAMETER_SET_ID, 58, 3),
                    new DataField((int)DataFields.BATCH_SIZE, 61, 
                    new DataField((int)DataFields.BATCH_COUNTER
                    new DataField((int)DataFields.TIGHTENING_STATUS
                    new DataField((int)DataFields.TORQUE_STATUS
                    new DataField((int)DataFields.ANGLE_STATUS
                    new DataField((int)DataFields.TORQUE_MIN_LIMIT
                    new DataField((int)DataFields.TORQUE_MAX_LIMIT
                    new DataField((int)DataFields.TORQUE_FINAL_TARGET
                    new DataField((int)DataFields.TORQUE
                    new DataField((int)DataFields.ANGLE_MIN_LIMIT
                    new DataField((int)DataFields.ANGLE_MAX_LIMIT
                    new DataField((int)DataFields.ANGLE_FINAL_TARGET
                    new DataField((int)DataFields.ANGLE
                    new DataField((int)DataFields.TIMESTAMP
                    new DataField((int)DataFields.LAST_CHANGE_IN_PARAMETER_SET
                    new DataField((int)DataFields.BATCH_STATUS
                    new DataField((int)DataFields.TIGHTENING_ID
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
