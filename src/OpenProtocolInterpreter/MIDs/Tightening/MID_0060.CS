using System;
namespace OpenProtocolInterpreter.MIDs.Tightening
{
    /// <summary>
    /// MID: Last tightening result data subscribe
    /// Description: 
    ///     Set the subscription for the result tightenings. The result of this command will be the transmission of
    ///     the tightening result after the tightening is performed(push function). The MID revision in the header
    ///     is used to subscribe to different revisions of MID 0061 Last tightening result data upload reply.
    /// 
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Last tightening subscription already 
    ///         exists or MID revision not supported
    /// </summary>
    public class MID_0060 : MID, ITightening
    {
        private const int length = 20;
        public const int MID = 60;
        private const int revision = 1;

        public MID_0060() : base(length, MID, revision)
        {

        }

        internal MID_0060(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if(base.isCorrectType(package))
                return base.processPackage(package);

            throw new NotImplementedException("MID not implemented or doesn't exists");
        }

        protected override void registerDatafields() { }
    }
}
