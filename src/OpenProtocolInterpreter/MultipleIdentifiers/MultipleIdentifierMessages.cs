using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    internal class MultipleIdentifierMessages : MessagesTemplate
    {
        public MultipleIdentifierMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
                { Mid0150.MID, new MidCompiledInstance(typeof(Mid0150)) },
                { Mid0151.MID, new MidCompiledInstance(typeof(Mid0151)) },
                { Mid0152.MID, new MidCompiledInstance(typeof(Mid0152)) },
                { Mid0153.MID, new MidCompiledInstance(typeof(Mid0153)) },
                { Mid0154.MID, new MidCompiledInstance(typeof(Mid0154)) },
                { Mid0155.MID, new MidCompiledInstance(typeof(Mid0155)) },
                { Mid0156.MID, new MidCompiledInstance(typeof(Mid0156)) },
                { Mid0157.MID, new MidCompiledInstance(typeof(Mid0157)) }
            };
        }

        public MultipleIdentifierMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public MultipleIdentifierMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 149 && mid < 158;
    }
}
