using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Template for <see cref="IAdvancedJob"/> implementers.
    /// </summary>
    internal class AdvancedJobMessages : MessagesTemplate
    {
        public AdvancedJobMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
                { Mid0120.MID, new MidCompiledInstance(typeof(Mid0120)) },
                { Mid0121.MID, new MidCompiledInstance(typeof(Mid0121)) },
                { Mid0122.MID, new MidCompiledInstance(typeof(Mid0122)) },
                { Mid0123.MID, new MidCompiledInstance(typeof(Mid0123)) },
                { Mid0124.MID, new MidCompiledInstance(typeof(Mid0124)) },
                { Mid0125.MID, new MidCompiledInstance(typeof(Mid0125)) },
                { Mid0126.MID, new MidCompiledInstance(typeof(Mid0126)) },
                { Mid0127.MID, new MidCompiledInstance(typeof(Mid0127)) },
                { Mid0128.MID, new MidCompiledInstance(typeof(Mid0128)) },
                { Mid0129.MID, new MidCompiledInstance(typeof(Mid0129)) },
                { Mid0130.MID, new MidCompiledInstance(typeof(Mid0130)) },
                { Mid0131.MID, new MidCompiledInstance(typeof(Mid0131)) },
                { Mid0132.MID, new MidCompiledInstance(typeof(Mid0132)) },
                { Mid0133.MID, new MidCompiledInstance(typeof(Mid0133)) },
                { Mid0140.MID, new MidCompiledInstance(typeof(Mid0140)) }
            };
        }

        public AdvancedJobMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public AdvancedJobMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 119 && mid < 141;
    }
}
