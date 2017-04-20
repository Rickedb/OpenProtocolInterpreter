using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.VIN
{
    /// <summary>
    /// MID: Vehicle ID Number acknowledge
    /// Description: 
    ///     Vehicle ID Number acknowledge.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0053 : MID, IVIN
    {
        private const int length = 20;
        private const int mid = 53;
        private const int revision = 1;

        public MID_0053() : base(length, mid, revision)
        {

        }

        internal MID_0053(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
