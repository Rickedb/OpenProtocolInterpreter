using System;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Set Parameter set batch size
    /// Description: 
    ///     This message gives the possibility to set the batch size of a parameter set at run time.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Invalid data
    /// </summary>
    public class MID_0019 : MID, IParameterSet
    {
        private const int length = 25;
        public const int MID = 19;
        private const int revision = 1;

        public int ParameterSetID { get; set; }
        public int BatchSize { get; set; }

        public MID_0019() : base(length, MID, revision) { }

        public MID_0019(int parameterSetId, int batchSize) : base(length, MID, revision)
        {
            this.ParameterSetID = parameterSetId;
            this.BatchSize = batchSize;
        }

        internal MID_0019(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            string package = base.BuildPackage();
            package += this.ParameterSetID.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Size, '0');
            package += this.BatchSize.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.BATCH_SIZE].Size, '0');
            return package;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                this.HeaderData = base.ProcessHeader(package);

                this.ParameterSetID = Convert.ToInt32(package.Substring(this.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Index,
                                                                        this.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Size));
                this.BatchSize = Convert.ToInt32(package.Substring(this.RegisteredDataFields[(int)DataFields.BATCH_SIZE].Index,
                                                                        this.RegisteredDataFields[(int)DataFields.BATCH_SIZE].Size));
                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() 
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3));
            this.RegisteredDataFields.Add(new DataField((int)DataFields.BATCH_SIZE, 23, 2));
        }

        public enum DataFields
        {
            PARAMETER_SET_ID,
            BATCH_SIZE
        }
    }
}
