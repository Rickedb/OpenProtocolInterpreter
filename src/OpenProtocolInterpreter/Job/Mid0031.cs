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
            get => GetField(1, (int)DataFields.NUMBER_OF_JOBS).GetValue(_intConverter.Convert);
            private set => GetField(1, (int)DataFields.NUMBER_OF_JOBS).SetValue(_intConverter.Convert, value);
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

        /// <summary>
        /// Revision 1 or 2 constructor
        /// </summary>
        /// <param name="totalJobs">
        ///     Revision 1 range: 00-99 
        ///     <para>Revision 2 range: 0000-9999</para>
        /// </param>
        /// <param name="jobIds">
        ///     Revision 1 - range: 00-99 each
        ///     <para>Revision 2 - range: 0000-9999 each</para>
        /// </param>
        /// /// <param name="revision">Revision number (default = 2)</param>
        public Mid0031(int totalJobs, IEnumerable<int> jobIds, int revision = DEFAULT_REVISION) : this(revision)
        {
            TotalJobs = totalJobs;
            JobIds = jobIds.ToList();
        }

        public override string Pack()
        {
            _jobListConverter = new JobIdListConverter(_intConverter, Header.Revision);
            TotalJobs = JobIds.Count;

            var eachJobField = GetField(1, (int)DataFields.EACH_JOB_ID);
            eachJobField.Size = (Header.Revision > 1 ? 4 : 2) * TotalJobs;
            eachJobField.Value = _jobListConverter.Convert(JobIds);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            HandleRevisions();

            _jobListConverter = new JobIdListConverter(_intConverter, Header.Revision);
            var eachJobField = GetField(1, (int)DataFields.EACH_JOB_ID);
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
                                new DataField((int)DataFields.NUMBER_OF_JOBS, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.EACH_JOB_ID, 22, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                            }
                },
            };
        }

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            List<string> failed = new List<string>();

            if (Header.Revision > 1)
            {
                if (TotalJobs < 0 || TotalJobs > 9999)
                    failed.Add(new ArgumentOutOfRangeException(nameof(TotalJobs), "Range: 0000-9999").Message);
                for (int i = 0; i < JobIds.Count; i++)
                {
                    int job = JobIds[i];
                    if (job < 0 || job > 9999)
                        failed.Add(new ArgumentOutOfRangeException(nameof(JobIds), $"Failed at index[{i}] => Range: 0000-9999").Message);
                }

            }
            else
            {
                if (TotalJobs < 0 || TotalJobs > 99)
                    failed.Add(new ArgumentOutOfRangeException(nameof(TotalJobs), "Range: 00-99").Message);
                for (int i = 0; i < JobIds.Count; i++)
                {
                    int job = JobIds[i];
                    if (job < 0 || job > 99)
                        failed.Add(new ArgumentOutOfRangeException(nameof(JobIds), $"Failed at index[{i}] => Range: 00-99").Message);
                }
            }

            errors = failed;
            return errors.Any();
        }

        private void HandleRevisions()
        {
            if (Header.Revision > 1)
            {
                GetField(1, (int)DataFields.EACH_JOB_ID).Index = 24;
                GetField(1, (int)DataFields.NUMBER_OF_JOBS).Size = 4;
            }
            else
            {
                GetField(1, (int)DataFields.NUMBER_OF_JOBS).Size = GetField(1, (int)DataFields.EACH_JOB_ID).Size = 2;
            }
        }

        public enum DataFields
        {
            NUMBER_OF_JOBS,
            EACH_JOB_ID
        }


    }
}
