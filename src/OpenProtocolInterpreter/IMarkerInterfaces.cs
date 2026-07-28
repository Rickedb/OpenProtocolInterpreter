using System.Collections.Generic;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Contract which every controller <see cref="Mid"/> message implements.
    /// </summary>
    public interface IController
    {
    }

    /// <summary>
    /// Contract which every integrator <see cref="Mid"/> message implements.
    /// </summary>
    public interface IIntegrator
    {
    }

    /// <summary>
    /// Contract which every acknowledge <see cref="Mid"/> message implements.
    /// </summary>
    public interface IAcknowledge
    {
    }

    /// <summary>
    /// Contract which every <see cref="Mid"/> that might needs an acknowledge response implements.
    /// </summary>
    public interface IAcknowledgeable<TAckMid> where TAckMid : Mid, IAcknowledge, new()
    {

    }

    /// <summary>
    /// Contract of every <see cref="Mid"/> message that can be answered by another mid which is not classified as an acknowledge.
    /// </summary>
    public interface IAnswerableBy<TAnswerMid> where TAnswerMid : Mid
    {

    }

    /// <summary>
    /// Contract of every <see cref="Mid"/> message that can be accepted with <see cref="Communication.Mid0005"/> implements.
    /// </summary>
    public interface IAcceptableCommand
    {
    }

    /// <summary>
    /// Contract which every <see cref="Mid"/> message that can be declined with <see cref="Communication.Mid0004"/> implements.
    /// </summary>
    public interface IDeclinableCommand
    {
        IEnumerable<Error> DocumentedPossibleErrors { get; }
    }

    /// <summary>
    /// Contract which every subscription <see cref="Mid"/> message implements.
    /// </summary>
    public interface ISubscription
    {
    }

    /// <summary>
    /// Contract which every unsubscription <see cref="Mid"/> message implements.
    /// </summary>
    public interface IUnsubscription
    {
    }
}
