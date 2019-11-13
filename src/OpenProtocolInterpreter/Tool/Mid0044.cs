namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// MID: Disconnect tool request
    /// Description: 
    ///     This command is sent by the integrator in order to request the possibility to disconnect the tool from
    ///     the controller.The command is rejected if the tool is currently used.
    ///     When the command is accepted the operator can disconnect the tool and replace it (hot swap).
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Tool currently in use
    /// </summary>
    public class Mid0044 : Mid, ITool, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 44;

        public Mid0044() : base(MID, LAST_REVISION)
        {

        }
    }
}
