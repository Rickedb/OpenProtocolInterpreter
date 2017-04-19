using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.Job
{
    /// <summary>
    /// MID: Select Job
    /// Description: 
    ///     Message to select Job. If the requested ID is not present in the controller, then the command will 
    ///     not be performed.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Job can not be set, or Invalid data
    /// </summary>
    public class MID_0038 : MID, IJob
    {
        private const int length = 22;
        private const int mid = 38;
        private const int revision = 1;

        public int JobID { get; set; }

        public MID_0038() : base(length, mid, revision) { }

        public MID_0038(int jobId) : base(length, mid, revision)
        {
            this.JobID = jobId;
        }

        public MID_0038(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            if (this.JobID == 0)
                throw new ArgumentNullException("JobID cannot be null");

            return base.buildHeader() + this.JobID.ToString().PadLeft(2, '0');
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.HeaderData = base.processHeader(package);
                var dataField = base.RegisteredDataFields[(int)DataFields.JOB_ID];
                this.JobID = Convert.ToInt32(package.Substring(dataField.Index, dataField.Size));
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
