using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        /// <summary>
        /// Packs a mid into its byte array representation using <see cref="Mid.DefaultEncoding"/>.
        /// </summary>
        public static byte[] PackBytes(Mid mid) => mid.PackBytes();

        /// <summary>
        /// Packs a mid into its byte array representation using the given <paramref name="encoding"/>.
        /// </summary>
        public static byte[] PackBytes(Mid mid, Encoding encoding) => mid.PackBytes(encoding);

        public Mid Parse(string package)
        {
#if NETSTANDARD2_0
            int mid = int.Parse(package.Substring(4, 4));
#else
            int mid = int.Parse(package.AsSpan(4, 4));
#endif
            var instance = TryParseStandaloneMid(mid);
            if (instance != default)
                return instance;

            var template = GetMessageTemplate(mid);
            return template.ProcessPackage(mid, package);
        }

        public TExtraData ParseExtraData<TExtraData>(Mid0006 mid) where TExtraData : ExtraData, IExtraDataRequest
        {
            var instance = ParseExtraData(mid);
            if (instance is TExtraData extraData)
                return extraData;

            throw new InvalidCastException($"Extra data cannot be casted to {typeof(TExtraData).Name}");
        }

        public TExtraData ParseExtraData<TExtraData>(Mid0008 mid) where TExtraData : ExtraData, IExtraDataSubscription
        {
            var instance = ParseExtraData(mid);
            if (instance is TExtraData extraData)
                return extraData;

            throw new InvalidCastException($"Extra data cannot be casted to {typeof(TExtraData).Name}");
        }

        public TExtraData ParseExtraData<TExtraData>(Mid0009 mid) where TExtraData : ExtraData, IExtraDataUnsubscription
        {
            var expectedExtraData = ParseExtraData(mid);
            if (expectedExtraData is TExtraData extraData)
                return extraData;

            throw new InvalidCastException($"Extra data cannot be casted to {typeof(TExtraData).Name}");
        }

        public TExtraData ParseExtraData<TMid, TExtraData>(TMid mid) where TMid : Mid, IExtraDataContainer
                                                                     where TExtraData : ExtraData
        {
            var expectedExtraData = ParseExtraData(mid);
            if (expectedExtraData is TExtraData extraData)
                return extraData;

            throw new InvalidCastException($"Extra data cannot be casted to {typeof(TExtraData).Name}");
        }

        public ExtraData ParseExtraData<TMid>(TMid mid) where TMid : Mid, IExtraDataContainer
        {
            var expectedMid = GetMidFromExtraDataMid(mid);
            var template = GetMessageTemplate(expectedMid);
            var instance = template.GetExtraDataInstance(expectedMid, GetExtraDataKind(mid));

            var extraDataInstance = instance.CompiledConstructor();
            extraDataInstance.Revision = mid.WantedRevision;
            return extraDataInstance.Parse(mid.ExtraData);
        }

        /// <summary>
        /// Parses a package decoding it with <see cref="Mid.DefaultEncoding"/>.
        /// </summary>
        public Mid Parse(byte[] package)
        {
            int mid = ReadMidNumber(package, Mid.DefaultEncoding);
            var instance = TryParseStandaloneMid(mid);
            if (instance != default)
                return instance;

            var template = GetMessageTemplate(mid);
            return template.ProcessPackage(mid, package);
        }

        /// <summary>
        /// Parses a package decoding it with the given <paramref name="encoding"/>.
        /// </summary>
        public Mid Parse(byte[] package, Encoding encoding)
        {
            int mid = ReadMidNumber(package, encoding);
            var instance = TryParseStandaloneMid(mid);
            if (instance != default)
                return instance;

            var template = GetMessageTemplate(mid);
            return template.ProcessPackage(mid, package, encoding);
        }

        public ExpectedMid Parse<ExpectedMid>(string package) where ExpectedMid : Mid
        {
            Mid mid = Parse(package);
            if (mid is ExpectedMid expectedMid)
                return expectedMid;

            throw new InvalidCastException($"Package is Mid {mid.GetType().Name}, cannot be casted to {typeof(ExpectedMid).Name}");
        }

        public ExpectedMid Parse<ExpectedMid>(byte[] package) where ExpectedMid : Mid
            => Parse<ExpectedMid>(Parse(package));

        public ExpectedMid Parse<ExpectedMid>(byte[] package, Encoding encoding) where ExpectedMid : Mid
            => Parse<ExpectedMid>(Parse(package, encoding));

        private static ExpectedMid Parse<ExpectedMid>(Mid mid) where ExpectedMid : Mid
        {
            if (mid.GetType().Equals(typeof(ExpectedMid)))
                return (ExpectedMid)mid;

            throw new InvalidCastException($"Package is Mid {mid.GetType().Name}, cannot be casted to {typeof(ExpectedMid).Name}");
        }

        private static int ReadMidNumber(byte[] package, Encoding encoding)
        {
#if NETSTANDARD2_0
            return int.Parse(encoding.GetString(package, 4, 4));
#else
            Span<char> buffer = stackalloc char[4];
            var written = encoding.GetChars(package.AsSpan(4, 4), buffer);
            return int.Parse(buffer.Slice(0, written));
#endif
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

        private static int GetMidFromExtraDataMid<TMid>(TMid mid) where TMid : Mid, IExtraDataContainer
        {
            switch (mid)
            {
                case Communication.Mid0006 m: return m.RequestedMid;
                case Communication.Mid0008 m: return m.SubscriptionMid;
                case Communication.Mid0009 m: return m.UnsubscriptionMid;
                default: throw new NotImplementedException($"Could not get the MID from {mid.GetType().Name} as extra data, please implement it");
            }
        }

        private static Type GetExtraDataKind<TMid>(TMid mid) where TMid : Mid, IExtraDataContainer
        {
            switch (mid)
            {
                case Communication.Mid0006 _: return typeof(IExtraDataRequest);
                case Communication.Mid0008 _: return typeof(IExtraDataSubscription);
                case Communication.Mid0009 _: return typeof(IExtraDataUnsubscription);
                default: throw new NotImplementedException($"Could not get the extra data kind from {mid.GetType().Name}, please implement it");
            }
        }
    }
}
