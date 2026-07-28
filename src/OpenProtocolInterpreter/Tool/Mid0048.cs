using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Tool Pairing status
    /// <para>This message is sent by the controller in order to report the current status of the tool pairing.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0048 : Mid, ITool, IController
    {
        public const int MID = 48;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 2)]
        public PairingStatus PairingStatus { get; set; }

        [TimestampDataFieldDefinition(revision: 1, field: 2, Index = 24)]
        public DateTime TimeStamp { get; set; }

        public Mid0048() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0048(Header header) : base(header)
        {
        }
    }
}
