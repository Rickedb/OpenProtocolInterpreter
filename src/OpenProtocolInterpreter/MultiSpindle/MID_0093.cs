using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// MID: Multi-spindle status acknowledge
    /// Description: 
    ///      Multi-spindle status acknowledge.
    /// Message sent by: Integrator
    /// Answer : None
    /// </summary>
    public class MID_0093 : Mid, IMultiSpindle
    {
        private const int LAST_REVISION = 1;
        public const int MID = 93;

        public MID_0093() : base(MID, LAST_REVISION)
        {

        }

        internal MID_0093(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
