using System;
using System.Collections.Generic;
using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    internal class ApplicationToolLocationSystemMessages : MessagesTemplate
    {
        public ApplicationToolLocationSystemMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
                { Mid0260.MID, new MidCompiledInstance(typeof(Mid0260)) },
                { Mid0261.MID, new MidCompiledInstance(typeof(Mid0261)) },
                { Mid0262.MID, new MidCompiledInstance(typeof(Mid0262)) },
                { Mid0263.MID, new MidCompiledInstance(typeof(Mid0263)) },
                { Mid0264.MID, new MidCompiledInstance(typeof(Mid0264)) },
                { Mid0265.MID, new MidCompiledInstance(typeof(Mid0265)) }
            };
        }

        public ApplicationToolLocationSystemMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public ApplicationToolLocationSystemMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 259 && mid < 266;
    }
}
