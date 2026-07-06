using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Relay function
    /// <para>
    ///     Upload of one specific relay function status, see Table 101.
    ///     For tracking event functions, <see cref="Mid0217"/> Relay function, is sent each time the relay status is changed. For
    ///     relay functions which are not tracking events, the upload is sent only when the relay is set high, i.e. the
    ///     data field “Relay function status” will always be 1 for such functions.
    /// </para>
    /// Message sent by: Controller
    /// Answer: <see cref="Mid0218"/> Relay function acknowledge
    /// </summary>
    public class Mid0217 : Mid, IIOInterface, IController, IAcknowledgeable<Mid0218>
    {
        public const int MID = 217;

        [Int32DataFieldDefinition(field: 1, revision: 1, Size = 3)]
        public RelayNumber RelayNumber { get; set; }
        [BooleanDataFieldDefinition(field: 2, revision: 1)]
        public bool RelayStatus { get; set; }

        public Mid0217() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0217(Header header) : base(header)
        {
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            RelayNumber,
            RelayStatus
        }
    }
}

