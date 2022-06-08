using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Disconnect tool request
    /// <para>
    ///     This command is sent by the integrator in order to request the possibility to disconnect the tool from
    ///     the controller.The command is rejected if the tool is currently used.
    /// </para>
    /// <para>
    ///     When the command is accepted the operator can disconnect the tool and replace it (hot swap).
    /// </para>    
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///             <see cref="Communication.Mid0004"/> Command error, Tool currently in use
    /// </para>
    /// </summary>
    public class Mid0044 : Mid, ITool, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        private const int LAST_REVISION = 1;
        public const int MID = 44;

        public IEnumerable<Error> PossibleErrors => new Error[] { Error.TOOL_CURRENTLY_IN_USE };

        public Mid0044() : base(MID, LAST_REVISION)
        {

        }

        public Mid0044(Header header) : base(header)
        {
        }
    }
}
