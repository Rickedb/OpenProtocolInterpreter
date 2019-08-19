using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MultiSpindle
{
    internal class MultiSpindleMessages : MessagesTemplate
    {
        public MultiSpindleMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
                { Mid0090.MID, new MidCompiledInstance(typeof(Mid0090)) },
                { Mid0091.MID, new MidCompiledInstance(typeof(Mid0091)) },
                { Mid0092.MID, new MidCompiledInstance(typeof(Mid0092)) },
                { Mid0093.MID, new MidCompiledInstance(typeof(Mid0093)) }
            };
        }

        public MultiSpindleMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public MultiSpindleMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 89 && mid < 104;
    }
}
