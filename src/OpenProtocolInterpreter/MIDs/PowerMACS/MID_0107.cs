using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.PowerMACS
{
    /// <summary>
    /// MID: Last Power MACS tightening result Bolt data
    /// Description: 
    ///    This message contains the cycle data for one Bolt, both Bolt data and step data. It is only sent if 
    ///    the acknowledgement of the message MID 0106 Last PowerMACS tightening result station data had the parameter 
    ///    Bolt Data set to TRUE. The next Bolt data is sent if the acknowledgement has the parameter Bolt Data set to TRUE.
    ///    This telegram is also used for Power MACS systems running a Press.The layout of the telegram is exactly the 
    ///    same but some of the fields have slightly different definitions. The fields for Torque are used for Force values 
    ///    and the fields for Angle are used for Stroke values. Press systems also use different identifiers for the optional 
    ///    data on bolt and step level. Press systems always use revision 4 or higher of the telegram.Values in the fixed part
    ///    that are undefined in the results will be sent as all spaces (ASCII 0x20). 
    ///    This can happen with the Customer Error Code if this function is not activated.
    ///    Note 2: The Bolt results and step results are only sent when the value exists in the result. This means,
    ///    for example, that if no high limit is programmed for Peak T, then the value Peak T + will not be sent
    ///    even if limits for Peak T are defined in the reporter.
    /// Message sent by: Controller
    /// Answer: MID 0108 Last PowerMACS tightening result data acknowledge
    /// </summary>
    internal class MID_0107 : MID, IPowerMACS
    {
        public const int MID = 107;
        private const int length = 9999;
        private const int revision = 1;

        public MID_0107() : base(length, MID, revision) { }

        internal MID_0107(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {

            }

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }

        public enum DataFields
        {
            
        }
    }
}
