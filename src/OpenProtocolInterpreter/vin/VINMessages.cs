using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Vin
{
    internal class VinMessages : MessagesTemplate
    {
        public VinMessages() : base()
        {
            _templates = new Dictionary<int, Type>()
            {
                { Mid0050.MID, typeof(Mid0050) },
                { Mid0051.MID, typeof(Mid0051) },
                { Mid0052.MID, typeof(Mid0052) },
                { Mid0053.MID, typeof(Mid0053) },
                { Mid0054.MID, typeof(Mid0054) }
            };
        }

        public VinMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public VinMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 49 && mid < 55;
    }
}
