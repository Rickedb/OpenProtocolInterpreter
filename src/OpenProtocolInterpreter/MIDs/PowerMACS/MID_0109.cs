using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.PowerMACS
{
    /// <summary>
    /// MID: Last Power MACS tightening result data unsubscribe
    /// Description: 
    ///    Reset the last Power MACS tightening result subscription for the rundowns result.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Subscription does not exist
    /// </summary>
    public class MID_0109 : MID, IPowerMACS
    {
        public const int MID = 109;
        private const int length = 20;
        private const int revision = 1;

        public MID_0109() : base(length, MID, revision) { }

        internal MID_0109(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0109)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
