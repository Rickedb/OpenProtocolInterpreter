namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Parameter set selected subscribe
    /// <para>
    ///     A subscription for the parameter set selection. Each time a new parameter set is selected the <see cref="Mid0015"/>
    ///     Parameter set selected is sent to the integrator.
    /// </para>
    /// <para>
    ///     Note that the immediate response is <see cref="Communication.Mid0005"/> Command
    ///     accepted and <see cref="Mid0015"/> Parameter set selected with the current parameter set number selected.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted and <see cref="Mid0015"/> Parameter set selected</para>
    /// </summary>
    public class Mid0014 : Mid, IParameterSet, IIntegrator, ISubscription, IAcceptableCommand, IAnswerableBy<Mid0015>
    {
        private const int LAST_REVISION = 1;
        public const int MID = 14;

        public Mid0014() : this(false)
        {

        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="noAckFlag">False=Ack needed, True=No Ack needed</param>
        public Mid0014(bool noAckFlag = false) : base(MID, LAST_REVISION, noAckFlag) 
        { 
        
        }

        public Mid0014(Header header) : base(header)
        {
        }
    }
}
