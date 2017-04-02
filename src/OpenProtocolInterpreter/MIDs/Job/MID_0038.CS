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
    public class MID_0038 : MID
    {
        private readonly IMID nextTemplate;

        private const int length = 22;
        private const int mid = 38;
        private const int revision = 1;

        public int JobID { get; set; }

        public MID_0038(int jobId) : base(length, mid, revision)
        {
            this.registerDatafields();
            this.JobID = jobId;
        }

        public MID_0038(IMID nextTemplate) : base(length, mid, revision)
        {
            this.registerDatafields();
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processPackage(package);
                this.JobID = (int)base.RegisteredDataFields[(int)DataFields.JOB_ID].Value;
                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        private void registerDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.JOB_ID, 20, 2));
        }

        public enum DataFields
        {
            JOB_ID
        }
    }
}
