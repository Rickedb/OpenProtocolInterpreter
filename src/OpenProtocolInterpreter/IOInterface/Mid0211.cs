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

        [BooleanDataFieldDefinition(field: 0, revision: 1, HasPrefix = false)]
        public bool StatusDigInOne { get; set; }
        [BooleanDataFieldDefinition(field: 1, revision: 1, HasPrefix = false)]
        public bool StatusDigInTwo { get; set; }
        [BooleanDataFieldDefinition(field: 2, revision: 1, HasPrefix = false)]
        public bool StatusDigInThree { get; set; }
        [BooleanDataFieldDefinition(field: 3, revision: 1, HasPrefix = false)]
        public bool StatusDigInFour { get; set; }
        [BooleanDataFieldDefinition(field: 4, revision: 1, HasPrefix = false)]
        public bool StatusDigInFive { get; set; }
        [BooleanDataFieldDefinition(field: 5, revision: 1, HasPrefix = false)]
        public bool StatusDigInSix { get; set; }
        [BooleanDataFieldDefinition(field: 6, revision: 1, HasPrefix = false)]
        public bool StatusDigInSeven { get; set; }
        [BooleanDataFieldDefinition(field: 7, revision: 1, HasPrefix = false)]
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

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            StatusDigIn1,
            StatusDigIn2,
            StatusDigIn3,
            StatusDigIn4,
            StatusDigIn5,
            StatusDigIn6,
            StatusDigIn7,
            StatusDigIn8
        }
    }
}
