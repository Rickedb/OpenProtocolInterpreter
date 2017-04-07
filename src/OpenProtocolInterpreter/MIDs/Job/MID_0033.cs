using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.Job
{
    /// <summary>
    /// MID: Job data upload reply
    /// Description:
    ///     This message is sent as a reply to the MID 0032 Job data request.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0033 : MID
    {
        private readonly IMID nextTemplate;

        private const int length = 20;
        private const int mid = 33;
        private const int revision = 1;

        public List<JobData> JobDatas { get; set; }

        public MID_0033() : base(length, mid, revision) { }

        public MID_0033(IMID nextTemplate) : base(length, mid, revision)
        {
            this.registerDatafields();
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            string package = base.buildHeader();
            package += this.JobID.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.NUMBER_OF_JOBS].Size, '0');
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


        private void registerDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.JOB_DATA, 20, 71));
        }

        public enum DataFields
        {
            JOB_DATA
        }

        public class JobData
        {
            public int JobID { get; set; }
            public string JobName { get; set; }
            public ForcedOrders ForcedOrder { get; set; }
            public int MaxTimeForFirstTightening { get; set; }
            public int MaxTimeToCompleteJob { get; set; }
            public JobBatchModes JobBatchMode { get; set; }

            public override string ToString()
            {
                return base.ToString();
            }

            public enum ForcedOrders
            {
                FREE_ORDER = 0,
                FORCED_ORDER = 1,
                FREE_AND_FORCED_ORDER = 2
            }

            public enum JobBatchModes
            {
                ONLY_OK_TIGHTENINGS = 0,
                OK_AND_NOK_TIGHTENINGS = 1
            }
        }
    }
}
