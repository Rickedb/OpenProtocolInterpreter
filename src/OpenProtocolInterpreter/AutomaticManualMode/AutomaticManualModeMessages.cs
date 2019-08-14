using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.AutomaticManualMode
{
    internal class AutomaticManualModeMessages : MessagesTemplate
    {
        public AutomaticManualModeMessages() : base()
        {
            _templates = new Dictionary<int, Type>()
            {
                { Mid0400.MID, typeof(Mid0400) },
                { Mid0401.MID, typeof(Mid0401) },
                { Mid0402.MID, typeof(Mid0402) },
                { Mid0403.MID, typeof(Mid0403) },
                { Mid0410.MID, typeof(Mid0410) },
                { Mid0411.MID, typeof(Mid0411) }
            };
        }

        public AutomaticManualModeMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public AutomaticManualModeMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 399 && mid < 412;
    }
}
