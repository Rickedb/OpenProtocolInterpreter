using System.Collections.Generic;
using System.Text;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Job ID upload reply
    /// <para>
    ///     The transmission of all the valid Job IDs of the controller. 
    ///     The data field contains the number of valid Jobs currently present in the controller, and the ID of each Job.
    /// </para>    
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0031 : Mid, IJob, IController
    {
        private int JobSize => Header.Revision > 1 ? 4 : 2;

        public const int MID = 31;

        public int TotalJobs
        {
            get => GetField(1, (int)DataFields.NumberOfJobs).GetValue(OpenProtocolConvert.ToInt32);
            private set => GetField(1, (int)DataFields.NumberOfJobs).SetValue(OpenProtocolConvert.ToString, value);
        }

        public List<int> JobIds { get; set; }

        public Mid0031() : this(DEFAULT_REVISION)
        {

        }

        public Mid0031(Header header) : base(header)
        {
            JobIds ??= [];
            HandleRevisions();
        }

        public Mid0031(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
            
        }

        public override string Pack()
        {
            TotalJobs = JobIds.Count;

            var eachJobField = GetField(1, (int)DataFields.EachJobId);
            eachJobField.Size = JobSize * TotalJobs;
            eachJobField.Value = PackJobIdList();
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            HandleRevisions();

            var eachJobField = GetField(1, (int)DataFields.EachJobId);
            eachJobField.Size = Header.Length - eachJobField.Index;
            base.Parse(package);
            JobIds = ParseJobIdList(eachJobField.Value);
            return this;
        }


        protected virtual string PackJobIdList()
        {
            var builder = new StringBuilder();
            foreach (var v in JobIds)
                builder.Append(OpenProtocolConvert.ToString('0', JobSize, PaddingOrientation.LeftPadded, v));

            return builder.ToString();
        }

        protected virtual List<int> ParseJobIdList(string section)
        {
            var list = new List<int>();
            if (string.IsNullOrWhiteSpace(section))
            {
                return list;
            }

            for (int i = 0; i < section.Length; i += JobSize)
            {
                list.Add(OpenProtocolConvert.ToInt32(section.Substring(i, JobSize)));
            }

            return list;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new((int)DataFields.NumberOfJobs, 20, 2, '0', PaddingOrientation.LeftPadded, false),
                                new((int)DataFields.EachJobId, 22, 2, '0', PaddingOrientation.LeftPadded, false)
                            }
                },
            };
        }

        private void HandleRevisions()
        {
            if (Header.Revision > 1)
            {
                GetField(1, (int)DataFields.NumberOfJobs).Size = 4;
                GetField(1, (int)DataFields.EachJobId).Index = 24;
            }
            else
            {
                GetField(1, (int)DataFields.NumberOfJobs).Size = GetField(1, (int)DataFields.EachJobId).Size = 2;
            }
        }

        protected enum DataFields
        {
            NumberOfJobs,
            EachJobId
        }
    }
}
