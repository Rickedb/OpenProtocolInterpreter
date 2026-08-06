using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenProtocolInterpreter
{
    public abstract class ExtraData
    {
        private static readonly ConcurrentDictionary<Type, DataFieldMetadata[]> _metadataCache = new();
        private readonly Lazy<Dictionary<int, List<DataField>>> _lazyFields;

        protected internal Dictionary<int, List<DataField>> RevisionsByFields => _lazyFields.Value;

        public abstract int Mid { get; }
        public int Revision { get; set; }
        public int StandardizedRevision => Revision > 0 ? Revision : 1;

        public ExtraData() : this(1)
        {

        }

        public ExtraData(int revision)
        {
            Revision = revision;
            _lazyFields = new Lazy<Dictionary<int, List<DataField>>>(() => new SafeAccessRevisionsFields(RegisterDatafields()));
        }

        public ExtraData Parse(string extraData)
            => Parse(extraData.AsSpan());

        public virtual ExtraData Parse(ReadOnlySpan<char> package)
        {
            if (!RevisionsByFields.Any())
                return this;

            for (int i = 1; i <= StandardizedRevision; i++)
            {
                foreach (var dataField in RevisionsByFields[i])
                {
                    ProcessDataField(dataField, package);
                }
            }

            return this;
        }

        public virtual string Pack()
        {
            if (!RevisionsByFields.TryGetValue(StandardizedRevision, out var dataFields))
            {
                return string.Empty;
            }

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

        protected virtual void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            try
            {
                var value = dataField.HasPrefix ? package.Slice(2 + dataField.Index, dataField.Size) : package.Slice(dataField.Index, dataField.Size);
                dataField.SetValue(value);
            }
            catch (ArgumentOutOfRangeException)
            {
                //Ignore failure
            }
        }

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

        protected DataField GetField(int revision, int field)
        {
            if (!RevisionsByFields.TryGetValue(revision, out var fields))
            {
                return DataField.Default;
            }

            return fields.FirstOrDefault(x => x.Field == field) ?? DataField.Default;
        }
    }
}
