using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.LinkCommunication
{
    /// <summary>
    /// MID: Communication acknowledge
    /// Description: 
    ///     This message is used in conjunction with the use of header sequence number.
    /// Message sent by: Controller and Integrator:
    ///     Is sent immediately after the message is received on application link level and if the check of the
    ///     header is found to be ok.
    ///     The acknowledge substitute the use of NoAck flag and all subscription data special acknowledging.
    /// </summary>
    class MID_9997
    {
    }
}
