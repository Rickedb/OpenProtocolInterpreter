using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCX.ITLC.UMI.AtlasCopco.OpenProtocol.MIDs.Tightening
{
    /// <summary>
    /// MID: Last tightening result data acknowledge
    /// Description: Acknowledgement of last tightening result data.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0062 : MID
    {
        private const int length = 20;
        private const int mid = 62;
        private const int revision = 1;

        public MID_0062() : base(length, mid, revision)
        {

        }

        public override IEnumerable<DataField> processPackage(string package)
        {
            throw new NotImplementedException();
        }
    }
}
