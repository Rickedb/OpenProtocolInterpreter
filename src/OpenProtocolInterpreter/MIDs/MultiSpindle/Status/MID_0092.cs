using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.MultiSpindle.Status
{
    /// <summary>
    /// MID: Multi-spindle status acknowledge
    /// Description: 
    ///      Multi-spindle status acknowledge.
    /// Message sent by: Integrator
    /// Answer : None
    /// </summary>
    public class MID_0092 : MID, IMultiSpindle
    {
        public const int MID = 92;
        private const int length = 20;
        private const int revision = 1;

        public MID_0092() : base(length, MID, revision) { }

        internal MID_0092(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0092)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
