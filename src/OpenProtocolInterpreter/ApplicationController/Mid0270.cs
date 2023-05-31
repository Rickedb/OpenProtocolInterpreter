using System.Collections.Generic;

namespace OpenProtocolInterpreter.ApplicationController
{
    /// <summary>
    /// Controller reboot request 
    /// <para>This message causes the controller to reboot after it has accepted the command.
    ///     <list type="bullet">
    ///         <item>Warning 1: this MID requires programming control (see 4.4 Programming control).</item>
    ///         <item>Warning 2: the connection will be lost and will need to be reestablished after controller reboot!</item>
    ///     </list>
    /// </para>    
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Programming control not granted</para>
    /// </summary>
    public class Mid0270 : Mid, IApplicationController, IIntegrator, IAcceptableCommand, IDeclinableCommand 
    {
        public const int MID = 270;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.ProgrammingControlNotGranted };

        public Mid0270() : base(MID, DEFAULT_REVISION) 
        { 
        }

        public Mid0270(Header header) : base(header)
        {

        }
    }
}
