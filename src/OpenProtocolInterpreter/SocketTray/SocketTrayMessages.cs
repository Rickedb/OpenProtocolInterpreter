using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.SocketTray
{
    /// <summary>
    /// Template for <see cref="ISocketTray"/> implementers.
    /// </summary>
    internal class SocketTrayMessages : MessagesTemplate
    {
        public SocketTrayMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
                { Mid0520.MID, new MidCompiledInstance(typeof(Mid0520)) },
                { Mid0522.MID, new MidCompiledInstance(typeof(Mid0522)) },
                { Mid0523.MID, new MidCompiledInstance(typeof(Mid0523)) },
                { Mid0524.MID, new MidCompiledInstance(typeof(Mid0524)) }
            };
        }

        public SocketTrayMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public SocketTrayMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 519 && mid < 525;
    }
}
