using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.UserInterface
{
    /// <summary>
    /// MID: Flash green light on tool
    /// Description: 
    ///     By sending this message the integrator can make the green light on the tool flash. The light on the tool
    ///     will flash until the operator pushes the tool trigger.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0113 : MID, IUserInterface
    {
        private const int length = 20;
        public const int MID = 113;
        private const int revision = 1;

        public MID_0113() : base(length, MID, revision)
        {

        }

        internal MID_0113(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0113)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
