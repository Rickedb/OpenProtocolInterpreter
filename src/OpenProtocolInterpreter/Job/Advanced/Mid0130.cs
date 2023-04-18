using OpenProtocolInterpreter.Converters;
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
        private readonly IValueConverter<bool> _boolConverter;
        public const int MID = 130;

        /// <summary>
        /// <para>False => Set Job Off</para>
        /// <para>True => Reset Job Off</para> 
        /// </summary>
        public bool JobOffStatus
        {
            get => GetField(1,(int)DataFields.JOB_OFF_STATUS).GetValue(_boolConverter.Convert);
            set => GetField(1,(int)DataFields.JOB_OFF_STATUS).SetValue(_boolConverter.Convert, value);
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
            _boolConverter = new BoolConverter();
        }

        public Mid0130(bool jobOffStatus) : this()
        {
            JobOffStatus = jobOffStatus;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.JOB_OFF_STATUS, 20, 1, false),
                            }
                }
            };
        }

        public enum DataFields
        {
            JOB_OFF_STATUS
        }
    }
}