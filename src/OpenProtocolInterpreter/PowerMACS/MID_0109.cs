using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// MID: Last Power MACS tightening result data unsubscribe
    /// Description: 
    ///    Reset the last Power MACS tightening result subscription for the rundowns result.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Subscription does not exist
    /// </summary>
    public class MID_0109 : Mid, IPowerMACS
    {
        public const int MID = 109;
        private const int length = 20;
        private const int revision = 1;

        public MID_0109() : base(length, MID, revision) { }

        internal MID_0109(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0109)base.ProcessPackage(package);

            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
