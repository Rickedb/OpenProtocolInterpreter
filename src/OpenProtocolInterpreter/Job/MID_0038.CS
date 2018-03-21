using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 2;
        public const int MID = 38;

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

        public MID_0038(int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
        }

        public MID_0038(int jobId, int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            SetRevision1or2(jobId);
        }

        internal MID_0038(IMID nextTemplate) : base(MID, LAST_REVISION)
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
