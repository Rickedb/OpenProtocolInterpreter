using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Time
{
    internal class TimeMessages : MessagesTemplate
    {
        public TimeMessages() : base()
        {
            _templates = new Dictionary<int, Type>()
            {
                { Mid0080.MID, typeof(Mid0080) },
                { Mid0081.MID, typeof(Mid0081) },
                { Mid0082.MID, typeof(Mid0082) }
            };
        }

        public TimeMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public TimeMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 79 && mid < 83;
    }
}
