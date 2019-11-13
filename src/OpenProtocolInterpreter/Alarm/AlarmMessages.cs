using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Alarm
{
    internal class AlarmMessages : MessagesTemplate
    {
        public AlarmMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
               { Mid0070.MID,  new MidCompiledInstance(typeof(Mid0070)) },
               { Mid0071.MID,  new MidCompiledInstance(typeof(Mid0071)) },
               { Mid0072.MID,  new MidCompiledInstance(typeof(Mid0072)) },
               { Mid0073.MID,  new MidCompiledInstance(typeof(Mid0073)) },
               { Mid0074.MID,  new MidCompiledInstance(typeof(Mid0074)) },
               { Mid0075.MID,  new MidCompiledInstance(typeof(Mid0075)) },
               { Mid0076.MID,  new MidCompiledInstance(typeof(Mid0076)) },
               { Mid0077.MID,  new MidCompiledInstance(typeof(Mid0077)) },
               { Mid0078.MID,  new MidCompiledInstance(typeof(Mid0078)) },
            };
        }

        public AlarmMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public AlarmMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 69 && mid < 79;
    }
}
