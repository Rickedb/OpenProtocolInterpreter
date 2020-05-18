using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Template for <see cref="IMultiSpindle"/> implementers.
    /// </summary>
    internal class MultiSpindleMessages : MessagesTemplate
    {
        public MultiSpindleMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
                { Mid0090.MID, new MidCompiledInstance(typeof(Mid0090)) },
                { Mid0091.MID, new MidCompiledInstance(typeof(Mid0091)) },
                { Mid0092.MID, new MidCompiledInstance(typeof(Mid0092)) },
                { Mid0093.MID, new MidCompiledInstance(typeof(Mid0093)) },
                { Mid0100.MID, new MidCompiledInstance(typeof(Mid0100)) },
                { Mid0101.MID, new MidCompiledInstance(typeof(Mid0101)) },
                { Mid0102.MID, new MidCompiledInstance(typeof(Mid0102)) },
                { Mid0103.MID, new MidCompiledInstance(typeof(Mid0103)) }
            };
        }

        public MultiSpindleMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public MultiSpindleMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 89 && mid < 104;
    }
}
