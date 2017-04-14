using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.Communication
{
    /// <summary>
    /// MID: Application Communication positive acknowledge
    /// Description: 
    ///     Do a request for data. This message is used for ALL request handling.
    ///     When used it substitutes the use of all MID special request messages.
    ///     NOTE! The Header Revision field is the revision of the MID 0006 itself NOT 
    ///     the revision of the data MID that is wanted to be uploaded.
    /// 
    /// Message sent by: Integrator
    /// Answer: MID Requested for or MID 0004 Command error. Error described at each MID description.
    /// </summary>
    public class MID_0006 : MID
    {
        private const int length = 24;
        private const int mid = 5;
        private const int revision = 1;

        public int MIDAccepted { get; set; }

        public MID_0006() : base(length, mid, revision)
        {

        }

        public MID_0006(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            throw new NotImplementedException();
        }

        public override MID processPackage(string package)
        {
            throw new NotImplementedException();
        }

    }
}
