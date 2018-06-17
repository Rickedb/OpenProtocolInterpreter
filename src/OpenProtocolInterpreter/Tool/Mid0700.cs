using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// MID: Tightening data download status
    /// Description: 
    ///     Used by controller to upload the status of tightening data download to an radio connected tool.
    ///     Must be subscribed for by generic MID 0008 and unsubscribed for with generic MID 0009.
    ///     No extra data is needed and no historical data is applicable.
    /// Message sent by: Controller
    /// Answer: MID 0005 Command accepted
    /// </summary>
    class Mid0700
    {
    }
}
