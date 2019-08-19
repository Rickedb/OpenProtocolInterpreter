using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.PLCUserData
{
    internal class PLCUserDataMessages : MessagesTemplate
    {
        public PLCUserDataMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
                { Mid0240.MID, new MidCompiledInstance(typeof(Mid0240)) },
                { Mid0241.MID, new MidCompiledInstance(typeof(Mid0241)) },
                { Mid0242.MID, new MidCompiledInstance(typeof(Mid0242)) },
                { Mid0243.MID, new MidCompiledInstance(typeof(Mid0243)) },
                { Mid0244.MID, new MidCompiledInstance(typeof(Mid0244)) },
                { Mid0245.MID, new MidCompiledInstance(typeof(Mid0245)) }
            };
        }

        public PLCUserDataMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public PLCUserDataMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 239 && mid < 246;
    }
}
