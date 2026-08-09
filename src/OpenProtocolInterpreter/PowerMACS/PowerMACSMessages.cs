using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// Template for <see cref="IPowerMACS"/> implementers.
    /// </summary>
    internal class PowerMACSMessages : MessagesTemplate
    {
        public PowerMACSMessages() : base()
        {
            _templates = new Dictionary<int, CompiledInstance<Mid>>()
            {
                { Mid0105.MID, new CompiledInstance<Mid>(typeof(Mid0105)) },
                { Mid0106.MID, new CompiledInstance<Mid>(typeof(Mid0106)) },
                { Mid0107.MID, new CompiledInstance<Mid>(typeof(Mid0107)) },
                { Mid0108.MID, new CompiledInstance<Mid>(typeof(Mid0108)) },
                { Mid0109.MID, new CompiledInstance<Mid>(typeof(Mid0109)) }
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
