using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// Application Communication positive acknowledge
    /// <para>
    ///     This message is used by the controller to confirm that the latest command, request or subscription sent
    ///     by the integrator was accepted.The data field contains the MID of the request accepted if the special
    ///     MIDs for request or subscription are used.
    /// </para>
    /// <para>
    ///     It can also be used by the integrator to acknowledge received subscribed data/events upload and will
    ///     then do all the special subscription data acknowledges obsolete.
    /// </para>
    /// <para>
    ///     When using the communication acknowledgement of MID 9997 and MID 9998 together with
    ///     sequence numbering this is an application level message only.
    ///     When using the GENERIC subscription MIDs <see cref="Mid0008"/> and 0009 the data field contains the MID of
    ///     the subscribed MID.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0005 : Mid, ICommunication, IController
    {
        public const int MID = 5;

        [Int32DataFieldDefinition(field: 0, revision: 1, Size = 4, HasPrefix = false)]
        public int MidAccepted { get; set; }

        public Mid0005() : this(DEFAULT_REVISION)
        {

        }

        public Mid0005(Header header) : base(header)
        {
        }

        public Mid0005(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {

        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            MidAccepted
        }
    }
}
