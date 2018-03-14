using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.VIN
{
    /// <summary>
    /// MID: Vehicle ID Number unsubscribe
    /// Description: 
    ///     Reset the subscription for the current tightening identifiers.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, VIN subscription does not exist
    /// </summary>
    public class MID_0054 : MID, IVIN
    {
        private const int length = 20;
        public const int MID = 54;
        private const int revision = 1;

        public MID_0054() : base(length, MID, revision)
        {

        }

        internal MID_0054(IMID nextTemplate) : base(length, MID, revision)
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
