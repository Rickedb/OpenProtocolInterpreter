using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.RexrothJob
{
    /// <summary>
    /// Template for <see cref="IRexrothJob"/> implementers.
    /// </summary>
    internal class RexrothJobMessages : MessagesTemplate
    {
        public RexrothJobMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
                { Mid0554.MID, new MidCompiledInstance(typeof(Mid0554)) },
                { Mid0555.MID, new MidCompiledInstance(typeof(Mid0555)) },
                { Mid0556.MID, new MidCompiledInstance(typeof(Mid0556)) },
                { Mid0557.MID, new MidCompiledInstance(typeof(Mid0557)) },
                { Mid0570.MID, new MidCompiledInstance(typeof(Mid0570)) },
                { Mid0571.MID, new MidCompiledInstance(typeof(Mid0571)) },
                { Mid0573.MID, new MidCompiledInstance(typeof(Mid0573)) },
                { Mid0574.MID, new MidCompiledInstance(typeof(Mid0574)) }
            };
        }

        public RexrothJobMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public RexrothJobMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => (mid > 553 && mid < 558) || (mid > 569 && mid < 575);
    }
}
