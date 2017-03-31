using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.Tightening
{
    /// <summary>
    /// MID: Old tightening result upload request
    /// Description: This message is a request to upload a particular tightening result from the controller. The requested
    ///              result is specified by its unique ID(tightening ID). This message is useful after a failure of the
    ///              network in order to retrieve the missing result during the communication interruption.The integrator
    ///              can see the missing results by always comparing the last tightening IDs of the two last received
    ///              tightenings packets (parameter 23 in the result message).
    ///              Requesting tightening ID zero is the same as requesting the latest tightening performed.
    /// Message sent by: Integrator
    /// Answer: MID 0065 Old tightening result upload reply 
    ///         or MID 0004 Command error, Tightening ID requested not found,
    ///         or MID revision not supported
    /// </summary>
    public class MID_0064 : MID
    {
        private const int length = 30;
        private const int mid = 64;
        private const int revision = 1;

        public MID_0064() : base(length, mid, revision)
        {

        }

        public override IEnumerable<DataField> processPackage(string package)
        {
            throw new NotImplementedException();
        }
    }
}
