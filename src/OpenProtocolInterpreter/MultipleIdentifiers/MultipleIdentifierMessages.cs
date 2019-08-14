using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    internal class MultipleIdentifierMessages : MessagesTemplate
    {
        public MultipleIdentifierMessages() : base()
        {
            _templates = new Dictionary<int, Type>()
            {
                { Mid0150.MID, typeof(Mid0150) },
                { Mid0151.MID, typeof(Mid0151) },
                { Mid0152.MID, typeof(Mid0152) },
                { Mid0153.MID, typeof(Mid0153) },
                { Mid0154.MID, typeof(Mid0154) },
                { Mid0155.MID, typeof(Mid0155) },
                { Mid0156.MID, typeof(Mid0156) },
                { Mid0157.MID, typeof(Mid0157) }
            };
        }

        public MultipleIdentifierMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public MultipleIdentifierMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 149 && mid < 158;
    }
}
