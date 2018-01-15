using System.Linq.Expressions;

namespace OpenProtocolInterpreter.MIDs.ParameterSet
{
    /// <summary>
    /// MID: Parameter set selected subscribe
    /// Description: 
    ///     A subscription for the parameter set selection. Each time a new parameter set is selected the MID 0015
    ///     Parameter set selected is sent to the integrator.Note that the immediate response is MID 0005 Command
    ///     accepted and MID 0015 Parameter set selected with the current parameter set number selected.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted and MID 0015 Parameter set selected
    /// </summary>
    public class MID_0014 : MID, IParameterSet
    {
        private const int length = 20;
        public const int MID = 14;
        private const int revision = 1;

        public MID_0014(bool? ackFlag = null) 
            : base(length, 
                  MID, 
                  revision, 
                  ((ackFlag != null) ? (int?)Expression.Constant(System.Convert.ToInt32(ackFlag), typeof(int?)).Value : null)) 
        { 
        
        }

        internal MID_0014(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0014)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
