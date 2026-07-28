using System;

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

        [TimestampDataFieldDefinition(revision: 1, field: 1, Index = 20, HasPrefix = false)]
        public DateTime Time { get; set; }

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
    }
}
