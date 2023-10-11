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
        public const int MID = 81;

        public DateTime Time
        {
            get => GetField(1,(int)DataFields.Time).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1,(int)DataFields.Time).SetValue(OpenProtocolConvert.ToString, value);
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
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new((int)DataFields.Time, 20, 19, false)
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
