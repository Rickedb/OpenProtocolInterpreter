using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly IValueConverter<int> _intConverter;
        private JobIdListConverter _jobListConverter;
        public const int MID = 31;

        public int TotalJobs
        {
            get => GetField(1, (int)DataFields.NumberOfJobs).GetValue(_intConverter.Convert);
            private set => GetField(1, (int)DataFields.NumberOfJobs).SetValue(_intConverter.Convert, value);
        }

        public List<int> JobIds { get; set; }

        public Mid0031() : this(DEFAULT_REVISION)
        {

        }

        public Mid0031(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            if (JobIds == null)
                JobIds = new List<int>();
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
            _jobListConverter = new JobIdListConverter(_intConverter, Header.Revision);
            TotalJobs = JobIds.Count;

            var eachJobField = GetField(1, (int)DataFields.EachJobId);
            eachJobField.Size = (Header.Revision > 1 ? 4 : 2) * TotalJobs;
            eachJobField.Value = _jobListConverter.Convert(JobIds);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            HandleRevisions();

            _jobListConverter = new JobIdListConverter(_intConverter, Header.Revision);
            var eachJobField = GetField(1, (int)DataFields.EachJobId);
            eachJobField.Size = Header.Length - eachJobField.Index;
            base.Parse(package);
            JobIds = _jobListConverter.Convert(eachJobField.Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.NumberOfJobs, 20, 2, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.EachJobId, 22, 2, '0', DataField.PaddingOrientations.LeftPadded, false)
                            }
                },
            };
        }

        private void HandleRevisions()
        {
            if (Header.Revision > 1)
            {
                GetField(1, (int)DataFields.EachJobId).Index = 24;
                GetField(1, (int)DataFields.NumberOfJobs).Size = 4;
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
