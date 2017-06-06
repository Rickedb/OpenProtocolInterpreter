namespace OpenProtocolInterpreter.MIDs.MotorTuning
{
    /// <summary>
    /// MID: Motor tuning result data subscribe
    /// Description: 
    ///     Sets the subscription for the motor tuning result. 
    ///     The result of this command will be the transmission of the motor 
    ///     tuning result after the motor tuning is performed. The MID revision in 
    ///     the header is used to subscribe to different revisions of MID 0501 Motor 
    ///     tuning result data upload reply.
    /// Message sent by: Integrator
    /// Answer: MID 0004 Command error, Motor Tuning subscription already exists or MID revision not supported
    /// </summary>
    public class MID_0500 : MID, IMotorTuning
    {
        private const int length = 20;
        public const int MID = 500;
        private const int revision = 1;

        public MID_0500() : base(length, MID, revision) { }

        internal MID_0500(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0500)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
