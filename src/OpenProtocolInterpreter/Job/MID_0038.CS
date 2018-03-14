using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.Job
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
        public const int MID = 38;
        private const int revision = 1;

        public int JobID { get; set; }

        public MID_0038() : base(length, MID, revision) { }

        public MID_0038(int jobId) : base(length, MID, revision)
        {
            this.JobID = jobId;
        }

        internal MID_0038(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            if (this.JobID == 0)
                throw new ArgumentNullException("JobID cannot be null");

            return base.BuildHeader() + this.JobID.ToString().PadLeft(2, '0');
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.HeaderData = base.ProcessHeader(package);
                var dataField = base.RegisteredDataFields[(int)DataFields.JOB_ID];
                this.JobID = Convert.ToInt32(package.Substring(dataField.Index, dataField.Size));
                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() 
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.JOB_ID, 20, 2));
        }

        public enum DataFields
        {
            JOB_ID
        }
    }
}
