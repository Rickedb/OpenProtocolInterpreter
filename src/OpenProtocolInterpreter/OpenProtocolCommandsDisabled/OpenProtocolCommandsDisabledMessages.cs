using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    internal class OpenProtocolCommandsDisabledMessages : MessagesTemplate
    {
        public OpenProtocolCommandsDisabledMessages() : base()
        {
            _templates = new Dictionary<int, Type>()
            {
                { Mid0420.MID, typeof(Mid0420) },
                { Mid0421.MID, typeof(Mid0421) },
                { Mid0422.MID, typeof(Mid0422) },
                { Mid0423.MID, typeof(Mid0423) }
            };
        }

        public OpenProtocolCommandsDisabledMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public OpenProtocolCommandsDisabledMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 419 && mid < 424;
    }
}
