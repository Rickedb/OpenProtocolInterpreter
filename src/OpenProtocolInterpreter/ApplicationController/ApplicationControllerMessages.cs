using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ApplicationController
{
    internal class ApplicationControllerMessages : MessagesTemplate
    {
        public ApplicationControllerMessages() : base()
        {
            _templates = new Dictionary<int, Type>()
            {
                { Mid0270.MID, typeof(Mid0270) }
            };
        }

        public ApplicationControllerMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public ApplicationControllerMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid == 270;
    }
}
