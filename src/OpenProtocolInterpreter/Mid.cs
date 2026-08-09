using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Abstract class which every Mid should inherit, containing all of default data, such as <see cref="Header"/> data and methods.
    /// </summary>
    public abstract class Mid
    {
        private static readonly ConcurrentDictionary<Type, DataFieldMetadata[]> _metadataCache = new();
        private static Encoding _defaultEncoding = Encoding.ASCII;

        private readonly Lazy<Dictionary<int, List<DataField>>> _lazyFields;
        protected const int DEFAULT_REVISION = 1;
        protected internal Dictionary<int, List<DataField>> RevisionsByFields => _lazyFields.Value;

        /// <summary>
        /// Encoding used whenever a package is converted from/to its byte array representation.
        /// <para> Defaults to <see cref="Encoding.ASCII"/>, as stated by the Open Protocol specification. </para>
        /// <para>
        ///     Setting it affects every MID, so it is meant to be set once during
        ///     startup, before any package is packed or parsed. Field positions of the specification are
        ///     counted in single byte characters, therefore ASCII compatible single byte encodings
        ///     (such as Latin1) are the ones able to preserve them.
        /// </para>
        /// </summary>
        public static Encoding DefaultEncoding
        {
            get => _defaultEncoding;
            set => _defaultEncoding = value ?? Encoding.ASCII;
        }

        /// <summary>
        /// Header of the MID message containing standardized fields.
        /// </summary>
        public Header Header { get; set; }

        public Mid(Header header)
        {
            Header = header;
            _lazyFields = new Lazy<Dictionary<int, List<DataField>>>(() => new SafeAccessRevisionsFields(RegisterDatafields()));
        }

        public Mid(int mid, int revision, bool noAckFlag = false) : this(new Header()
        {
            Mid = mid,
            Revision = revision,
            NoAckFlag = noAckFlag
        })
        {

        }

        protected virtual byte[] BuildRawHeader() => ToBytes(BuildHeader());

        protected virtual string BuildHeader()
        {
            if (RevisionsByFields.Any())
            {
                Header.Length = Header.DefaultSize;
                for (int i = 1; i <= Header.StandardizedRevision; i++)
                {
                    if (RevisionsByFields.TryGetValue(i, out var dataFields))
                    {
                        foreach (var dataField in dataFields)
                            Header.Length += dataField.TotalSize;
                    }
                }
            }
            return Header.ToString();
        }

        /// <summary>
        /// Packs the MID message into a string representation, including the header and all data fields for the current revision.
        /// <para> If the MID has no data fields, only the header will be packed. </para>
        /// </summary>
        /// <returns>The string representing the packed MID message.</returns>
        public virtual string Pack()
        {
            var header = BuildHeader();
            if (!RevisionsByFields.Any())
                return header;

            var builder = new StringBuilder(header);
            var revision = Header.StandardizedRevision;
            for (int rev = 1; rev <= revision; rev++)
            {
                builder.Append(Pack(rev));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Packs the MID message into a byte array representation, including the header and all data fields for the current revision.
        /// <para> If the MID has no data fields, only the header will be packed. </para>
        /// <para> The byte array is encoded with <see cref="DefaultEncoding"/>. </para>
        /// </summary>
        /// <returns>The byte array representing the packed MID message.</returns>
        public virtual byte[] PackBytes() => PackBytes(DefaultEncoding);

        /// <summary>
        /// Packs the MID message into a byte array representation, including the header and all data fields for the current revision.
        /// <para> If the MID has no data fields, only the header will be packed. </para>
        /// </summary>
        /// <param name="encoding">Encoding used to convert the packed message into bytes.</param>
        /// <returns>The byte array representing the packed MID message in the given encoding.</returns>
        public virtual byte[] PackBytes(Encoding encoding) => ToBytes(Pack(), encoding);

        protected virtual string Pack(int revision)
        {
            if (!RevisionsByFields.TryGetValue(revision, out var dataFields))
            {
                return string.Empty;
            }

            return Pack(dataFields);
        }

        protected internal virtual string Pack(IEnumerable<DataField> dataFields)
        {
            var builder = new StringBuilder();
            foreach (var dataField in dataFields)
            {
                if (dataField is IBackedPropertyDataField backedPropertyDataField)
                    backedPropertyDataField.SyncWithBackingPropertyIfBound();

                if (dataField.HasPrefix)
                {
                    builder.Append(dataField.Field.ToString("D2"));
                }

                builder.Append(dataField.Value);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Registers the data fields for the MID, ordered by their revision and field id. This method is called lazily when parsing or packing a MID to ensure revision defined at header.
        /// <para> Each data field should be decorated with a <see cref="DataFieldDefinitionAttribute"/> to define its specifications. </para>
        /// <para> The field id in the attribute is used to order the fields in the same revision.</para>
        /// <para> Mids with custom fields due to different revisions fields should override this method to handle them appropriately.</para>
        /// </summary>
        /// <returns>A dictionary where the key is the revision number and the value is a list of data fields for that revision.</returns>
        protected virtual Dictionary<int, List<DataField>> RegisterDatafields()
        {
            var metadata = _metadataCache.GetOrAdd(GetType(), static type =>
            {
                var result = new List<DataFieldMetadata>();
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                     .Where(x => x.CustomAttributes.Any(a => typeof(DataFieldDefinitionAttribute).IsAssignableFrom(a.AttributeType)));

                foreach (var prop in properties)
                {
                    var attributes = prop.GetCustomAttributes<DataFieldDefinitionAttribute>();
                    if (!attributes.Any())
                        continue;

                    foreach (var attr in attributes)
                    {
                        result.Add(new DataFieldMetadata(attr.Index, attr, prop));
                    }
                }
                return result.ToArray();
            });

            var fields = new Dictionary<int, List<DataField>>();
            foreach (var m in metadata)
            {
                if (!fields.TryGetValue(m.Attribute.Revision, out var revisionFields))
                    fields.Add(m.Attribute.Revision, revisionFields = new List<DataField>());
                revisionFields.Add(m.CreateAndBind(this));
            }
            return fields;
        }

        /// <summary>
        /// Processes the header of the MID message and fills the <see cref="Header"/> property. This method is called before processing the data fields.
        /// </summary>
        /// <param name="package">The MID message as a string.</param>
        /// <returns>The parsed <see cref="Header"/> object.</returns>
        protected virtual Header ProcessHeader(string package)
            => ProcessHeader(package.AsSpan());

        /// <summary>
        /// Processes the header of the MID message and fills the <see cref="Header"/> property. This method is called before processing the data fields.
        /// </summary>
        /// <param name="package">The MID message as a read-only span of characters.</param>
        /// <returns>The parsed <see cref="Header"/> object.</returns>
        protected virtual Header ProcessHeader(ReadOnlySpan<char> package)
        {
            if (package.Length < 20)
            {
                Span<char> buffer = stackalloc char[20];
                package.CopyTo(buffer);
                buffer.Slice(package.Length).Fill(' ');
                return Header.Parse(buffer);
            }

            return Header.Parse(package);
        }

        /// <summary>
        /// Parses the MID message from a string representation, filling the <see cref="Header"/> and data fields for the current revision.
        /// </summary>
        /// <param name="package">The MID message as a string.</param>
        /// <returns>The parsed <see cref="Mid"/> object.</returns>
        public virtual Mid Parse(string package)
            => Parse(package.AsSpan());

        /// <summary>
        /// Parses the MID message from a read-only span of characters, filling the <see cref="Header"/> and data fields for the current revision.
        /// </summary>
        /// <param name="package">The MID message as a read-only span of characters.</param>
        /// <returns>The parsed <see cref="Mid"/> object.</returns>
        public virtual Mid Parse(ReadOnlySpan<char> package)
        {
            Header = ProcessHeader(package);
            ProcessDataFields(package);
            return this;
        }

        /// <summary>
        /// Parses the MID message from a byte array representation, filling the <see cref="Header"/> and data fields for the current revision.
        /// <para> The byte array is decoded with <see cref="DefaultEncoding"/>. </para>
        /// </summary>
        /// <param name="package">The MID message as a byte array.</param>
        /// <returns>The parsed <see cref="Mid"/> object.</returns>
        public virtual Mid Parse(byte[] package) => Parse(package, DefaultEncoding);

        /// <summary>
        /// Parses the MID message from a byte array representation, filling the <see cref="Header"/> and data fields for the current revision.
        /// </summary>
        /// <param name="package">The MID message as a byte array.</param>
        /// <param name="encoding">Encoding used to decode the package.</param>
        /// <returns>The parsed <see cref="Mid"/> object.</returns>
        public virtual Mid Parse(byte[] package, Encoding encoding)
        {
            var pack = ToText(package, encoding);
            return Parse(pack);
        }

        protected virtual void ProcessDataFields(ReadOnlySpan<char> package)
        {
            if (!RevisionsByFields.Any())
                return;

            int revision = Header.StandardizedRevision;
            for (int i = 1; i <= revision; i++)
            {
                ProcessDataFields(i, package);
            }
        }

        protected virtual void ProcessDataFields(int revision, string package)
            => ProcessDataFields(revision, package.AsSpan());

        protected virtual void ProcessDataFields(int revision, ReadOnlySpan<char> package)
        {
            if (RevisionsByFields.TryGetValue(revision, out var fields))
            {
                ProcessDataFields(fields, package);
            }
        }

        protected virtual void ProcessDataFields(IEnumerable<DataField> dataFields, ReadOnlySpan<char> package)
        {
            foreach (var dataField in dataFields)
                ProcessDataField(dataField, package);
        }

        protected virtual void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
            => dataField.SetValue(GetValue(dataField, package));

        protected ReadOnlySpan<char> GetValue(DataField field, ReadOnlySpan<char> package)
        {
            try
            {
                return field.HasPrefix ? package.Slice(2 + field.Index, field.Size) : package.Slice(field.Index, field.Size);
            }
            catch (ArgumentOutOfRangeException)
            {
                return ReadOnlySpan<char>.Empty;
            }
        }

        protected byte[] GetValue(DataField field, byte[] package)
        {
            try
            {
                byte[] bytes = new byte[field.Size];
                var index = field.HasPrefix ? 2 + field.Index : field.Index;
                int j = 0;
                for (int i = index; i < index + field.Size; i++)
                {
                    bytes[j] = package[i];
                    j++;
                }

                return bytes;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }

        protected DataField GetField(int revision, int field)
        {
            if (!RevisionsByFields.TryGetValue(revision, out var fields))
            {
                return DataField.Default;
            }

            return fields.FirstOrDefault(x => x.Field == field) ?? DataField.Default;
        }

        protected DataField<T> GetField<T>(int revision, int field)
        {
            if (!RevisionsByFields.TryGetValue(revision, out var fields))
            {
                throw new ArgumentException("No fields registered for the specified revision.", nameof(revision));
            }

            return (DataField<T>)fields.FirstOrDefault(x => x.GetType() == typeof(DataField<T>) && x.Field == field);
        }

        protected DataField GetField(string propertyName)
        {
            var type = GetType();
            if (!_metadataCache.TryGetValue(type, out var metadata) && !_lazyFields.IsValueCreated)
            {
                _ = _lazyFields.Value; // Force initialization of the lazy fields to populate the metadata cache
                _metadataCache.TryGetValue(type, out metadata);
            }

            var dataField = metadata.First(x => x.Property.Name == propertyName);
            return RevisionsByFields[Header.StandardizedRevision].First(x => x.Field == dataField.Attribute.Field);
        }

        protected DataField GetField<TEnum>(int revision, TEnum field) where TEnum : struct, Enum
            => GetField(revision, field.GetHashCode());

        [Obsolete($"Packages are no longer necessarily ASCII encoded, use ToText(byte[]) which honors {nameof(DefaultEncoding)} instead.")]
        protected static string ToAscii(byte[] bytes) => ToText(bytes, DefaultEncoding);
        protected static string ToText(byte[] bytes) => ToText(bytes, DefaultEncoding);
        protected static string ToText(byte[] bytes, Encoding encoding) => encoding.GetString(bytes);
        protected static byte[] ToBytes(string value) => ToBytes(value, DefaultEncoding);
        protected static byte[] ToBytes(string value, Encoding encoding) => encoding.GetBytes(value);
        protected static Span<byte> ToBytesSpan(string value) => ToBytes(value.AsSpan());
        protected static Span<byte> ToBytes(ReadOnlySpan<char> value) => ToBytes(value, DefaultEncoding);
        protected static Span<byte> ToBytes(ReadOnlySpan<char> value, Encoding encoding)
        {
#if NETSTANDARD2_0
            return encoding.GetBytes(value.ToString());
#else
            var buffer = new byte[encoding.GetByteCount(value)];
            encoding.GetBytes(value, buffer);
            return buffer;
#endif
        }
    }
}
