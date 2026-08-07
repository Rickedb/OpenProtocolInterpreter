using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Template for <see cref="ITightening"/> implementers.
    /// </summary>
    internal class TighteningMessages : MessagesTemplate
    {
        public TighteningMessages() : base()
        {
            _templates = new Dictionary<int, CompiledInstance<Mid>>()
            {
                { Mid0060.MID, new CompiledInstance<Mid>(typeof(Mid0060)) },
                { Mid0061.MID, new CompiledInstance<Mid>(typeof(Mid0061)) },
                { Mid0062.MID, new CompiledInstance<Mid>(typeof(Mid0062)) },
                { Mid0063.MID, new CompiledInstance<Mid>(typeof(Mid0063)) },
                { Mid0064.MID, new CompiledInstance<Mid>(typeof(Mid0064)) },
                { Mid0065.MID, new CompiledInstance<Mid>(typeof(Mid0065)) },
                { Mid0066.MID, new CompiledInstance<Mid>(typeof(Mid0066)) },
                { Mid0067.MID, new CompiledInstance<Mid>(typeof(Mid0067)) },
                { Mid0902.MID, new CompiledInstance<Mid>(typeof(Mid0902)) }
            };

            _extraDataTemplates = new Dictionary<int, List<CompiledInstance<ExtraData>>>()
            {
                {
                    Mid0067.MID, new List<CompiledInstance<ExtraData>>()
                    {
                        new CompiledInstance<ExtraData>(typeof(Mid0067ExtraData))
                    }
                }
            };
        }

        public TighteningMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public TighteningMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => (mid > 59 && mid < 68) || (mid > 899 && mid < 903);
    }
}
