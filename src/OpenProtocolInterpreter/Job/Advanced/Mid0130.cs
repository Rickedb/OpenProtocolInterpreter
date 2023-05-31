using System.Collections.Generic;

namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Job off
    /// <para>Set the controller in Job off mode or reset the Job off mode.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0130 : Mid, IAdvancedJob, IIntegrator, IAcceptableCommand
    {
        public const int MID = 130;

        /// <summary>
        /// <para>False => Set Job Off</para>
        /// <para>True => Reset Job Off</para> 
        /// </summary>
        public bool JobOffStatus
        {
            get => GetField(1,(int)DataFields.JobOffStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1,(int)DataFields.JobOffStatus).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0130() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {
            
        }

        public Mid0130(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.JobOffStatus, 20, 1, false),
                            }
                }
            };
        }

        protected enum DataFields
        {
            JobOffStatus
        }
    }
}