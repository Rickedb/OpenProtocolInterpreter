using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter
{
    internal class CustomMessages : MessagesTemplate
    {
        public CustomMessages(IDictionary<int, Type> types)
        {
            foreach (var type in types.Where(x => typeof(Mid).IsAssignableFrom(x.Value)))
            {
                _templates.Add(type.Key, new CompiledInstance<Mid>(type.Value));
            }

            foreach (var type in types.Where(x => typeof(ExtraData).IsAssignableFrom(x.Value)))
            {
                AddExtraDataTemplate(type.Key, new CompiledInstance<ExtraData>(type.Value));
            }
        }

        public override bool IsAssignableTo(int mid) => _templates.ContainsKey(mid);
    }
}
