using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// MID: Job ID upload reply
    /// Description:
    ///     The transmission of all the valid Job IDs of the controller. 
    ///     The data field contains the number of valid Jobs currently present in the controller, and the ID of each Job.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0031 : MID, IJob
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly JobListConverter _jobListConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 31;

        public int TotalJobs
        {
            get => RevisionsByFields[1][(int)DataFields.NUMBER_OF_JOBS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.NUMBER_OF_JOBS].SetValue(_intConverter.Convert, value);
        }

        public List<int> JobIds { get; set; }

        public MID_0031(int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            _jobListConverter = new JobListConverter(_intConverter);
            JobIds = new List<int>();
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
        public MID_0031(int totalJobs, IEnumerable<int> jobIds, int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            _jobListConverter = new JobListConverter(_intConverter);
            JobIds = new List<int>();
            SetRevision1or2(totalJobs, jobIds);
        }

        internal MID_0031(IMID nextTemplate) : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
            _jobListConverter = new JobListConverter(_intConverter);
            JobIds = new List<int>();
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            string package = BuildHeader();
            var eachJobField = RevisionsByFields[1][(int)DataFields.EACH_JOB_ID];
            if (HeaderData.Revision == 2)
            {
                eachJobField.Index = 24;
                RevisionsByFields[1][(int)DataFields.NUMBER_OF_JOBS].Size = eachJobField.Size = 4;
            }
            _jobListConverter.TotalJobs = TotalJobs;
            _jobListConverter.EachJobSize = eachJobField.Size;
            eachJobField.Value = _jobListConverter.Convert(JobIds);
            return base.BuildPackage();
        }

        public override MID ProcessPackage(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);

                var eachJobField = RevisionsByFields[1][(int)DataFields.EACH_JOB_ID];
                if (HeaderData.Revision == 2)
                {
                    eachJobField.Index = 24;
                    RevisionsByFields[1][(int)DataFields.NUMBER_OF_JOBS].Size =  4;
                }
                _jobListConverter.EachJobSize = eachJobField.Size;
                eachJobField.Size = package.Length - eachJobField.Index;
                base.ProcessPackage(package);
                _jobListConverter.TotalJobs = TotalJobs;
                JobIds = _jobListConverter.Convert(eachJobField.Value).ToList();
                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
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
                }
            };
        }

        /// <summary>
        /// Revision 1 or 2 setter
        /// </summary>
        /// <param name="totalJobs">
        ///     Revision 1 range: 00-99 
        ///     <para>Revision 2 range: 0000-9999</para>
        /// </param>
        /// <param name="jobIds">
        ///     Revision 1 - range: 00-99 each
        ///     <para>Revision 2 - range: 0000-9999 each</para>
        /// </param>
        public void SetRevision1or2(int totalJobs, IEnumerable<int> jobIds)
        {
            TotalJobs = totalJobs;
            JobIds = jobIds.ToList();
        }

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            List<string> failed = new List<string>();

            if(HeaderData.Revision == 1)
            {
                if(TotalJobs < 0 || TotalJobs > 99)
                    failed.Add(new ArgumentOutOfRangeException(nameof(TotalJobs), "Range: 00-99").Message);
                for (int i = 0; i < JobIds.Count; i++)
                {
                    int job = JobIds[i];
                    if (job < 0 || job > 99)
                        failed.Add(new ArgumentOutOfRangeException(nameof(JobIds), $"Failed at index[{i}] => Range: 00-99").Message);
                }
            }
            else
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

            errors = failed;
            return errors.Any();
        }

        public enum DataFields
        {
            NUMBER_OF_JOBS,
            EACH_JOB_ID
        }

        private class JobListConverter : IValueConverter<IEnumerable<int>>
        {
            private readonly IValueConverter<int> _intConverter;
            public int TotalJobs { get; set; }
            public int EachJobSize { get; set; }

            public JobListConverter(IValueConverter<int> intConverter)
            {
                _intConverter = intConverter;
            }

            public IEnumerable<int> Convert(string value)
            {
                int index = 0;
                for (int i = 0; i < TotalJobs; i++)
                {
                    index = i * EachJobSize;
                    yield return _intConverter.Convert(value.Substring(index, EachJobSize));
                }
            }

            public string Convert(IEnumerable<int> value)
            {
                string pack = string.Empty;
                foreach (var v in value)
                    pack += _intConverter.Convert('0', EachJobSize, DataField.PaddingOrientations.LEFT_PADDED, v);

                return pack;
            }

            public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<int> value)
            {
                return Convert(value);
            }
        }
    }
}
