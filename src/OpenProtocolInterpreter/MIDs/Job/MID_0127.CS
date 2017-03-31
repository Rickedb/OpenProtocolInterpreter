using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.Job
{
    /// <summary>
    /// MID: Abort Job
    /// Description: Abort the current running job if there is one.
    /// Message sent by: Integrator
    /// Answer: MID 0005
    /// </summary>
    public class MID_0127 : MID
    {
        public MID_0127() : base(1,1,1)
        {

        }

        public override bool processPackage(string package)
        {
            throw new NotImplementedException();
        }
    }
}
