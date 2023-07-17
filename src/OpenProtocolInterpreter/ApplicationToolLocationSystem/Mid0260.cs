using System.Collections.Generic;

namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// Tool tag ID request
    /// <para>Used by the integrator to request Tool tag ID information.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0262"/> Tool tag ID or <see cref="Communication.Mid0004"/> Command error, Tool tag ID unknown or MID revision unsupported.</para>
    /// </summary>
    public class Mid0260 : Mid, IApplicationToolLocationSystem, IController, IAnswerableBy<Mid0262>, IDeclinableCommand
    {
        public const int MID = 260;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.ToolTagIdUnknown, Error.MidRevisionUnsupported };

        public Mid0260() : base(MID, DEFAULT_REVISION) { }

        public Mid0260(Header header) : base(header)
        {

        }
    }
}
