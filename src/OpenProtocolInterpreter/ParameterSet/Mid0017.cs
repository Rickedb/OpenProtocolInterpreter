using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Parameter set selected unsubscribe
    /// <para>Reset the subscription for the parameter set selection.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///     <see cref="Communication.Mid0004"/> Command error, Parameter set subscription does not exist
    /// </para>
    /// </summary>
    public class Mid0017 : Mid, IParameterSet, IIntegrator, IUnsubscription, IAcceptableCommand, IDeclinableCommand
    {
        private const int LAST_REVISION = 1;
        public const int MID = 17;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.PARAMETER_SET_SELECTION_SUBSCRIPTION_DOESNT_EXISTS };

        public Mid0017() : base(MID, LAST_REVISION) { }

        public Mid0017(Header header) : base(header)
        {
        }
    }
}
