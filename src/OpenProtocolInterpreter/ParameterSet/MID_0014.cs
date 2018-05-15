namespace OpenProtocolInterpreter.ParameterSet
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
    public class MID_0014 : Mid, IParameterSet
    {
        private const int LAST_REVISION = 1;
        public const int MID = 14;

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="ackFlag">0=Ack needed, 1=No Ack needed</param>
        public MID_0014(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag) 
        { 
        
        }

        internal MID_0014(IMid nextTemplate) : this()
        {
            NextTemplate = nextTemplate;
        }
    }
}
