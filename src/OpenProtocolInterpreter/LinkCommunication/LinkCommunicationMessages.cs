using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.LinkCommunication
{
    internal class LinkCommunicationMessages : MessagesTemplate
    {
        public LinkCommunicationMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
                { Mid9997.MID, new MidCompiledInstance(typeof(Mid9997)) },
                { Mid9998.MID, new MidCompiledInstance(typeof(Mid9998)) }
            };
        }

        public LinkCommunicationMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public LinkCommunicationMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 9996 && mid < 9999;
    }
}
