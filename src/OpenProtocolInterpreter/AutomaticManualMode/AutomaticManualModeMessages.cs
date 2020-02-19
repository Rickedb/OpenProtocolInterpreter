using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// Template for <see cref="IAutomaticManualMode"/> implementers.
    /// </summary>
    internal class AutomaticManualModeMessages : MessagesTemplate
    {
        public AutomaticManualModeMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
                { Mid0400.MID, new MidCompiledInstance(typeof(Mid0400)) },
                { Mid0401.MID, new MidCompiledInstance(typeof(Mid0401)) },
                { Mid0402.MID, new MidCompiledInstance(typeof(Mid0402)) },
                { Mid0403.MID, new MidCompiledInstance(typeof(Mid0403)) },
                { Mid0410.MID, new MidCompiledInstance(typeof(Mid0410)) },
                { Mid0411.MID, new MidCompiledInstance(typeof(Mid0411)) }
            };
        }

        public AutomaticManualModeMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public AutomaticManualModeMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 399 && mid < 412;
    }
}
