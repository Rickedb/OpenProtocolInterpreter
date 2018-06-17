using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Time
{
    /// <summary>
    /// MID: Set Time
    /// Description: 
    ///     Set the time in the controller.
    /// 
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0082 : Mid, ITime
    {
        private readonly IValueConverter<DateTime> _dateConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 82;

        public DateTime Time
        {
            get => GetField(1,(int)DataFields.TIME).GetValue(_dateConverter.Convert);
            set => GetField(1,(int)DataFields.TIME).SetValue(_dateConverter.Convert, value);
        }

        public Mid0082() : base(MID, LAST_REVISION)
        {
            _dateConverter = new DateConverter();
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="time"></param>
        public Mid0082(DateTime time) : this()
        {
            Time = time;
        }

        internal Mid0082(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

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
