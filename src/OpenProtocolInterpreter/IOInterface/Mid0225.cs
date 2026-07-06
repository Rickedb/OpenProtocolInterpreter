using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Reset digital input function
    /// <para>
    ///     Reset the digital input function with the digital input number.
    ///     The digital input function numbers are defined in Table 80.
    /// </para>
    /// <para>
    ///     This MID will only affect the digital input functions of tracking type.
    ///     The digital input functions with the type flank cannot be reset (for example reset the reset
    ///     batch digital input function will have no effect).
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Invalid data</para>
    /// </summary>
    public class Mid0225 : Mid, IIOInterface, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 225;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.InvalidData };


        [Int32DataFieldDefinition(field: 1, revision: 1, Size = 3, HasPrefix = false)]
        public DigitalInputNumber DigitalInputNumber { get; set; }

        public Mid0225() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0225(Header header) : base(header)
        {
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            DigitalInputNumber
        }
    }
}
