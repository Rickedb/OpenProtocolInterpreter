using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    internal class ToolMessages : MessagesTemplate
    {
        public ToolMessages() : base()
        {
            _templates = new Dictionary<int, Type>()
            {
                { Mid0040.MID, typeof(Mid0040) },
                { Mid0041.MID, typeof(Mid0041) },
                { Mid0042.MID, typeof(Mid0042) },
                { Mid0043.MID, typeof(Mid0043) },
                { Mid0044.MID, typeof(Mid0044) },
                { Mid0045.MID, typeof(Mid0045) },
                { Mid0046.MID, typeof(Mid0046) },
                { Mid0047.MID, typeof(Mid0047) },
                { Mid0048.MID, typeof(Mid0048) }
            };
        }

        public ToolMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public ToolMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 39 && mid < 49;
    }
}
