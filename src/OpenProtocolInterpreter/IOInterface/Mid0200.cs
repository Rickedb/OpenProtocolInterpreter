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

        [Int32DataFieldDefinition(field: 0, revision: 1, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelayOne { get; set; }
        [Int32DataFieldDefinition(field: 1, revision: 1, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelayTwo { get; set; }
        [Int32DataFieldDefinition(field: 2, revision: 1, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelayThree { get; set; }
        [Int32DataFieldDefinition(field: 3, revision: 1, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelayFour { get; set; }
        [Int32DataFieldDefinition(field: 4, revision: 1, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelayFive { get; set; }
        [Int32DataFieldDefinition(field: 5, revision: 1, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelaySix { get; set; }
        [Int32DataFieldDefinition(field: 6, revision: 1, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelaySeven { get; set; }
        [Int32DataFieldDefinition(field: 7, revision: 1, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelayEight { get; set; }
        [Int32DataFieldDefinition(field: 8, revision: 1, Size = 1, HasPrefix = false)]
        public RelayStatus StatusRelayNine { get; set; }
        [Int32DataFieldDefinition(field: 9, revision: 1, Size = 1, HasPrefix = false)]
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

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            StatusRelay1,
            StatusRelay2,
            StatusRelay3,
            StatusRelay4,
            StatusRelay5,
            StatusRelay6,
            StatusRelay7,
            StatusRelay8,
            StatusRelay9,
            StatusRelay10
        }
    }
}
