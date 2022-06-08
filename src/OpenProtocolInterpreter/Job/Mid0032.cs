using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Job data upload request
    /// <para>Request to upload the data for a specific Job from the controller.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Mid0033"/> Job data upload or <see cref="Communication.Mid0004"/> Command error, Job ID not present</para>
    /// </summary>
    public class Mid0032 : Mid, IJob, IIntegrator, IAnswerableBy<Mid0033>, IDeclinableCommand
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 4;
        public const int MID = 32;

        public IEnumerable<Error> PossibleErrors => new Error[] { Error.JOB_ID_NOT_PRESENT };

        public int JobId
        {
            get => GetField(1, (int)DataFields.JOB_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JOB_ID).SetValue(_intConverter.Convert, value);
        }

        public Mid0032() : this(LAST_REVISION)
        {

        }

        public Mid0032(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            HandleRevision();
        }

        public Mid0032(int revision = LAST_REVISION) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        /// <summary>
        /// Revision 1, 2, 3 and 4 constructor
        /// </summary>
        /// <param name="jobId">
        ///     Revision 1 range: 00-99 
        ///     <para>Revision 2 range: 0000-9999</para>
        /// </param>
        /// <param name="revision">Revision number (default = 4)</param>
        public Mid0032(int jobId, int revision = LAST_REVISION) : this(revision)
        {
            JobId = jobId;
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
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
                }
            };
        }

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            List<string> failed = new List<string>();

            if (Header.Revision == 1)
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
            if (Header.Revision == 1)
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