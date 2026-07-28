using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Set externally controlled relays
    /// <para>
    ///     By using this message the integrator can control 10 relays (externally control relays). The station can
    ///     set, reset the relays or make them flashing.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0200 : Mid, IIOInterface, IIntegrator, IAcceptableCommand
    {
        public const int MID = 200;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelayOne { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 21, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelayTwo { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 3, Index = 22, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelayThree { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 4, Index = 23, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelayFour { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 5, Index = 24, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelayFive { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 6, Index = 25, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelaySix { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 7, Index = 26, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelaySeven { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 8, Index = 27, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelayEight { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 9, Index = 28, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelayNine { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 10, Index = 29, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelayTen { get; set; }

        public Mid0200() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0200(Header header) : base(header)
        {
        }
    }
}
