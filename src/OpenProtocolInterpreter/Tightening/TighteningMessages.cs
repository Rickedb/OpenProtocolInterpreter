using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Template for <see cref="ITightening"/> implementers.
    /// </summary>
    internal class TighteningMessages : MessagesTemplate
    {
        public TighteningMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
                { Mid0060.MID, new MidCompiledInstance(typeof(Mid0060)) },
                { Mid0061.MID, new MidCompiledInstance(typeof(Mid0061)) },
                { Mid0062.MID, new MidCompiledInstance(typeof(Mid0062)) },
                { Mid0063.MID, new MidCompiledInstance(typeof(Mid0063)) },
                { Mid0064.MID, new MidCompiledInstance(typeof(Mid0064)) },
                { Mid0065.MID, new MidCompiledInstance(typeof(Mid0065)) },
                { Mid0066.MID, new MidCompiledInstance(typeof(Mid0066)) }
            };
        }

        public TighteningMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public TighteningMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 59 && mid < 67;
    }
}
