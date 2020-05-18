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
        private const int LAST_REVISION = 1;
        public const int MID = 81;

        public DateTime Time
        {
            get => GetField(1,(int)DataFields.TIME).GetValue(_dateConverter.Convert);
            set => GetField(1,(int)DataFields.TIME).SetValue(_dateConverter.Convert, value);
        }

        public Mid0081() : base(MID, LAST_REVISION)
        {
            _dateConverter = new DateConverter();
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="time"></param>
        public Mid0081(DateTime time) : this()
        {
            Time = time;
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

        public enum DataFields
        {
            TIME
        }
    }
}
