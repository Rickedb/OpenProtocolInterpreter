using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.PowerMACS
{
    internal class PowerMACSMessages : MessagesTemplate
    {
        public PowerMACSMessages() : base()
        {
            _templates = new Dictionary<int, Type>()
            {
                { Mid0105.MID, typeof(Mid0105) },
                { Mid0106.MID, typeof(Mid0106) },
                { Mid0107.MID, typeof(Mid0107) },
                { Mid0108.MID, typeof(Mid0108) },
                { Mid0109.MID, typeof(Mid0109) }
            };
        }

        public PowerMACSMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public PowerMACSMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 104 && mid < 110;
    }
}
