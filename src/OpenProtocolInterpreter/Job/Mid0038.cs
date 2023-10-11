using System.Collections.Generic;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Select Job
    /// <para>Message to select Job. If the requested ID is not present in the controller, then the command will not be performed.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Job can not be set, or Invalid data</para>
    /// </summary>
    public class Mid0038 : Mid, IJob, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 38;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.JobCannotBeSet, Error.InvalidData };

        public int JobId
        {
            get => GetField(1, (int)DataFields.JobId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.JobId).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0038() : this(DEFAULT_REVISION)
        {

        }
        
        public Mid0038(Header header) : base(header)
        {
            HandleRevision();
        }

        public Mid0038(int revision) : this(new Header()
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
                                new((int)DataFields.JobId, 20, 2, '0', PaddingOrientation.LeftPadded, false),
                            }
                }
            };
        }

        private void HandleRevision()
        {
            if (Header.Revision > 1)
            {
                GetField(1, (int)DataFields.JobId).Size = 4;
            }
            else
            {
                GetField(1, (int)DataFields.JobId).Size = 2;
            }
        }

        protected enum DataFields
        {
            JobId
        }
    }
}
