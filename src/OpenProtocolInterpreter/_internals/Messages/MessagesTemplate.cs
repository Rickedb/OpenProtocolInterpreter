using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Messages
{
    internal abstract class MessagesTemplate : IMessagesTemplate
    {
        protected IDictionary<int, Type> _templates;

        public MessagesTemplate()
        {
            _templates = new Dictionary<int, Type>();
        }

        public abstract bool IsAssignableTo(int mid);

        public Mid ProcessPackage(int mid, string package)
        {
            var type = GetMidType(mid);   
            return GetInstance(type).Parse(package);
        }

        public Mid ProcessPackage(int mid, byte[] package)
        {
            var type = GetMidType(mid);
            return GetInstance(type).Parse(package);
        }

        protected void FilterSelectedMids(InterpreterMode mode)
        {
            if (mode == InterpreterMode.Both)
                return;

            var type = mode == InterpreterMode.Controller ? typeof(IIntegrator) : typeof(IController);
            var selectedMids = _templates.Values.Where(x => x.IsAssignableFrom(type));
            FilterSelectedMids(selectedMids);
        }

        protected void FilterSelectedMids(IEnumerable<Type> mids)
        {
            var ignoredMids = _templates.Values.Where(x=> !mids.Contains(x));
            _templates = _templates.Except(ignoredMids);
        }

        private IMid GetInstance(Type type) => (IMid)Activator.CreateInstance(type);

        private Type GetMidType(int mid)
        {
            if (!_templates.TryGetValue(mid, out Type type))
            {
                throw new NotImplementedException($"MID {mid} was not implemented, please register it!");
            }

            return type;
        }
    }
}
