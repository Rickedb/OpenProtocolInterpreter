using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.Job.Advanced
{
    /// <summary>
    /// MID: Set Job line alert 2
    /// Description: The integrator can set the line control alert 2 in the controller with this message.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0133 : MID
    {
        private const int length = 20;
        public const int MID = 133;
        private const int revision = 1;

        public MID_0133() : base(length, MID, revision) { }

        internal MID_0133(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0133)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
