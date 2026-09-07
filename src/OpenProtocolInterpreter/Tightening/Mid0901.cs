using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Trace plot parameters message
    /// <para>
    ///     This MID 0901 response contains all trace plotting parameters necessary for drawing
    ///     the limit figures in relation to the trace curve. The plotting parameters sent depend
    ///     on the Trace types subscribed for.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// <para>
    ///     Revisions (Open Protocol Specification R 2.21.1, section 5.8.10 / Tables 146–148):
    ///     Rev 1 = RDI + Time stamp + Number of PIDs + Variable data fields.
    ///     Rev 2 = Rev 1 + Request MID after Number of PIDs.
    ///     Rev 3 = Rev 2 + Object ID / Object type / Reference object ID / Trace Type after Request MID.
    ///     Every revision registers its FULL wire layout.
    /// </para>
    /// </summary>
    public class Mid0901 : Mid, ITightening, IController
    {
        public const int MID = 901;

        /// <summary>
        /// The Result Data Identifier is a unique ID for each operation result within the system. (10 bytes)
        /// </summary>
        public string ResultDataIdentifier
        {
            get => GetActiveField(DataFields.ResultDataIdentifier).Value;
            set => GetActiveField(DataFields.ResultDataIdentifier).SetValue(value);
        }

        /// <summary>
        /// Time stamp for each operation sent to the control station (YYYY-MM-DD:HH:MM:SS, 19 bytes).
        /// </summary>
        public DateTime TimeStamp
        {
            get => GetActiveField(DataFields.TimeStamp).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetActiveField(DataFields.TimeStamp).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>Number of PID's (parameter / variable data fields) in the telegram.</summary>
        public int NumberOfPIDs
        {
            get => GetActiveField(DataFields.NumberOfPIDs).GetValue(OpenProtocolConvert.ToInt32);
            set => GetActiveField(DataFields.NumberOfPIDs).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>The MID of the request that this message is a response to (typically 0008 or 0006). (Revision 2+)</summary>
        public int RequestMid
        {
            get => GetActiveField(DataFields.RequestMid).GetValue(OpenProtocolConvert.ToInt32);
            set => GetActiveField(DataFields.RequestMid).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>The user defined object ID. (Revision 3)</summary>
        public int ObjectId
        {
            get => GetActiveField(DataFields.ObjectId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetActiveField(DataFields.ObjectId).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>Type of the object (0 = Unknown, 1 = Dual Reading, 2 = Tightening Production, ...). (Revision 3)</summary>
        public ObjectType ObjectType
        {
            get => (ObjectType)GetActiveField(DataFields.ObjectType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetActiveField(DataFields.ObjectType).SetValue(OpenProtocolConvert.ToString, (int)value);
        }

        /// <summary>Link to related Object ID. (Revision 3)</summary>
        public int ReferenceObjectId
        {
            get => GetActiveField(DataFields.ReferenceObjectId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetActiveField(DataFields.ReferenceObjectId).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>Type of the trace curve (1 = Angle, 2 = Torque, 3 = Current, 4 = Gradient, 5 = Stroke, 6 = Force). (Revision 3)</summary>
        public int TraceType
        {
            get => GetActiveField(DataFields.TraceType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetActiveField(DataFields.TraceType).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>Variable / parameter data fields (plotting PID records).</summary>
        public List<VariableDataField> VariableDataFields { get; set; } = new List<VariableDataField>();

        public Mid0901() : this(DEFAULT_REVISION)
        {
        }

        public Mid0901(Header header) : base(header)
        {
        }

        public Mid0901(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        /// <summary>
        /// Sets the Volatile field size and packs ONLY the current revision's field list, in wire order.
        /// </summary>
        public override string Pack()
        {
            var revision = Header.StandardizedRevision;
            SetVolatileFieldSizes(revision);

            var builder = new StringBuilder(BuildHeader());
            int prefixIndex = 1;
            builder.Append(Pack(revision, ref prefixIndex));
            return builder.ToString();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            ProcessDataFields(package);
            return this;
        }

        /// <summary>
        /// Sum ONLY the active revision's full field layout before rendering the length prefix.
        /// The base implementation sums every revision 1..N, which is wrong for full per-revision layouts.
        /// </summary>
        protected override string BuildHeader()
        {
            Header.Length = Header.DefaultSize;
            if (RevisionsByFields.TryGetValue(Header.StandardizedRevision, out var activeFields))
            {
                foreach (var field in activeFields)
                    Header.Length += (field.HasPrefix ? 2 : 0) + field.Size;
            }

            return Header.ToString();
        }

        /// <summary>
        /// Sizes the variable-length data-field section from the current list contents so the
        /// Volatile data field and <see cref="Header.Length"/> are correct before packing.
        /// </summary>
        private void SetVolatileFieldSizes(int revision)
        {
            NumberOfPIDs = VariableDataFields.Count;
            var pidsField = GetField(revision, DataFields.VariableDataFields);
            pidsField.SetValue(OpenProtocolConvert.ToString(VariableDataFields));
            pidsField.Size = pidsField.Value.Length;
        }

        /// <summary>
        /// Parses fixed lead fields for the active revision, then sizes the trailing Variable
        /// data fields section from the remaining declared body length.
        /// </summary>
        protected override void ProcessDataFields(string package)
        {
            var revision = Header.StandardizedRevision;
            base.ProcessDataFields(revision, package);

            var dataFields = GetField(revision, DataFields.VariableDataFields);
            int remaining = Header.Length - dataFields.Index;
            if (remaining < 0)
                remaining = 0;

            dataFields.Size = remaining;
            dataFields.Value = GetValue(dataFields, package);
            VariableDataFields = VariableDataField.ParseAll(dataFields.Value).ToList();
        }

        /// <summary>Looks up a data field in the ACTIVE revision's list.</summary>
        private DataField GetActiveField(DataFields field) => GetField(Header.StandardizedRevision, field);

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        // Spec R 2.21.1, Table 146 (MID 901 data field, revision 1).
                        DataField.String(DataFields.ResultDataIdentifier, 20, 10, false),
                        DataField.Timestamp(DataFields.TimeStamp, 30, false),
                        DataField.Number(DataFields.NumberOfPIDs, 49, 3, false),
                        DataField.Volatile(DataFields.VariableDataFields, 52, false)
                    }
                },
                {
                    2, new List<DataField>()
                    {
                        // Spec R 2.21.1, Table 147 (MID 901 data field, revision 2).
                        // Rev 2 = Rev 1 + Request MID (UI4) immediately after Number of PIDs.
                        DataField.String(DataFields.ResultDataIdentifier, 20, 10, false),
                        DataField.Timestamp(DataFields.TimeStamp, 30, false),
                        DataField.Number(DataFields.NumberOfPIDs, 49, 3, false),
                        DataField.Number(DataFields.RequestMid, 52, 4, false),
                        DataField.Volatile(DataFields.VariableDataFields, 56, false)
                    }
                },
                {
                    3, new List<DataField>()
                    {
                        // Spec R 2.21.1, Table 148 (MID 901 data field, revision 3).
                        // Rev 3 = Rev 2 + Object ID / Object type / Reference object ID / Trace Type
                        // immediately after Request MID, before the variable data fields.
                        DataField.String(DataFields.ResultDataIdentifier, 20, 10, false),
                        DataField.Timestamp(DataFields.TimeStamp, 30, false),
                        DataField.Number(DataFields.NumberOfPIDs, 49, 3, false),
                        DataField.Number(DataFields.RequestMid, 52, 4, false),
                        DataField.Number(DataFields.ObjectId, 56, 4, false),
                        DataField.Number(DataFields.ObjectType, 60, 1, false),
                        DataField.Number(DataFields.ReferenceObjectId, 61, 4, false),
                        DataField.Number(DataFields.TraceType, 65, 2, false),
                        DataField.Volatile(DataFields.VariableDataFields, 67, false)
                    }
                }
            };
        }

        protected enum DataFields
        {
            ResultDataIdentifier,
            TimeStamp,
            NumberOfPIDs,
            RequestMid,
            ObjectId,
            ObjectType,
            ReferenceObjectId,
            TraceType,
            VariableDataFields
        }
    }
}
