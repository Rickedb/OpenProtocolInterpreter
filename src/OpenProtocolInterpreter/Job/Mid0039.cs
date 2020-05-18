using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Job restart
    /// <para>Job restart message.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Job not running, or Invalid data</para>
    /// </summary>
    public class Mid0039 : Mid, IJob, IIntegrator
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 2;
        public const int MID = 39;

        public int JobId
        {
            get => GetField(1, (int)DataFields.JOB_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JOB_ID).SetValue(_intConverter.Convert, value);
        }

        public Mid0039() : this(LAST_REVISION)
        {

        }

        public Mid0039(int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            HandleRevisions();
        }

        /// <summary>
        /// Constructor for Revision 1 and 2
        /// </summary>
        /// <param name="jobId">The Job ID is specified by two/four ASCII characters, range 00-99/0000-9999 <para>*Depend on revision</para></param>
        /// <param name="revision">Revision number (default = 2)</param>
        public Mid0039(int jobId, int revision = LAST_REVISION) : this(revision)
        {
            JobId = jobId;
        }

        public override Mid Parse(string package)
        {
            HeaderData = ProcessHeader(package);
            HandleRevisions();
            ProcessDataFields(package);
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.JOB_ID, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                            }
                },
                {  2, new List<DataField>() }
            };
        }

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            List<string> failed = new List<string>();

            if (HeaderData.Revision == 1)
            {
                if (JobId < 0 || JobId > 99)
                    failed.Add(new ArgumentOutOfRangeException(nameof(JobId), "Range: 00-99").Message);
            }
            else
            {
                if (JobId < 0 || JobId > 9999)
                    failed.Add(new ArgumentOutOfRangeException(nameof(JobId), "Range: 0000-9999").Message);
            }

            errors = failed;
            return errors.Any();
        }

        private void HandleRevisions()
        {
            if (HeaderData.Revision == 1)
            {
                GetField(1, (int)DataFields.JOB_ID).Size = 2;
            }
            else
            {
                GetField(1, (int)DataFields.JOB_ID).Size = 4;
            }
        }

        public enum DataFields
        {
            JOB_ID
        }
    }
}
