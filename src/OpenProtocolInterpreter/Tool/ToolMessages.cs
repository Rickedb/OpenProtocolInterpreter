using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Template for <see cref="ITool"/> implementers.
    /// </summary>
    internal class ToolMessages : MessagesTemplate
    {
        public ToolMessages() : base()
        {
            _templates = new Dictionary<int, CompiledInstance<Mid>>()
            {
                { Mid0040.MID, new CompiledInstance<Mid>(typeof(Mid0040)) },
                { Mid0041.MID, new CompiledInstance<Mid>(typeof(Mid0041)) },
                { Mid0042.MID, new CompiledInstance<Mid>(typeof(Mid0042)) },
                { Mid0043.MID, new CompiledInstance<Mid>(typeof(Mid0043)) },
                { Mid0044.MID, new CompiledInstance<Mid>(typeof(Mid0044)) },
                { Mid0045.MID, new CompiledInstance<Mid>(typeof(Mid0045)) },
                { Mid0046.MID, new CompiledInstance<Mid>(typeof(Mid0046)) },
                { Mid0047.MID, new CompiledInstance<Mid>(typeof(Mid0047)) },
                { Mid0048.MID, new CompiledInstance<Mid>(typeof(Mid0048)) },
                { Mid0701.MID, new CompiledInstance<Mid>(typeof(Mid0701)) },
                { Mid0702.MID, new CompiledInstance<Mid>(typeof(Mid0702)) },
                { Mid0703.MID, new CompiledInstance<Mid>(typeof(Mid0703)) },
                { Mid0704.MID, new CompiledInstance<Mid>(typeof(Mid0704)) }
            };

            _extraDataTemplates = new Dictionary<int, List<CompiledInstance<ExtraData>>>()
            {
                {
                    Mid0702.MID, new List<CompiledInstance<ExtraData>>()
                    {
                        new CompiledInstance<ExtraData>(typeof(Mid0702ExtraData))
                    }
                },
                {
                    Mid0704.MID, new List<CompiledInstance<ExtraData>>()
                    {
                        new CompiledInstance<ExtraData>(typeof(Mid0704ExtraDataRequest)),
                        new CompiledInstance<ExtraData>(typeof(Mid0704ExtraDataSubscription)),
                        new CompiledInstance<ExtraData>(typeof(Mid0704ExtraDataUnsubscription))
                    }
                }
            };
        }

        public ToolMessages(IEnumerable<Type> selectedMids) : this()
        {
            FilterSelectedMids(selectedMids);
        }

        public ToolMessages(InterpreterMode mode) : this()
        {
            FilterSelectedMids(mode);
        }

        public override bool IsAssignableTo(int mid) => (mid > 39 && mid < 49) || (mid > 699 && mid < 705);
    }
}
