using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MultiSpindle.Result
{
    /// <summary>
    /// MID: Multi-spindle status subscribe
    /// Description:
    ///     A subscription for the multi-spindle status. For Power Focus, the subscription must 
    ///     be addressed to a sync Master. This telegram is also used for a PowerMACS 4000 system 
    ///     running a press instead of a spindle. A press system only supports revision 4 and higher 
    ///     of the telegram and will answer with MID 0004, MID revision unsupported if a subscription 
    ///     is made with a lower revision.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, 
    ///         Controller is not a sync master/station controller, 
    ///         Multi-spindle result subscription already exists or MID revision unsupported
    /// </summary>
    class MID_0100 
    {
        public const int MID = 100;
        private const int length = 20;
        private const int revision = 1;

    }
}
