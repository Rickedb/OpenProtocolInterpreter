using System;
using System.Collections.Generic;
using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// Template for <see cref="ICommunication"/> implementers.
    /// </summary>
    internal class CommunicationMessages : MessagesTemplate
    {
        public CommunicationMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
               { Mid0001.MID, new MidCompiledInstance(typeof(Mid0001)) },
               { Mid0002.MID, new MidCompiledInstance(typeof(Mid0002)) },
               { Mid0003.MID, new MidCompiledInstance(typeof(Mid0003)) },
               { Mid0004.MID, new MidCompiledInstance(typeof(Mid0004)) },
               { Mid0005.MID, new MidCompiledInstance(typeof(Mid0005)) },
               { Mid0006.MID, new MidCompiledInstance(typeof(Mid0006)) },
               { Mid0008.MID, new MidCompiledInstance(typeof(Mid0008)) }
            };
        }

        public CommunicationMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public CommunicationMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 0 && mid < 10;
    }
}
