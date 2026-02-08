using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Messages
{
    /// <summary>
    /// Base class for all <see cref="IMessagesTemplate"/> templates implementers
    /// </summary>
    internal abstract class MessagesTemplate : IMessagesTemplate
    {
        protected IDictionary<int, MidCompiledInstance> _templates;

        /// <summary>
        /// Initializes a new instance of <see cref="MessagesTemplate"/> class.
        /// </summary>
        public MessagesTemplate()
        {
            _templates = new Dictionary<int, MidCompiledInstance>();
        }

        /// <summary>
        /// Check if mid number is assignable to this message template or not.
        /// </summary>
        /// <param name="mid">Mid number</param>
        /// <returns>Is assignable or not</returns>
        public abstract bool IsAssignableTo(int mid);

        /// <summary>
        /// Find out which Mid instance it should instantiate and parse all it's content.
        /// </summary>
        /// <param name="mid">Mid number.</param>
        /// <param name="package">Package in ASCII string.</param>
        /// <returns><see cref="Mid"/> instance.</returns>
        public Mid ProcessPackage(int mid, string package)
        {
            var compiledInstance = GetMidType(mid);   
            return compiledInstance.CompiledConstructor().Parse(package);
        }

        /// <summary>
        /// Find out which Mid instance it should instantiate and parse all it's content
        /// </summary>
        /// <param name="mid">Mid number</param>
        /// <param name="package">package in bytes</param>
        /// <returns><see cref="Mid"/> instance</returns>
        public Mid ProcessPackage(int mid, byte[] package)
        {
            var compiledInstance = GetMidType(mid);
            return compiledInstance.CompiledConstructor().Parse(package);
        }

        /// <summary>
        /// Update Mid instance it should instantiate
        /// </summary>
        /// <param name="types">Mid x Type key/value</param>
        public void AddOrUpdateTemplate(IDictionary<int, Type> types)
        {
            foreach (var type in types)
            {
                if (_templates.ContainsKey(type.Key))
                {
                    _templates.Remove(type.Key);
                }

                _templates.Add(type.Key, new MidCompiledInstance(type.Value));
            }
        }

        /// <summary>
        /// Filter dictionary to use only Mids from it's mode.
        /// </summary>
        /// <param name="mode">Current mode if <see cref="InterpreterMode.Controller"/>, <see cref="InterpreterMode.Integrator"/> or <see cref="InterpreterMode.Both"/>.</param>
        protected void FilterSelectedMids(InterpreterMode mode)
        {
            if (mode == InterpreterMode.Both)
                return;

            var type = mode == InterpreterMode.Controller ? typeof(IIntegrator) : typeof(IController);
            var selectedMids = _templates.Values.Where(x => type.IsAssignableFrom(x.Type));
            FilterSelectedMids(selectedMids);
        }

        /// <summary>
        /// Filter dictionary to use only selected Mids.
        /// </summary>
        /// <param name="mids">Selected <see cref="Mid"/> types.</param>
        protected void FilterSelectedMids(IEnumerable<Type> mids)
        {
            var ignoredMids = _templates.Values.Where(x => mids.Contains(x.Type));
            FilterSelectedMids(ignoredMids);
        }

        /// <summary>
        /// Remove unused/ignored <see cref="MidCompiledInstance"/> from dictionary.
        /// </summary>
        /// <param name="mids">Ignored mid instances</param>
        private void FilterSelectedMids(IEnumerable<MidCompiledInstance> mids)
        {
            var ignoredMids = _templates.Where(x => !mids.Contains(x.Value)).ToList();
            foreach (var ignore in ignoredMids)
                _templates.Remove(ignore);
        }

        /// <summary>
        /// Get <see cref="MidCompiledInstance"/> from the dictionary based on mid number
        /// </summary>
        /// <param name="mid">Mid number</param>
        /// <returns>Compiled instance</returns>
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
