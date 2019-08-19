using System;
using System.Collections.Generic;
using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.IOInterface
{
    internal class IOInterfaceMessages : MessagesTemplate
    {
        public IOInterfaceMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
                { Mid0200.MID, new MidCompiledInstance(typeof(Mid0200)) },
                { Mid0210.MID, new MidCompiledInstance(typeof(Mid0210)) },
                { Mid0211.MID, new MidCompiledInstance(typeof(Mid0211)) },
                { Mid0212.MID, new MidCompiledInstance(typeof(Mid0212)) },
                { Mid0213.MID, new MidCompiledInstance(typeof(Mid0213)) },
                { Mid0214.MID, new MidCompiledInstance(typeof(Mid0214)) },
                { Mid0215.MID, new MidCompiledInstance(typeof(Mid0215)) },
                { Mid0216.MID, new MidCompiledInstance(typeof(Mid0216)) },
                { Mid0217.MID, new MidCompiledInstance(typeof(Mid0217)) },
                { Mid0218.MID, new MidCompiledInstance(typeof(Mid0218)) },
                { Mid0219.MID, new MidCompiledInstance(typeof(Mid0219)) },
                { Mid0220.MID, new MidCompiledInstance(typeof(Mid0220)) },
                { Mid0221.MID, new MidCompiledInstance(typeof(Mid0221)) },
                { Mid0222.MID, new MidCompiledInstance(typeof(Mid0222)) },
                { Mid0223.MID, new MidCompiledInstance(typeof(Mid0223)) },
                { Mid0224.MID, new MidCompiledInstance(typeof(Mid0224)) },
                { Mid0225.MID, new MidCompiledInstance(typeof(Mid0225)) }
            };
        }

        public IOInterfaceMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public IOInterfaceMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 199 && mid < 226;
    }
}
