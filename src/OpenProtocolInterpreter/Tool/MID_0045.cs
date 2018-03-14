using System;

namespace OpenProtocolInterpreter.Tool
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
        public const int MID = 45;
        private const int revision = 1;

        public CalibrationValueUnits CalibrationValueUnit { get; set; }
        public double CalibrationValue { get; set; }

        public MID_0045() : base(length, MID, revision) { }

        internal MID_0045(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            this.RegisteredDataFields[(int)DataFields.CALIBRATION_VALUE_UNIT].Value = (int)this.CalibrationValueUnit;
            this.RegisteredDataFields[(int)DataFields.CALIBRATION_VALUE].Value = Math.Round(this.CalibrationValue * 100, 0);

            return base.BuildPackage();
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.ProcessPackage(package);

                this.CalibrationValueUnit = (CalibrationValueUnits)this.RegisteredDataFields[(int)DataFields.CALIBRATION_VALUE_UNIT].ToInt32();
                this.CalibrationValue = this.RegisteredDataFields[(int)DataFields.CALIBRATION_VALUE].ToInt32() / 100;

                return this;
            }
                
            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
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
