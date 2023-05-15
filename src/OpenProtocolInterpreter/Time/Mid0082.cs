using OpenProtocolInterpreter.Converters;
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
        private readonly IValueConverter<DateTime> _dateConverter;
        public const int MID = 82;

        public DateTime Time
        {
            get => GetField(1,(int)DataFields.TIME).GetValue(_dateConverter.Convert);
            set => GetField(1,(int)DataFields.TIME).SetValue(_dateConverter.Convert, value);
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
            _dateConverter = new DateConverter();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.TIME, 20, 19, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            TIME
        }
    }
}
