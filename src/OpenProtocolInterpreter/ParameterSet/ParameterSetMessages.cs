using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    internal class ParameterSetMessages : MessagesTemplate
    {
        public ParameterSetMessages() : base()
        {
            _templates = new Dictionary<int, Type>()
            {
                { Mid0010.MID, typeof(Mid0010) },
                { Mid0011.MID, typeof(Mid0011) },
                { Mid0012.MID, typeof(Mid0012) },
                { Mid0013.MID, typeof(Mid0013) },
                { Mid0014.MID, typeof(Mid0014) },
                { Mid0015.MID, typeof(Mid0015) },
                { Mid0016.MID, typeof(Mid0016) },
                { Mid0017.MID, typeof(Mid0017) },
                { Mid0018.MID, typeof(Mid0018) },
                { Mid0019.MID, typeof(Mid0019) },
                { Mid0020.MID, typeof(Mid0020) },
                { Mid0021.MID, typeof(Mid0021) },
                { Mid0022.MID, typeof(Mid0022) },
                { Mid0023.MID, typeof(Mid0023) },
                { Mid0024.MID, typeof(Mid0024) },
                { Mid2504.MID, typeof(Mid2504) }
            };
        }

        public ParameterSetMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public ParameterSetMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 9 && mid < 26 || mid > 2499 && mid < 2506;
    }
}
