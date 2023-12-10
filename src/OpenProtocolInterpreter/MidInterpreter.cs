using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Responsible for building and parsing any incoming Mid. 
    /// Message templates initialization must be done with <see cref="MidInterpreterMessagesExtensions"/> methods.
    /// </summary>
    public class MidInterpreter
    {
        private readonly Dictionary<Type, Lazy<IMessagesTemplate>> _messagesTemplates;
        private readonly SortedDictionary<int, IMessagesTemplate> _midTemplates;

        public MidInterpreter()
        {
            _messagesTemplates = new Dictionary<Type, Lazy<IMessagesTemplate>>();
            _midTemplates = new SortedDictionary<int, IMessagesTemplate>();
        }

        public static string Pack(Mid mid) => mid.Pack();

        public static byte[] PackBytes(Mid mid) => mid.PackBytes();

        public Mid Parse(string package)
        {
            int mid = int.Parse(package.Substring(4, 4));
            var instance = TryParseStandaloneMid(mid);
            if (instance != default)
                return instance;

            var template = GetMessageTemplate(mid);
            return template.ProcessPackage(mid, package);
        }

        public Mid Parse(byte[] package)
        {
            int mid = int.Parse(Encoding.ASCII.GetString(package, 4, 4));
            var instance = TryParseStandaloneMid(mid);
            if (instance != default)
                return instance;

            var template = GetMessageTemplate(mid);
            return template.ProcessPackage(mid, package);
        }

        public ExpectedMid Parse<ExpectedMid>(string package) where ExpectedMid : Mid
        {
            Mid mid = Parse(package);
            if (mid.GetType().Equals(typeof(ExpectedMid)))
                return (ExpectedMid)mid;

            throw new InvalidCastException($"Package is Mid {mid.GetType().Name}, cannot be casted to {typeof(ExpectedMid).Name}");
        }

        public ExpectedMid Parse<ExpectedMid>(byte[] package) where ExpectedMid : Mid
        {
            Mid mid = Parse(package);
            if (mid.GetType().Equals(typeof(ExpectedMid)))
                return (ExpectedMid)mid;

            throw new InvalidCastException($"Package is Mid {mid.GetType().Name}, cannot be casted to {typeof(ExpectedMid).Name}");
        }

        internal void UseTemplate(IMessagesTemplate template)
        {
            var type = template.GetType();
            if (!_messagesTemplates.ContainsKey(type))
            {
                _messagesTemplates.Add(type, new Lazy<IMessagesTemplate>(() => template));
            }
        }

        internal void UseTemplate(Type type, Lazy<IMessagesTemplate> template)
        {
            if (!_messagesTemplates.ContainsKey(type))
            {
                _messagesTemplates.Add(type, template);
            }
        }

        internal void UseTemplate<T>() where T : IMessagesTemplate
        {
            UseTemplate<T>(InterpreterMode.Both);
        }

        internal void UseTemplate<T>(InterpreterMode mode) where T : IMessagesTemplate
        {
            var type = typeof(T);
            var instance = new Lazy<IMessagesTemplate>(() => (IMessagesTemplate)Activator.CreateInstance(type, [mode]));
            UseTemplate(type, instance);
        }

        internal void UseTemplate<T>(IEnumerable<Type> types) where T : IMessagesTemplate
        {
            if (types.Any())
            {
                var type = typeof(T);
                var instance = new Lazy<IMessagesTemplate>(() => (IMessagesTemplate)Activator.CreateInstance(type, [types]));
                UseTemplate(type, instance);
            }
        }

        internal void UseTemplate<T>(IDictionary<int, Type> types) where T : IMessagesTemplate
        {
            if (types.Any())
            {
                var type = typeof(T);
                if (!_messagesTemplates.TryGetValue(type, out var instance))
                {
                    instance = new Lazy<IMessagesTemplate>(() => (IMessagesTemplate)Activator.CreateInstance(type, []));
                    UseTemplate(type, instance);
                }

                instance.Value.AddOrUpdateTemplate(types);
            }
        }

        private IMessagesTemplate GetMessageTemplate(int mid)
        {
            if (!_midTemplates.TryGetValue(mid, out IMessagesTemplate template))
            {
                var lazy = _messagesTemplates.Values.FirstOrDefault(x => x.Value.IsAssignableTo(mid));
                if (lazy == null)
                {
                    throw new NotImplementedException($@"Could not found a message parser for mid {mid}, please register it before using");
                }

                template = lazy.Value;
                _midTemplates.Add(mid, template);
            }

            return template;
        }

        private static Mid TryParseStandaloneMid(int mid)
        {
            return mid switch
            {
                KeepAlive.Mid9999.MID => new KeepAlive.Mid9999(),
                ApplicationController.Mid0270.MID => new ApplicationController.Mid0270(),
                _ => default,
            };
        }
    }
}
