using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Result
{
    internal class ResultMessages : MessagesTemplate
    {
        public ResultMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
                { Mid1201.MID, new MidCompiledInstance(typeof(Mid1201)) },
                { Mid1202.MID, new MidCompiledInstance(typeof(Mid1202)) },
                { Mid1203.MID, new MidCompiledInstance(typeof(Mid1203)) }
            };
        }

        public ResultMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public ResultMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 1200 && mid < 1204;
    }
}
