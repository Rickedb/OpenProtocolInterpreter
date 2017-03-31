using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.Tightening
{
    /// <summary>
    /// MID: Old tightening result upload reply
    /// Description: Old tightening upload.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0065 : MID
    {
        private const int length = 118;
        private const int mid = 65;
        private const int revision = 1;
        
        public MID_0065() : base(length, mid, revision)
        {

        }

        public override IEnumerable<DataField> processPackage(string package)
        {
            throw new NotImplementedException();
        }
    }
}
