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
            _templates = new Dictionary<int, CompiledInstance<Mid>>()
            {
               { Mid0001.MID, new CompiledInstance<Mid>(typeof(Mid0001)) },
               { Mid0002.MID, new CompiledInstance<Mid>(typeof(Mid0002)) },
               { Mid0003.MID, new CompiledInstance<Mid>(typeof(Mid0003)) },
               { Mid0004.MID, new CompiledInstance<Mid>(typeof(Mid0004)) },
               { Mid0005.MID, new CompiledInstance<Mid>(typeof(Mid0005)) },
               { Mid0006.MID, new CompiledInstance<Mid>(typeof(Mid0006)) },
               { Mid0008.MID, new CompiledInstance<Mid>(typeof(Mid0008)) },
               { Mid0009.MID, new CompiledInstance<Mid>(typeof(Mid0009)) }
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
