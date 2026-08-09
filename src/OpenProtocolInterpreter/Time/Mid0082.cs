using System;

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

        [TimestampDataFieldDefinition(revision: 1, field: 1, Index = 20, HasPrefix = false)]
        public DateTime Time { get; set; }

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
    }
}
