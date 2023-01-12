using System.Collections.Generic;

namespace OpenProtocolInterpreter.MotorTuning
{
    /// <summary>
    /// Motor tuning result data subscribe
    /// <para>
    ///     Sets the subscription for the motor tuning result. 
    ///     The result of this command will be the transmission of the motor 
    ///     tuning result after the motor tuning is performed. The MID revision in 
    ///     the header is used to subscribe to different revisions of MID 0501 Motor 
    ///     tuning result data upload reply.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0004"/> Command error, Motor Tuning subscription already exists or MID revision not supported</para>
    /// </summary>
    public class Mid0500 : Mid, IMotorTuning, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        private const int LAST_REVISION = 1;
        public const int MID = 500;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.SUBSCRIPTION_ALREADY_EXISTS, Error.MID_REVISION_UNSUPPORTED};

        public Mid0500() : this(false) 
        { 
        }

        public Mid0500(bool noAckFlag = false) : base(MID, LAST_REVISION, noAckFlag) 
        { 
        }

        public Mid0500(Header header) : base(header)
        {
        }
    }
}
