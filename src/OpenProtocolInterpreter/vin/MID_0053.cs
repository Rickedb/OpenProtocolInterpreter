using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.VIN
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
        public const int MID = 53;
        private const int revision = 1;

        public MID_0053() : base(length, MID, revision)
        {

        }

        internal MID_0053(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
