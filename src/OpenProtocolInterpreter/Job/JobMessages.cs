using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Template for <see cref="IJob"/> implementers.
    /// </summary>
    internal class JobMessages : MessagesTemplate
    {
        public JobMessages() : base()
        {
            _templates = new Dictionary<int, CompiledInstance<Mid>>()
            {
                { Mid0030.MID, new CompiledInstance<Mid>(typeof(Mid0030)) },
                { Mid0031.MID, new CompiledInstance<Mid>(typeof(Mid0031)) },
                { Mid0032.MID, new CompiledInstance<Mid>(typeof(Mid0032)) },
                { Mid0033.MID, new CompiledInstance<Mid>(typeof(Mid0033)) },
                { Mid0034.MID, new CompiledInstance<Mid>(typeof(Mid0034)) },
                { Mid0035.MID, new CompiledInstance<Mid>(typeof(Mid0035)) },
                { Mid0036.MID, new CompiledInstance<Mid>(typeof(Mid0036)) },
                { Mid0037.MID, new CompiledInstance<Mid>(typeof(Mid0037)) },
                { Mid0038.MID, new CompiledInstance<Mid>(typeof(Mid0038)) },
                { Mid0039.MID, new CompiledInstance<Mid>(typeof(Mid0039)) }
            };
        }

        public JobMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public JobMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 29 && mid < 40;
    }
}
