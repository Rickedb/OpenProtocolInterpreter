using System;

namespace OpenProtocolInterpreter.MIDs.ParameterSet
{
    /// <summary>
    /// MID: Parameter set ID upload request
    /// Description: 
    ///     A request to get the valid parameter set IDs from the controller.
    /// Message sent by: Integrator
    /// Answer: MID 0011 Parameter set ID upload reply
    /// </summary>
    public class MID_0010 : MID, IParameterSet
    {
        private const int length = 20;
        public const int MID = 10;
        private const int revision = 1;

        public MID_0010() : base(length, MID, revision) { }

        internal MID_0010(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0010)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() {  }
    }
}
