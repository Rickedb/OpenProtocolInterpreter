using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.LinkCommunication
{
    /// <summary>
    /// Communication acknowledge error
    /// <para>This message is used in conjunction with the use of header sequence number.</para>
    /// <para>Message sent by: Controller and Integrator:</para>
    /// <para>
    ///     This message is sent immediately after the message is received on application link level and if the check of the header is found to be wrong in any way.
    ///     The acknowledge substitute the use of NoAck flag and all subscription data special acknowledging.
    /// </para>
    /// <para>
    /// The acknowledge substitute the use of NoAck flag and all subscription data special acknowledging.
    /// </para>
    /// </summary>
    public class Mid9998 : Mid, ILinkCommunication, IController, IIntegrator
    {
        public const int MID = 9998;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 4, HasPrefix = false)]
        public int MidNumber { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 24, Size = 4, HasPrefix = false)]
        public LinkCommunicationError ErrorCode { get; set; }

        public Mid9998() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid9998(Header header) : base(header)
        {
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            MidNumber,
            ErrorCode
        }
    }
}
