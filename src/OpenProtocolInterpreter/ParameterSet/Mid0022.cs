using System;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Lock at batch done upload
    /// <para>This message gives the relay status for Lock at batch done.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0023"/> Lock at batch done upload Ack</para>
    /// </summary>
    public class Mid0022 : Mid, IParameterSet, IController, IAcknowledgeable<Mid0023>
    {
        public const int MID = 22;

        [BooleanDataFieldDefinition(revision: 1, field: 1, Index = 20, HasPrefix = false)]
        public bool RelayStatus { get; set; }

        public Mid0022() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0022(Header header) : base(header)
        {
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            RelayStatus
        }
    }
}
