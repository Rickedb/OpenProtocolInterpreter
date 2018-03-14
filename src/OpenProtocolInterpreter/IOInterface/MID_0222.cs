using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Digital input function acknowledge
    /// Description: 
    ///     Acknowledgement of the digital input function upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0222 : MID, IIOInterface
    {
        public const int MID = 222;
        private const int length = 20;
        private const int revision = 1;

        public MID_0222() : base(length, MID, revision) { }

        internal MID_0222(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0222)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
