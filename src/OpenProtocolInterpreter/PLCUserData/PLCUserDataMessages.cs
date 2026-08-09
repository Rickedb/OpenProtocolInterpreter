using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// Template for <see cref="IPLCUserData"/> implementers.
    /// </summary>
    internal class PLCUserDataMessages : MessagesTemplate
    {
        public PLCUserDataMessages() : base()
        {
            _templates = new Dictionary<int, CompiledInstance<Mid>>()
            {
                { Mid0240.MID, new CompiledInstance<Mid>(typeof(Mid0240)) },
                { Mid0241.MID, new CompiledInstance<Mid>(typeof(Mid0241)) },
                { Mid0242.MID, new CompiledInstance<Mid>(typeof(Mid0242)) },
                { Mid0243.MID, new CompiledInstance<Mid>(typeof(Mid0243)) },
                { Mid0244.MID, new CompiledInstance<Mid>(typeof(Mid0244)) },
                { Mid0245.MID, new CompiledInstance<Mid>(typeof(Mid0245)) }
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
