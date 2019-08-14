using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MotorTuning
{
    internal class MotorTuningMessages : MessagesTemplate
    {
        public MotorTuningMessages() : base()
        {
            _templates = new Dictionary<int, Type>()
            {
                { Mid0500.MID, typeof(Mid0500) },
                { Mid0501.MID, typeof(Mid0501) },
                { Mid0502.MID, typeof(Mid0502) },
                { Mid0503.MID, typeof(Mid0503) },
                { Mid0504.MID, typeof(Mid0504) }
            };
        }

        public MotorTuningMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public MotorTuningMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => mid > 499 && mid < 505;
    }
}
