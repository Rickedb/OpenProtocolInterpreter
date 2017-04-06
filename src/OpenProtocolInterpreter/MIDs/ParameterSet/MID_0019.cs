using System;

namespace OpenProtocolInterpreter.MIDs.ParameterSet
{
    /// <summary>
    /// MID: Set Parameter set batch size
    /// Description: 
    ///     This message gives the possibility to set the batch size of a parameter set at run time.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Invalid data
    /// </summary>
    public class MID_0019 : MID
    {
        private readonly IMID nextTemplate;

        private const int length = 25;
        private const int mid = 19;
        private const int revision = 1;

        public int ParameterSetID { get; set; }
        public int BatchSize { get; set; }

        public MID_0019() : base(length, mid, revision) { }

        public MID_0019(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            string package = base.buildPackage();
            package += this.ParameterSetID.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Size, '0');
            package += this.BatchSize.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.BATCH_SIZE].Size, '0');
            return package;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                this.HeaderData = base.processHeader(package);

                this.ParameterSetID = Convert.ToInt32(package.Substring(this.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Index,
                                                                        this.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Size));
                this.BatchSize = Convert.ToInt32(package.Substring(this.RegisteredDataFields[(int)DataFields.BATCH_SIZE].Index,
                                                                        this.RegisteredDataFields[(int)DataFields.BATCH_SIZE].Size));
                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        private void registerDatafields()
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
