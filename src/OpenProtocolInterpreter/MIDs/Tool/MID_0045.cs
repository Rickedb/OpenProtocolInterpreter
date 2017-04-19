using System;

namespace OpenProtocolInterpreter.MIDs.Tool
{
    /// <summary>
    /// MID: Set calibration value request
    /// Description: 
    ///     This message is sent by the integrator in order to set the calibration value of the tool.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Calibration failed
    /// </summary>
    public class MID_0045 : MID, ITool
    {
        private const int length = 31;
        private const int mid = 45;
        private const int revision = 1;

        public CalibrationValueUnits CalibrationValueUnit { get; set; }
        public double CalibrationValue { get; set; }

        public MID_0045() : base(length, mid, revision) { }

        public MID_0045(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            this.RegisteredDataFields[(int)DataFields.CALIBRATION_VALUE_UNIT].Value = (int)this.CalibrationValueUnit;
            this.RegisteredDataFields[(int)DataFields.CALIBRATION_VALUE].Value = Math.Round(this.CalibrationValue * 100, 0);

            return base.buildPackage();
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processPackage(package);

                this.CalibrationValueUnit = (CalibrationValueUnits)this.RegisteredDataFields[(int)DataFields.CALIBRATION_VALUE_UNIT].ToInt32();
                this.CalibrationValue = this.RegisteredDataFields[(int)DataFields.CALIBRATION_VALUE].ToInt32() / 100;

                return this;
            }
                
            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields()
        {
            this.RegisteredDataFields.AddRange(new DataField[]
            {
                new DataField((int)DataFields.CALIBRATION_VALUE_UNIT, 20, 1),
                new DataField((int)DataFields.CALIBRATION_VALUE, 23, 6)
            });

        }

        public enum CalibrationValueUnits
        {
            NM = 1,
            LBF_FT = 2,
            LBF_LN = 3,
            KPM = 4,
            NCM = 5
        }

        public enum DataFields
        {
            CALIBRATION_VALUE_UNIT,
            CALIBRATION_VALUE
        }
    }
}
