using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Hvo
{
    /// <summary>
    /// Template for <see cref="IHvo"/> implementers.
    /// </summary>
    internal class HvoMessages : MessagesTemplate
    {
        public HvoMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
                { Mid0510.MID, new MidCompiledInstance(typeof(Mid0510)) },
                { Mid0512.MID, new MidCompiledInstance(typeof(Mid0512)) },
                { Mid0513.MID, new MidCompiledInstance(typeof(Mid0513)) },
                { Mid0515.MID, new MidCompiledInstance(typeof(Mid0515)) }
            };
        }

        public HvoMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public HvoMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 509 && mid < 516;
    }
}
