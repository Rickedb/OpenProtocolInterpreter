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
        protected IDictionary<int, CompiledInstance<Mid>> _templates;
        protected IDictionary<int, List<CompiledInstance<ExtraData>>> _extraDataTemplates;

        /// <summary>
        /// Initializes a new instance of <see cref="MessagesTemplate"/> class.
        /// </summary>
        public MessagesTemplate()
        {
            _templates = new Dictionary<int, CompiledInstance<Mid>>();
            _extraDataTemplates = new Dictionary<int, List<CompiledInstance<ExtraData>>>();
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
            var compiledInstance = GetInstance(mid);
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
            var compiledInstance = GetInstance(mid);
            return compiledInstance.CompiledConstructor().Parse(package);
        }

        /// <summary>
        /// Get <see cref="CompiledInstance"/> from the dictionary based on mid number
        /// </summary>
        /// <param name="mid">Mid number</param>
        /// <returns>Compiled instance</returns>
        public CompiledInstance<Mid> GetInstance(int mid)
        {
            if (!_templates.TryGetValue(mid, out CompiledInstance<Mid> compiledInstance))
            {
                throw new NotImplementedException($"MID {mid} was not implemented, please register it!");
            }

            return compiledInstance;
        }

        /// <summary>
        /// Get the <see cref="CompiledInstance{T}"/> of the <see cref="ExtraData"/> registered for a mid number.
        /// <para>
        ///     A mid may have one <see cref="ExtraData"/> per kind, since request (<see cref="Communication.Mid0006"/>),
        ///     subscription (<see cref="Communication.Mid0008"/>) and unsubscription (<see cref="Communication.Mid0009"/>)
        ///     may not share the same content.
        /// </para>
        /// </summary>
        /// <param name="mid">Mid number</param>
        /// <param name="kind"><see cref="IExtraDataRequest"/>, <see cref="IExtraDataSubscription"/> or <see cref="IExtraDataUnsubscription"/></param>
        /// <returns>Compiled instance</returns>
        public CompiledInstance<ExtraData> GetExtraDataInstance(int mid, Type kind)
        {
            if (!_extraDataTemplates.TryGetValue(mid, out List<CompiledInstance<ExtraData>> compiledInstances))
            {
                throw new NotImplementedException($"MID {mid} has no extra data implemented, please register it!");
            }

            var compiledInstance = compiledInstances.FirstOrDefault(x => kind.IsAssignableFrom(x.Type));
            if (compiledInstance == null)
            {
                throw new NotImplementedException($"MID {mid} has no extra data implemented for {kind.Name}, please register it!");
            }

            return compiledInstance;
        }

        /// <summary>
        /// Register an <see cref="ExtraData"/> implementer for a mid number.
        /// <para>The same mid may register one <see cref="ExtraData"/> per kind (request, subscription and unsubscription).</para>
        /// </summary>
        /// <param name="mid">Mid number</param>
        /// <param name="compiledInstance">Compiled instance of the <see cref="ExtraData"/> implementer</param>
        protected void AddExtraDataTemplate(int mid, CompiledInstance<ExtraData> compiledInstance)
        {
            if (!_extraDataTemplates.TryGetValue(mid, out List<CompiledInstance<ExtraData>> compiledInstances))
            {
                _extraDataTemplates.Add(mid, compiledInstances = new List<CompiledInstance<ExtraData>>());
            }

            compiledInstances.Add(compiledInstance);
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

                _templates.Add(type.Key, new CompiledInstance<Mid>(type.Value));
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
        /// Remove unused/ignored <see cref="CompiledInstance"/> from dictionary.
        /// </summary>
        /// <param name="mids">Ignored mid instances</param>
        private void FilterSelectedMids(IEnumerable<CompiledInstance<Mid>> mids)
        {
            var ignoredMids = _templates.Where(x => !mids.Contains(x.Value)).ToList();
            foreach (var ignore in ignoredMids)
                _templates.Remove(ignore);
        }
    }
}
