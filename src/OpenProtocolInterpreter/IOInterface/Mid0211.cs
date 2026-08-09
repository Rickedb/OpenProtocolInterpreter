using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Status externally monitored inputs
    /// <para>
    ///    Status for the eight externally monitored digital inputs. This message is sent to the subscriber every
    ///    time the status of at least one of the inputs has changed.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0212"/> Status externally monitored inputs acknowledge</para>
    /// </summary>
    public class Mid0211 : Mid, IIOInterface, IController, IAcknowledgeable<Mid0212>
    {
        public const int MID = 211;

        [BooleanDataFieldDefinition(revision: 1, field: 1, Index = 20, HasPrefix = false)]
        public bool StatusDigInOne { get; set; }
        [BooleanDataFieldDefinition(revision: 1, field: 2, Index = 21, HasPrefix = false)]
        public bool StatusDigInTwo { get; set; }
        [BooleanDataFieldDefinition(revision: 1, field: 3, Index = 22, HasPrefix = false)]
        public bool StatusDigInThree { get; set; }
        [BooleanDataFieldDefinition(revision: 1, field: 4, Index = 23, HasPrefix = false)]
        public bool StatusDigInFour { get; set; }
        [BooleanDataFieldDefinition(revision: 1, field: 5, Index = 24, HasPrefix = false)]
        public bool StatusDigInFive { get; set; }
        [BooleanDataFieldDefinition(revision: 1, field: 6, Index = 25, HasPrefix = false)]
        public bool StatusDigInSix { get; set; }
        [BooleanDataFieldDefinition(revision: 1, field: 7, Index = 26, HasPrefix = false)]
        public bool StatusDigInSeven { get; set; }
        [BooleanDataFieldDefinition(revision: 1, field: 8, Index = 27, HasPrefix = false)]
        public bool StatusDigInEight { get; set; }

        public Mid0211() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0211(Header header) : base(header)
        {
        }
    }
}
