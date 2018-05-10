using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// MID: Multi-spindle status acknowledge
    /// Description: 
    ///      Multi-spindle status acknowledge.
    /// Message sent by: Integrator
    /// Answer : None
    /// </summary>
    public class MID_0092 : Mid, IMultiSpindle
    {
        public const int MID = 92;
        private const int length = 20;
        private const int revision = 1;

        public MID_0092() : base(length, MID, revision) { }

        internal MID_0092(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0092)base.ProcessPackage(package);

            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
