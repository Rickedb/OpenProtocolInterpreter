namespace OpenProtocolInterpreter.Statistic
{
    /// <summary>
    /// MID: Histogram upload request
    /// Description: 
    ///    Request to upload a histogram from the controller for a certain parameter set.
    ///    The histogram is calculated with all the tightening results currently present in 
    ///    the controller’s memory and within the statistic acceptance window(statistic min and max limits) 
    ///    for the requested parameter set.
    /// Message sent by: Integrator
    /// Answer: MID 0301, Histogram upload reply, or 
    ///         MID 0004 Command error, No histogram available or Invalid data
    /// </summary>
    public class MID_0300 : Mid, IStatistic
    {
        private const int length = 30;
        public const int MID = 300;
        private const int revision = 1;

        public int ParameterSetID { get; set; }
        public HistogramTypes HistogramType { get; set; }

        public MID_0300() : base(length, MID, revision) { }

        internal MID_0300(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            base.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Value = ParameterSetID.ToString().PadLeft(base.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Size);
            base.RegisteredDataFields[(int)DataFields.HISTOGRAM_TYPE].Value = ((int)HistogramType).ToString().PadLeft(base.RegisteredDataFields[(int)DataFields.HISTOGRAM_TYPE].Size);
            return base.BuildPackage();
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.ProcessPackage(package);
                ParameterSetID = base.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].ToInt32();
                HistogramType = (HistogramTypes)base.RegisteredDataFields[(int)DataFields.HISTOGRAM_TYPE].ToInt32();
                return this;
            }

            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.AddRange(new DataField[] {
                new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3),
                new DataField((int)DataFields.HISTOGRAM_TYPE, 25, 2)
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
            HISTOGRAM_TYPE
        }
    }
}
