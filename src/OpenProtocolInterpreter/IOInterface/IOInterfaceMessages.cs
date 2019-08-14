using System;
using System.Collections.Generic;
using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.IOInterface
{
    internal class IOInterfaceMessages : MessagesTemplate
    {
        public IOInterfaceMessages() : base()
        {
            _templates = new Dictionary<int, Type>()
            {
                { Mid0200.MID, typeof(Mid0200) },
                { Mid0210.MID, typeof(Mid0210) },
                { Mid0211.MID, typeof(Mid0211) },
                { Mid0212.MID, typeof(Mid0212) },
                { Mid0213.MID, typeof(Mid0213) },
                { Mid0214.MID, typeof(Mid0214) },
                { Mid0215.MID, typeof(Mid0215) },
                { Mid0216.MID, typeof(Mid0216) },
                { Mid0217.MID, typeof(Mid0217) },
                { Mid0218.MID, typeof(Mid0218) },
                { Mid0219.MID, typeof(Mid0219) },
                { Mid0220.MID, typeof(Mid0220) },
                { Mid0221.MID, typeof(Mid0221) },
                { Mid0222.MID, typeof(Mid0222) },
                { Mid0223.MID, typeof(Mid0223) },
                { Mid0224.MID, typeof(Mid0224) },
                { Mid0225.MID, typeof(Mid0225) }
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
