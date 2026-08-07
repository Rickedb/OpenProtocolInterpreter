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

        /// <summary>
        /// Creates an interpreter with no message template registered.
        /// <para>
        ///     Templates must be registered before parsing any package
        /// </para>
        /// </summary>
        public MidInterpreter()
        {
            _messagesTemplates = new Dictionary<Type, Lazy<IMessagesTemplate>>();
            _midTemplates = new SortedDictionary<int, IMessagesTemplate>();
        }

        /// <summary>
        /// Packs a mid into its string representation.
        /// </summary>
        /// <param name="mid">The mid to pack.</param>
        /// <returns>The string representation of the mid.</returns>
        public static string Pack(Mid mid) => mid.Pack();

        /// <summary>
        /// Packs a mid into its byte array representation using <see cref="Mid.DefaultEncoding"/>.
        /// </summary>
        /// <param name="mid">The mid to pack.</param>
        /// <returns>The byte array representation of the mid.</returns>
        public static byte[] PackBytes(Mid mid) => mid.PackBytes();

        /// <summary>
        /// Packs a mid into its byte array representation using the given <paramref name="encoding"/>.
        /// </summary>
        /// <param name="mid">The mid to pack.</param>
        /// <param name="encoding">Encoding used to convert the packed mid into bytes.</param>
        /// <returns>The byte array representation of the mid.</returns>
        public static byte[] PackBytes(Mid mid, Encoding encoding) => mid.PackBytes(encoding);

        /// <summary>
        /// Parses a package into its corresponding <see cref="Mid"/> instance.
        /// </summary>
        /// <param name="package">The package to parse.</param>
        /// <returns>The parsed mid instance.</returns>
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

        /// <summary>
        /// Parses the extra data of a <see cref="Mid0006"/> request into the expected <typeparamref name="TExtraData"/>.
        /// </summary>
        /// <typeparam name="TExtraData">The expected extra data type of the requested mid.</typeparam>
        /// <param name="mid">The mid containing the extra data to parse.</param>
        /// <returns>The parsed extra data.</returns>
        /// <exception cref="InvalidCastException">Thrown when the parsed extra data is not a <typeparamref name="TExtraData"/>.</exception>
        /// <exception cref="NotImplementedException">Thrown when no registered message template handles the requested mid.</exception>
        public TExtraData ParseExtraData<TExtraData>(Mid0006 mid) where TExtraData : ExtraData, IExtraDataRequest
        {
            var instance = ParseExtraData(mid);
            if (instance is TExtraData extraData)
                return extraData;

            throw new InvalidCastException($"Extra data cannot be casted to {typeof(TExtraData).Name}");
        }

        /// <summary>
        /// Parses the extra data of a <see cref="Mid0008"/> subscription into the expected <typeparamref name="TExtraData"/>.
        /// </summary>
        /// <typeparam name="TExtraData">The expected extra data type of the subscribed mid.</typeparam>
        /// <param name="mid">The mid containing the extra data to parse.</param>
        /// <returns>The parsed extra data.</returns>
        /// <exception cref="InvalidCastException">Thrown when the parsed extra data is not a <typeparamref name="TExtraData"/>.</exception>
        /// <exception cref="NotImplementedException">Thrown when no registered message template handles the subscribed mid.</exception>
        public TExtraData ParseExtraData<TExtraData>(Mid0008 mid) where TExtraData : ExtraData, IExtraDataSubscription
        {
            var instance = ParseExtraData(mid);
            if (instance is TExtraData extraData)
                return extraData;

            throw new InvalidCastException($"Extra data cannot be casted to {typeof(TExtraData).Name}");
        }

        /// <summary>
        /// Parses the extra data of a <see cref="Mid0009"/> unsubscription into the expected <typeparamref name="TExtraData"/>.
        /// </summary>
        /// <typeparam name="TExtraData">The expected extra data type of the unsubscribed mid.</typeparam>
        /// <param name="mid">The mid containing the extra data to parse.</param>
        /// <returns>The parsed extra data.</returns>
        /// <exception cref="InvalidCastException">Thrown when the parsed extra data is not a <typeparamref name="TExtraData"/>.</exception>
        /// <exception cref="NotImplementedException">Thrown when no registered message template handles the unsubscribed mid.</exception>
        public TExtraData ParseExtraData<TExtraData>(Mid0009 mid) where TExtraData : ExtraData, IExtraDataUnsubscription
        {
            var expectedExtraData = ParseExtraData(mid);
            if (expectedExtraData is TExtraData extraData)
                return extraData;

            throw new InvalidCastException($"Extra data cannot be casted to {typeof(TExtraData).Name}");
        }

        /// <summary>
        /// Parses the extra data of any extra data container mid into the expected <typeparamref name="TExtraData"/>.
        /// </summary>
        /// <typeparam name="TMid">The type of the mid carrying the extra data.</typeparam>
        /// <typeparam name="TExtraData">The expected extra data type of the contained mid.</typeparam>
        /// <param name="mid">The mid containing the extra data to parse.</param>
        /// <returns>The parsed extra data.</returns>
        /// <exception cref="InvalidCastException">Thrown when the parsed extra data is not a <typeparamref name="TExtraData"/>.</exception>
        /// <exception cref="NotImplementedException">Thrown when <typeparamref name="TMid"/> is not a supported extra data container, or when no registered message template handles the contained mid.</exception>
        public TExtraData ParseExtraData<TMid, TExtraData>(TMid mid) where TMid : Mid, IExtraDataContainer
                                                                     where TExtraData : ExtraData
        {
            var expectedExtraData = ParseExtraData(mid);
            if (expectedExtraData is TExtraData extraData)
                return extraData;

            throw new InvalidCastException($"Extra data cannot be casted to {typeof(TExtraData).Name}");
        }

        /// <summary>
        /// Parses the extra data of any extra data container mid, such as <see cref="Mid0006"/>, <see cref="Mid0008"/> and <see cref="Mid0009"/>.
        /// <para> The extra data instance is resolved from the mid it refers to and parsed with the revision wanted by <paramref name="mid"/>. </para>
        /// </summary>
        /// <typeparam name="TMid">The type of the mid carrying the extra data.</typeparam>
        /// <param name="mid">The mid containing the extra data to parse.</param>
        /// <returns>The parsed extra data.</returns>
        /// <exception cref="NotImplementedException">Thrown when <typeparamref name="TMid"/> is not a supported extra data container, or when no registered message template handles the contained mid.</exception>
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
        /// <param name="package">The package to parse.</param>
        /// <returns>The parsed mid instance.</returns>
        /// <exception cref="NotImplementedException">Thrown when no registered message template handles the package's mid.</exception>
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
        /// <param name="package">The package to parse.</param>
        /// <param name="encoding">Encoding used to decode the package.</param>
        /// <returns>The parsed mid instance.</returns>
        /// <exception cref="NotImplementedException">Thrown when no registered message template handles the package's mid.</exception>
        public Mid Parse(byte[] package, Encoding encoding)
        {
            int mid = ReadMidNumber(package, encoding);
            var instance = TryParseStandaloneMid(mid);
            if (instance != default)
                return instance;

            var template = GetMessageTemplate(mid);
            return template.ProcessPackage(mid, package, encoding);
        }

        /// <summary>
        /// Parses a package and returns it as the expected mid type.
        /// </summary>
        /// <typeparam name="ExpectedMid">The mid type the package is expected to be.</typeparam>
        /// <param name="package">The package to parse.</param>
        /// <returns>The parsed mid instance.</returns>
        /// <exception cref="InvalidCastException">Thrown when the package is not an <typeparamref name="ExpectedMid"/>.</exception>
        /// <exception cref="NotImplementedException">Thrown when no registered message template handles the package's mid.</exception>
        public ExpectedMid Parse<ExpectedMid>(string package) where ExpectedMid : Mid
        {
            Mid mid = Parse(package);
            if (mid is ExpectedMid expectedMid)
                return expectedMid;

            throw new InvalidCastException($"Package is Mid {mid.GetType().Name}, cannot be casted to {typeof(ExpectedMid).Name}");
        }

        /// <summary>
        /// Parses a package decoding it with <see cref="Mid.DefaultEncoding"/> and returns it as the expected mid type.
        /// </summary>
        /// <typeparam name="ExpectedMid">The mid type the package is expected to be.</typeparam>
        /// <param name="package">The package to parse.</param>
        /// <returns>The parsed mid instance.</returns>
        /// <exception cref="InvalidCastException">Thrown when the package is not an <typeparamref name="ExpectedMid"/>.</exception>
        /// <exception cref="NotImplementedException">Thrown when no registered message template handles the package's mid.</exception>
        public ExpectedMid Parse<ExpectedMid>(byte[] package) where ExpectedMid : Mid
            => Parse<ExpectedMid>(Parse(package));

        /// <summary>
        /// Parses a package decoding it with the given <paramref name="encoding"/> and returns it as the expected mid type.
        /// </summary>
        /// <typeparam name="ExpectedMid">The mid type the package is expected to be.</typeparam>
        /// <param name="package">The package to parse.</param>
        /// <param name="encoding">Encoding used to decode the package.</param>
        /// <returns>The parsed mid instance.</returns>
        /// <exception cref="InvalidCastException">Thrown when the package is not an <typeparamref name="ExpectedMid"/>.</exception>
        /// <exception cref="NotImplementedException">Thrown when no registered message template handles the package's mid.</exception>
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
