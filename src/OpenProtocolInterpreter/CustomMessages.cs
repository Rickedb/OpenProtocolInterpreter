using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter
{
    internal class CustomMessages : MessagesTemplate
    {
        public CustomMessages(IDictionary<int, Type> midTypes)
        {
            foreach(var type in midTypes)
            {
                _templates.Add(type.Key, new MidCompiledInstance(type.Value));
            }
        }

        public override bool IsAssignableTo(int mid) => _templates.ContainsKey(mid);    
    }
}
