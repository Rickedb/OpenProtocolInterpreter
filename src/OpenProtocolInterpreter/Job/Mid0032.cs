using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// MID: Job data upload request
    /// Description:
    ///     Request to upload the data for a specific Job from the controller.
    /// Message sent by: Integrator
    /// Answer: MID 0033 Job data upload or MID 0004 Command error, Job ID not present
    /// </summary>
    public class Mid0032 : Mid, IJob, IIntegrator
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 3;
        public const int MID = 32;

        public int JobId
        {
            get => GetField(1, (int)DataFields.JOB_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JOB_ID).SetValue(_intConverter.Convert, value);
        }

        public Mid0032() : this(LAST_REVISION)
        {

        }

        public Mid0032(int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            HandleRevision();
        }

        /// <summary>
        /// Revision 1 or 2 setter
        /// </summary>
        /// <param name="jobId">
        ///     Revision 1 range: 00-99 
        ///     <para>Revision 2 range: 0000-9999</para>
        /// </param>
        /// <param name="revision">Revision number (default = 3)</param>
        public Mid0032(int jobId, int revision = 2) : this(revision) => JobId = jobId;

        public override Mid Parse(string package)
        {
            HeaderData = ProcessHeader(package);
            HandleRevision();
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
                { 2, new List<DataField>() },
                { 3, new List<DataField>() }
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

        private void HandleRevision()
        {
            if (HeaderData.Revision == 1)
                GetField(1, (int)DataFields.JOB_ID).Size = 2;
            else
                GetField(1, (int)DataFields.JOB_ID).Size = 4;
        }

        public enum DataFields
        {
            JOB_ID
        }
    }
}
