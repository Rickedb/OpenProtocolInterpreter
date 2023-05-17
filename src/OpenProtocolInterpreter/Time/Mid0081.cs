using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Time
{
    /// <summary>
    /// Read time upload reply
    /// <para>Time upload reply from the controller.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0081 : Mid, ITime, IController
    {
        private readonly IValueConverter<DateTime> _dateConverter;
        public const int MID = 81;

        public DateTime Time
        {
            get => GetField(1,(int)DataFields.Time).GetValue(_dateConverter.Convert);
            set => GetField(1,(int)DataFields.Time).SetValue(_dateConverter.Convert, value);
        }

        public Mid0081() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0081(Header header) : base(header)
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
                                new DataField((int)DataFields.Time, 20, 19, false)
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
