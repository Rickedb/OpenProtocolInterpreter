using System;

namespace OpenProtocolInterpreter.MIDs.Tightening
{
    /// <summary>
    /// MID: Old tightening result upload reply
    /// Description: Old tightening upload.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0065 : MID, ITightening
    {
        private const int length = 118;
        private const int mid = 65;
        private const int revision = 1;
        
        public int TighteningID { get; set; }
        public string VINNumber { get; set; }
        public int ParameterSetID { get; set; }
        public int BatchCounter { get; set; }
        public bool TighteningStatus { get; set; }
        public TighteningValuesStatuses TorqueStatus { get; set; }
        public TighteningValuesStatuses AngleStatus { get; set; }
        public decimal Torque { get; set; }
        public int Angle { get; set; }
        public DateTime TimeStamp { get; set; }
        public BatchStatuses BatchStatus { get; set; }


        public MID_0065() : base(length, mid, revision)
        {

        }

        public MID_0065(IMID nextTemplate) : base(length, mid, revision)
        {
            this.registerDatafields();
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processPackage(package);

                this.TighteningID = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.TIGHTENING_ID].Value);
                this.VINNumber = base.RegisteredDataFields[(int)DataFields.VIN_NUMBER].Value.ToString();
                this.ParameterSetID = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Value);
                this.BatchCounter = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.BATCH_COUNTER].Value);
                this.TighteningStatus = Convert.ToBoolean(Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.TIGHTENING_STATUS].Value));
                this.TorqueStatus = (TighteningValuesStatuses)Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.TORQUE_STATUS].Value);
                this.AngleStatus = (TighteningValuesStatuses)Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.ANGLE_STATUS].Value);
                this.Torque = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.TORQUE].Value) / 100;
                this.Angle = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.ANGLE].Value);
                this.TimeStamp = base.RegisteredDataFields[(int)DataFields.TIMESTAMP].ToDateTime();
                this.BatchStatus = (BatchStatuses)Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.ANGLE_STATUS].Value);

                return this;
            }

            if(this.nextTemplate == null)
                throw new NotImplementedException("MID not implemented or doesn't exists");


            return this.nextTemplate.processPackage(package);
        }


        private void registerDatafields()
        {
            this.RegisteredDataFields.AddRange(
                new DataField[]
                {
                    new DataField((int)DataFields.TIGHTENING_ID, 20, 10),
                    new DataField((int)DataFields.VIN_NUMBER, 32, 25),
                    new DataField((int)DataFields.PARAMETER_SET_ID, 59, 3),
                    new DataField((int)DataFields.BATCH_COUNTER, 64, 4),
                    new DataField((int)DataFields.TIGHTENING_STATUS, 70, 1),
                    new DataField((int)DataFields.TORQUE_STATUS, 73, 1),
                    new DataField((int)DataFields.ANGLE_STATUS, 76, 1),
                    new DataField((int)DataFields.TORQUE, 79, 6),
                    new DataField((int)DataFields.ANGLE, 87, 5),
                    new DataField((int)DataFields.TIMESTAMP, 94, 19),
                    new DataField((int)DataFields.BATCH_STATUS, 115, 1)
                });
        }

        public enum DataFields
        {
            TIGHTENING_ID,
            VIN_NUMBER,
            PARAMETER_SET_ID,
            BATCH_COUNTER,
            TIGHTENING_STATUS,
            TORQUE_STATUS,
            ANGLE_STATUS,
            TORQUE,
            ANGLE,
            TIMESTAMP,
            BATCH_STATUS
        }

        public enum TighteningValuesStatuses
        {
            LOW,
            OK,
            HIGH
        }

        public enum BatchStatuses
        {
            NOK,
            OK,
            NOT_USED
        }
    }
}
