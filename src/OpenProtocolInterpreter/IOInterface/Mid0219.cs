using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Relay function unsubscribe
    /// <para>
    ///     Unsubscribe for a single relay function. The data field consists of three ASCII digits,
    ///     the relay number, which corresponds to the specific relay function. The relay numbers can be
    ///     found in Table 101.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, The relay function subscription does not exist</para>
    /// </summary>
    public class Mid0219 : Mid, IIOInterface, IIntegrator, IUnsubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 219;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.RelayFunctionSubscriptionDoesntExists };

        [Int32DataFieldDefinition(field: 1, revision: 1, Size = 3, HasPrefix = false)]
        public RelayNumber RelayNumber { get; set; }

        public Mid0219() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION,
        })
        {

        }

        public Mid0219(Header header) : base(header)
        {
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            RelayNumber
        }
    }
}
