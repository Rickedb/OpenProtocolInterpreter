using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Wifi
{
    /// <summary>
    /// Template for <see cref="IWifi"/> implementers.
    /// </summary>
    internal class WifiMessages : MessagesTemplate
    {
        public WifiMessages() : base()
        {
            _templates = new Dictionary<int, MidCompiledInstance>()
            {
                { Mid0805.MID, new MidCompiledInstance(typeof(Mid0805)) },
                { Mid0806.MID, new MidCompiledInstance(typeof(Mid0806)) },
                { Mid0807.MID, new MidCompiledInstance(typeof(Mid0807)) },
                { Mid0808.MID, new MidCompiledInstance(typeof(Mid0808)) },
                { Mid0809.MID, new MidCompiledInstance(typeof(Mid0809)) }
            };
        }

        public WifiMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public WifiMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 804 && mid < 810;
    }
}
