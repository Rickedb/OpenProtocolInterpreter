using System.Collections.Generic;

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
        public const int MID = 32;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.JobIdNotPresent };

        public int JobId
        {
            get => GetField(1, DataFields.JobId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.JobId).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0032() : this(DEFAULT_REVISION)
        {

        }

        public Mid0032(Header header) : base(header)
        {
            HandleRevision();
        }

        public Mid0032(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
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
                                DataField.Number(DataFields.JobId, 20, 2, false),
                            }
                }
            };
        }

        private void HandleRevision()
        {
            if (Header.Revision == 1)
                GetField(1, DataFields.JobId).Size = 2;
            else
                GetField(1, DataFields.JobId).Size = 4;
        }

        protected enum DataFields
        {
            JobId
        }
    }
}