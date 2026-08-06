using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Template for <see cref="IParameterSet"/> implementers.
    /// </summary>
    internal class ParameterSetMessages : MessagesTemplate
    {
        public ParameterSetMessages() : base()
        {
            _templates = new Dictionary<int, CompiledInstance<Mid>>()
            {
                { Mid0010.MID, new CompiledInstance<Mid>(typeof(Mid0010)) },
                { Mid0011.MID, new CompiledInstance<Mid>(typeof(Mid0011)) },
                { Mid0012.MID, new CompiledInstance<Mid>(typeof(Mid0012)) },
                { Mid0013.MID, new CompiledInstance<Mid>(typeof(Mid0013)) },
                { Mid0014.MID, new CompiledInstance<Mid>(typeof(Mid0014)) },
                { Mid0015.MID, new CompiledInstance<Mid>(typeof(Mid0015)) },
                { Mid0016.MID, new CompiledInstance<Mid>(typeof(Mid0016)) },
                { Mid0017.MID, new CompiledInstance<Mid>(typeof(Mid0017)) },
                { Mid0018.MID, new CompiledInstance<Mid>(typeof(Mid0018)) },
                { Mid0019.MID, new CompiledInstance<Mid>(typeof(Mid0019)) },
                { Mid0020.MID, new CompiledInstance<Mid>(typeof(Mid0020)) },
                { Mid0021.MID, new CompiledInstance<Mid>(typeof(Mid0021)) },
                { Mid0022.MID, new CompiledInstance<Mid>(typeof(Mid0022)) },
                { Mid0023.MID, new CompiledInstance<Mid>(typeof(Mid0023)) },
                { Mid0024.MID, new CompiledInstance<Mid>(typeof(Mid0024)) },
                { Mid2501.MID, new CompiledInstance<Mid>(typeof(Mid2501)) },
                { Mid2502.MID, new CompiledInstance<Mid>(typeof(Mid2502)) },
                { Mid2503.MID, new CompiledInstance<Mid>(typeof(Mid2503)) },
                { Mid2504.MID, new CompiledInstance<Mid>(typeof(Mid2504)) },
                { Mid2505.MID, new CompiledInstance<Mid>(typeof(Mid2505)) },
                { Mid2506.MID, new CompiledInstance<Mid>(typeof(Mid2506)) }
            };
        }

        public ParameterSetMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public ParameterSetMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 9 && mid < 26 || mid > 2499 && mid < 2507;
    }
}
