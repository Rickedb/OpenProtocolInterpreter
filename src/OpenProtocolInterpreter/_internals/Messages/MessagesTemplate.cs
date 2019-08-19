using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Messages
{
    internal abstract class MessagesTemplate : IMessagesTemplate
    {
        protected IDictionary<int, MidCompiledInstance> _templates;

        public MessagesTemplate()
        {
            _templates = new Dictionary<int, MidCompiledInstance>();
        }

        public abstract bool IsAssignableTo(int mid);

        public Mid ProcessPackage(int mid, string package)
        {
            var compiledInstance = GetMidType(mid);   
            return compiledInstance.CompiledConstructor().Parse(package);
        }

        public Mid ProcessPackage(int mid, byte[] package)
        {
            var compiledInstance = GetMidType(mid);
            return compiledInstance.CompiledConstructor().Parse(package);
        }

        protected void FilterSelectedMids(InterpreterMode mode)
        {
            if (mode == InterpreterMode.Both)
                return;

            var type = mode == InterpreterMode.Controller ? typeof(IIntegrator) : typeof(IController);
            var selectedMids = _templates.Values.Where(x => x.Type.IsAssignableFrom(type));
            FilterSelectedMids(selectedMids);
        }

        protected void FilterSelectedMids(IEnumerable<Type> mids)
        {
            var ignoredMids = _templates.Values.Where(x => mids.Contains(x.Type));
            FilterSelectedMids(ignoredMids);
        }

        private void FilterSelectedMids(IEnumerable<MidCompiledInstance> mids)
        {
            var ignoredMids = _templates.Where(x => !mids.Contains(x.Value)).ToList();
            foreach (var ignore in ignoredMids)
                _templates.Remove(ignore);
        }

        private MidCompiledInstance GetMidType(int mid)
        {
            if (!_templates.TryGetValue(mid, out MidCompiledInstance instanceCompiler))
            {
                throw new NotImplementedException($"MID {mid} was not implemented, please register it!");
            }

            return instanceCompiler;
        }
    }
}
