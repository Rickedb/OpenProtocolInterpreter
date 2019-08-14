using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.UserInterface
{
    internal class UserInterfaceMessages : MessagesTemplate
    {
        public UserInterfaceMessages() : base()
        {
            _templates = new Dictionary<int, Type>()
            {
                { Mid0110.MID, typeof(Mid0110) },
                { Mid0111.MID, typeof(Mid0111) },
                { Mid0113.MID, typeof(Mid0113) }
            };
        }

        public UserInterfaceMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public UserInterfaceMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 109 && mid < 114;
    }
}
