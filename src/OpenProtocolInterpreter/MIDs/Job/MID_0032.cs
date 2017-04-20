using System;

namespace OpenProtocolInterpreter.MIDs.Job
{
    /// <summary>
    /// MID: Job data upload request
    /// Description:
    ///     Request to upload the data for a specific Job from the controller.
    /// Message sent by: Integrator
    /// Answer: MID 0033 Job data upload or MID 0004 Command error, Job ID not present
    /// </summary>
    public class MID_0032 : MID, IJob
    {
        private const int length = 22;
        public const int MID = 32;
        private const int revision = 1;

        public int JobID { get; private set; }

        public MID_0032() : base(length, MID, revision) { }

        internal MID_0032(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            string package = base.buildHeader();
            package += this.JobID.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.JOB_ID].Size, '0');
            return package;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                this.HeaderData = base.processHeader(package);

                var datafield = this.RegisteredDataFields[(int)DataFields.JOB_ID];
                this.JobID = Convert.ToInt32(package.Substring(datafield.Index, datafield.Size));

                return this;
            }

            return this.nextTemplate.processPackage(package);
        }


        protected override void registerDatafields() 
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.JOB_ID, 20, 2));
        }

        public enum DataFields
        {
            JOB_ID
        }
    }
}
