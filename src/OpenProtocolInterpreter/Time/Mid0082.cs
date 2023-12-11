using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Time
{
    /// <summary>
    /// Set Time
    /// <para>Set the time in the controller.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0082 : Mid, ITime, IIntegrator
    {
        public const int MID = 82;

        public DateTime Time
        {
            get => GetField(1, DataFields.Time).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, DataFields.Time).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0082() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0082(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.Timestamp(DataFields.Time, 20, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            Time
        }
    }
}
