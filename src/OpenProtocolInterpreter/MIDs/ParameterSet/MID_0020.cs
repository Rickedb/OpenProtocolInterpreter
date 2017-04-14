using System;
namespace OpenProtocolInterpreter.MIDs.ParameterSet
{
    /// <summary>
    /// MID: Reset Parameter set batch counter
    /// Description: 
    ///     This message gives the possibility to reset the batch counter of the running parameter set, at run time.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Invalid data, or Parameter set not running
    /// </summary>
    public class MID_0020 : MID, IParameterSet
    {
        private const int length = 23;
        private const int mid = 20;
        private const int revision = 1;

        public int ParameterSetID { get; set; }
        public int BatchSize { get; set; }

        public MID_0020() : base(length, mid, revision) { }

        internal MID_0020(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            string package = base.buildPackage();
            package += this.ParameterSetID.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Size, '0');
            return package;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                this.HeaderData = base.processHeader(package);

                this.ParameterSetID = Convert.ToInt32(package.Substring(this.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Index,
                                                                        this.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Size));
                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        private void registerDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3));
        }

        public enum DataFields
        {
            PARAMETER_SET_ID
        }
    }
}
