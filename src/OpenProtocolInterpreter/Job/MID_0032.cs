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
    public class MID_0032 : MID, IJob
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 3;
        public const int MID = 32;
        
        public int JobId
        {
            get
            {
                HandleRevision();
                return RevisionsByFields[1][(int)DataFields.JOB_ID].GetValue(_intConverter.Convert);
            }
            set
            {
                HandleRevision();
                RevisionsByFields[1][(int)DataFields.JOB_ID].SetValue(_intConverter.Convert, value);
            }
        }

        public MID_0032(int revision = LAST_REVISION) : this(MID, revision)
        {
            _intConverter = new Int32Converter();
        }

        /// <summary>
        /// Revision 1 or 2 setter
        /// </summary>
        /// <param name="jobId">
        ///     Revision 1 range: 00-99 
        ///     <para>Revision 2 range: 0000-9999</para>
        /// </param>
        /// <param name="revision">Revision number (default = 3)</param>
        public MID_0032(int jobId, int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            SetRevision1or2(jobId);
        }

        internal MID_0032(IMID nextTemplate) : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
            NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);
                HandleRevision();
                return base.ProcessPackage(package);
            }

            return NextTemplate.ProcessPackage(package);
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
                }
            };
        }

        /// <summary>
        /// Revision 1 or 2 setter
        /// </summary>
        /// <param name="jobId">
        ///     Revision 1 range: 00-99 
        ///     <para>Revision 2 range: 0000-9999</para>
        /// </param>
        public void SetRevision1or2(int jobId) => JobId = jobId;

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
                RevisionsByFields[1][(int)DataFields.JOB_ID].Size = 2;
            else
                RevisionsByFields[1][(int)DataFields.JOB_ID].Size = 4;
        }

        public enum DataFields
        {
            JOB_ID
        }
    }
}
