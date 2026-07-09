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

        private readonly Lazy<Dictionary<int, List<DataField>>> _lazyFields;
        protected const int DEFAULT_REVISION = 1;

        protected Dictionary<int, List<DataField>> RevisionsByFields => _lazyFields.Value;

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

        public virtual string Pack()
        {
            var header = BuildHeader();
            if (!RevisionsByFields.Any())
                return header;

            var builder = new StringBuilder(header);
            int prefixIndex = 1;
            var revision = Header.StandardizedRevision;
            for (int i = 1; i <= revision; i++)
            {
                builder.Append(Pack(i, ref prefixIndex));
            }

            return builder.ToString();
        }

        public virtual byte[] PackBytes() => Encoding.ASCII.GetBytes(Pack());

        protected virtual string Pack(int revision, ref int prefixIndex)
        {
            if (!RevisionsByFields.TryGetValue(revision, out var dataFields))
            {
                return string.Empty;
            }

            return Pack(dataFields, ref prefixIndex);
        }

        protected virtual string Pack(List<DataField> dataFields, ref int prefixIndex)
        {
            var builder = new StringBuilder();
            foreach (var dataField in dataFields)
            {
                if (dataField is IBackedPropertyDataField backedPropertyDataField)
                    backedPropertyDataField.SyncWithBackingPropertyIfBound();

                if (dataField.HasPrefix)
                {
                    builder.Append(prefixIndex.ToString("D2"));
                    prefixIndex++;
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
                                     .Where(x =>
                                     {
                                         return x.CustomAttributes.Any(a => a.AttributeType.IsAssignableTo(typeof(DataFieldDefinitionAttribute)));
                                     });
                int fieldIndex = 20;
                foreach (var prop in properties)
                {
                    var attributes = prop.GetCustomAttributes<DataFieldDefinitionAttribute>();
                    if (!attributes.Any())
                        continue;

                    foreach (var attr in attributes)
                    {
                        fieldIndex = attr.Index > 0 ? attr.Index : fieldIndex; //enforced index if defined in attribute
                        attr.Index = fieldIndex;
                        result.Add(new DataFieldMetadata(fieldIndex, attr, prop));
                        fieldIndex += attr.Size + (attr.HasPrefix ? 2 : 0);
                    }
                }
                return result.ToArray();
            });

            var fields = new Dictionary<int, List<DataField>>();
            var currentRevision = Header.Revision;
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
                return ParseHeader(buffer);
            }

            return ParseHeader(package);
        }

        public virtual Mid Parse(string package)
            => Parse(package.AsSpan());

        public virtual Mid Parse(ReadOnlySpan<char> package)
        {
            Header = ProcessHeader(package);
            ProcessDataFields(package);
            return this;
        }

        public virtual Mid Parse(byte[] package)
        {
            var pack = ToAscii(package);
            return Parse(pack);
        }

        protected virtual void ProcessDataFields(string package)
        {
            if (!RevisionsByFields.Any())
                return;

            int revision = Header.Revision > 0 ? Header.Revision : 1;
            for (int i = 1; i <= revision; i++)
            {
                ProcessDataFields(i, package);
            }
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

        protected virtual void ProcessDataFields(List<DataField> dataFields, string package)
            => ProcessDataFields(dataFields, package.AsSpan());

        protected virtual void ProcessDataFields(List<DataField> dataFields, ReadOnlySpan<char> package)
        {
            foreach (var dataField in dataFields)
                ProcessDataField(dataField, package);
        }

        protected virtual void ProcessDataField(DataField dataField, string package)
            => dataField.SetValue(GetValue(dataField, package));

        protected virtual void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
            => dataField.SetValue(GetValue(dataField, package));

        protected string GetValue(DataField field, string package)
        {
            try
            {
                return field.HasPrefix ? package.Substring(2 + field.Index, field.Size) : package.Substring(field.Index, field.Size);
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }

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

        protected DataField GetField(string propertyName)
        {
            var type = GetType();
            if (!_metadataCache.TryGetValue(type, out var metadata) && !_lazyFields.IsValueCreated)
            {
                _ = _lazyFields.Value; // Force initialization of the lazy fields to populate the metadata cache
                _metadataCache.TryGetValue(type, out metadata);
            }

            var dataField = metadata.First(x => x.Property.Name == propertyName);
            return RevisionsByFields[dataField.Attribute.Revision].First(x => x.Field == dataField.Attribute.Field);
        }

        protected DataField GetField<TEnum>(int revision, TEnum field) where TEnum : struct, Enum
            => GetField(revision, field.GetHashCode());

        protected static string ToAscii(byte[] bytes) => Encoding.ASCII.GetString(bytes);
        protected static byte[] ToBytes(string value) => Encoding.ASCII.GetBytes(value);
        protected static Span<byte> ToBytesSpan(string value) => ToBytes(value.AsSpan());
        protected static Span<byte> ToBytes(ReadOnlySpan<char> value)
        {
            var buffer = new byte[value.Length];
#if NETSTANDARD2_0
            Encoding.ASCII.GetBytes(value.ToString(), 0, value.Length, buffer, 0);
#else
            Encoding.ASCII.GetBytes(value, buffer);
#endif
            return buffer;
        }

        private Header ParseHeader(ReadOnlySpan<char> package)
        {
#if NETSTANDARD2_0
            static bool IsNotEmptyOrZero(ReadOnlySpan<char> package, out int value)
            {
                value = 0;
                return !package.IsWhiteSpace() && int.TryParse(package.ToString(), out value) && value > 0;
            }
            static int ParseInt(ReadOnlySpan<char> span) => int.Parse(span.ToString());
            static bool TryParseInt(ReadOnlySpan<char> span, out int value) => int.TryParse(span.ToString(), out value);
#else
            static bool IsNotEmptyOrZero(ReadOnlySpan<char> package, out int value)
            {
                value = 0;
                return !package.IsWhiteSpace() && int.TryParse(package, out value) && value > 0;
            }
            static int ParseInt(ReadOnlySpan<char> span) => int.Parse(span);
            static bool TryParseInt(ReadOnlySpan<char> span, out int value) => int.TryParse(span, out value);
#endif

            return new Header
            {
                Length = ParseInt(package.Slice(0, 4)),
                Mid = ParseInt(package.Slice(4, 4)),
                Revision = IsNotEmptyOrZero(package.Slice(8, 3), out var revision) ? revision : 1,
                NoAckFlag = !package.Slice(11, 1).IsWhiteSpace(),
                StationId = TryParseInt(package.Slice(12, 2), out var stationId) ? stationId : 1,
                SpindleId = TryParseInt(package.Slice(14, 2), out var spindleId) ? spindleId : 1,
                SequenceNumber = IsNotEmptyOrZero(package.Slice(16, 2), out var sequenceNumber) ? sequenceNumber : default(int?),
                NumberOfMessages = IsNotEmptyOrZero(package.Slice(18, 1), out var numberOfMessages) ? numberOfMessages : default(int?),
                MessageNumber = IsNotEmptyOrZero(package.Slice(19, 1), out var messageNumber) ? messageNumber : default(int?)
            };
        }
    }
}
