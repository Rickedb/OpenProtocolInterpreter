namespace OpenProtocolInterpreter.Statistic
{
    /// <summary>
    /// MID: Histogram upload reply
    /// Description: 
    ///    Histogram upload reply for the requested parameter set and for the requested histogram type. The
    ///    histogram uploaded is made of 9 bars according to Figure 22 Histogram example.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0301 : MID, IStatistic
    {
        private const int length = 107;
        public const int MID = 301;
        private const int revision = 1;

        public int ParameterSetID { get; set; }
        public HistogramTypes HistogramType { get; set; }
        public decimal SigmaHistogram { get; set; }
        public decimal MeanValueHistogram { get; set; }
        public decimal ClassRange { get; set; }
        public int Bar1 { get; set; }
        public int Bar2 { get; set; }
        public int Bar3 { get; set; }
        public int Bar4 { get; set; }
        public int Bar5 { get; set; }
        public int Bar6 { get; set; }
        public int Bar7 { get; set; }
        public int Bar8 { get; set; }
        public int Bar9 { get; set; }

        public MID_0301() : base(length, MID, revision) { }

        internal MID_0301(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            base.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Value = this.ParameterSetID.ToString().PadLeft(base.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Size);
            base.RegisteredDataFields[(int)DataFields.HISTOGRAM_TYPE].Value = ((int)this.HistogramType).ToString().PadLeft(base.RegisteredDataFields[(int)DataFields.HISTOGRAM_TYPE].Size);
            base.RegisteredDataFields[(int)DataFields.SIGMA_HISTOGRAM].Value = this.SigmaHistogram * 100;
            base.RegisteredDataFields[(int)DataFields.MEAN_VALUE_HISTOGRAM].Value = this.MeanValueHistogram * 100;
            base.RegisteredDataFields[(int)DataFields.CLASS_RANGE].Value = this.ClassRange * 100;
            base.RegisteredDataFields[(int)DataFields.BAR_1].Value = this.Bar1;
            base.RegisteredDataFields[(int)DataFields.BAR_2].Value = this.Bar2;
            base.RegisteredDataFields[(int)DataFields.BAR_3].Value = this.Bar3;
            base.RegisteredDataFields[(int)DataFields.BAR_4].Value = this.Bar4;
            base.RegisteredDataFields[(int)DataFields.BAR_5].Value = this.Bar5;
            base.RegisteredDataFields[(int)DataFields.BAR_6].Value = this.Bar6;
            base.RegisteredDataFields[(int)DataFields.BAR_7].Value = this.Bar7;
            base.RegisteredDataFields[(int)DataFields.BAR_8].Value = this.Bar8;
            base.RegisteredDataFields[(int)DataFields.BAR_9].Value = this.Bar9;
            return base.BuildPackage();
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.ProcessPackage(package);
                this.ParameterSetID = base.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].ToInt32();
                this.HistogramType = (HistogramTypes)base.RegisteredDataFields[(int)DataFields.HISTOGRAM_TYPE].ToInt32();
                this.SigmaHistogram = base.RegisteredDataFields[(int)DataFields.SIGMA_HISTOGRAM].ToInt32() / 100m;
                this.MeanValueHistogram = base.RegisteredDataFields[(int)DataFields.MEAN_VALUE_HISTOGRAM].ToInt32() / 100m;
                this.ClassRange = base.RegisteredDataFields[(int)DataFields.CLASS_RANGE].ToInt32() / 100m;
                this.Bar1 = base.RegisteredDataFields[(int)DataFields.BAR_1].ToInt32();
                this.Bar2 = base.RegisteredDataFields[(int)DataFields.BAR_2].ToInt32();
                this.Bar3 = base.RegisteredDataFields[(int)DataFields.BAR_3].ToInt32();
                this.Bar4 = base.RegisteredDataFields[(int)DataFields.BAR_4].ToInt32();
                this.Bar5 = base.RegisteredDataFields[(int)DataFields.BAR_5].ToInt32();
                this.Bar6 = base.RegisteredDataFields[(int)DataFields.BAR_6].ToInt32();
                this.Bar7 = base.RegisteredDataFields[(int)DataFields.BAR_7].ToInt32();
                this.Bar8 = base.RegisteredDataFields[(int)DataFields.BAR_8].ToInt32();
                this.Bar9 = base.RegisteredDataFields[(int)DataFields.BAR_9].ToInt32();
                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.AddRange(new DataField[] {
                new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3),
                new DataField((int)DataFields.HISTOGRAM_TYPE, 25, 2),
                new DataField((int)DataFields.SIGMA_HISTOGRAM, 29, 6),
                new DataField((int)DataFields.MEAN_VALUE_HISTOGRAM, 37, 6),
                new DataField((int)DataFields.CLASS_RANGE, 45, 6),
                new DataField((int)DataFields.BAR_1, 53, 4),
                new DataField((int)DataFields.BAR_2, 59, 4),
                new DataField((int)DataFields.BAR_3, 65, 4),
                new DataField((int)DataFields.BAR_4, 71, 4),
                new DataField((int)DataFields.BAR_5, 77, 4),
                new DataField((int)DataFields.BAR_6, 83, 4),
                new DataField((int)DataFields.BAR_7, 89, 4),
                new DataField((int)DataFields.BAR_8, 95, 4),
                new DataField((int)DataFields.BAR_9, 101, 4)
            });
        }

        public enum HistogramTypes
        {
            TORQUE = 0,
            ANGLE = 1,
            CURRENT = 2,
            PREVAIL_TORQUE = 3,
            SELF_TAP = 4,
            RUNDOWN_ANGLE = 5
        }

        public enum DataFields
        {
            PARAMETER_SET_ID,
            HISTOGRAM_TYPE,
            SIGMA_HISTOGRAM,
            /// <summary>
            /// X-BAR
            /// </summary>
            MEAN_VALUE_HISTOGRAM,
            CLASS_RANGE,
            BAR_1,
            BAR_2,
            BAR_3,
            BAR_4,
            BAR_5,
            BAR_6,
            BAR_7,
            BAR_8,
            BAR_9
        }
    }
}
