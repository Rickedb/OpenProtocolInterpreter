using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Time
{
    /// <summary>
    /// MID: Read time upload reply
    /// Description: 
    ///     Time upload reply from the controller.
    /// 
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0081 : Mid, ITime
    {
        private readonly IValueConverter<DateTime> _dateConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 81;

        public DateTime Time
        {
            get => RevisionsByFields[1][(int)DataFields.TIME].GetValue(_dateConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.TIME].SetValue(_dateConverter.Convert, value);
        }

        public MID_0081() : base(MID, LAST_REVISION)
        {
            _dateConverter = new DateConverter();
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="time"></param>
        public MID_0081(DateTime time) : this()
        {
            Time = time;
        }

        internal MID_0081(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

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
