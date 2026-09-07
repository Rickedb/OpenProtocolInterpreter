using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Trace curve data message
    /// <para>
    ///     This MID 0900 response contains all data from the trace curve that the integrator has
    ///     subscribed for, except the plotting parameters that are sent in MID 0901.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// <para>
    ///     The message has an ASCII lead followed by a single NUL (0x00) separator and
    ///     <see cref="NumberOfSamples"/> x 2-byte big-endian signed binary trace samples.
    /// </para>
    /// <para>
    ///     Revisions (Open Protocol Specification R 2.21.1, section 5.8.9):
    ///     Rev 1 = Table 139, Rev 2 = Rev 1 + Request MID after Unit, Rev 3 = Rev 2 +
    ///     Object ID / Object type / Reference object ID after Time stamp and Number of traces
    ///     after Trace Type. Every revision registers its FULL wire layout.
    /// </para>
    /// </summary>
    public class Mid0900 : Mid, ITightening, IController
    {
        public const int MID = 900;

        /// <summary>
        /// Binary trace samples are appended after a single NUL (0x00) separator that follows the
        /// ASCII lead. Each sample is a 2-byte big-endian signed value.
        /// </summary>
        private const int BinarySeparatorSize = 1;

        /// <summary>Fixed portion of a variable data field record: PID(5) + Length(3) + DataType(2) + Unit(3) + StepNumber(4).</summary>
        private const int VariableDataFieldHeaderSize = 17;

        /// <summary>Fixed portion of a resolution field record: FirstIndex(5) + LastIndex(5) + Length(3) + DataType(2) + Unit(3).</summary>
        private const int ResolutionFieldHeaderSize = 18;

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

        /// <summary>Number of PID's (variable data fields) in the telegram.</summary>
        public int NumberOfPIDs
        {
            get => GetActiveField(DataFields.NumberOfPIDs).GetValue(OpenProtocolConvert.ToInt32);
            set => GetActiveField(DataFields.NumberOfPIDs).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>Variable data fields (PID records) common for all traces.</summary>
        public List<VariableDataField> VariableDataFields { get; set; } = new List<VariableDataField>();

        /// <summary>Type of the trace curve (1 = Angle, 2 = Torque, 3 = Current, 4 = Gradient, 5 = Stroke, 6 = Force).</summary>
        public int TraceType
        {
            get => GetActiveField(DataFields.TraceType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetActiveField(DataFields.TraceType).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>Transducer used to produce the trace data (0 = no transducer, 1 = transducer 1, ...).</summary>
        public int TransducerType
        {
            get => GetActiveField(DataFields.TransducerType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetActiveField(DataFields.TransducerType).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>Unit of trace curve, according to the table Units types (e.g. 001 = Nm).</summary>
        public int Unit
        {
            get => GetActiveField(DataFields.Unit).GetValue(OpenProtocolConvert.ToInt32);
            set => GetActiveField(DataFields.Unit).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>Number of parameter data fields in the telegram.</summary>
        public int NumberOfParameterDataFields
        {
            get => GetActiveField(DataFields.NumberOfParameterDataFields).GetValue(OpenProtocolConvert.ToInt32);
            set => GetActiveField(DataFields.NumberOfParameterDataFields).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>Parameter data fields (PID records).</summary>
        public List<VariableDataField> ParameterDataFields { get; set; } = new List<VariableDataField>();

        /// <summary>Number of different resolution fields in this telegram.</summary>
        public int NumberOfResolutionFields
        {
            get => GetActiveField(DataFields.NumberOfResolutionFields).GetValue(OpenProtocolConvert.ToInt32);
            set => GetActiveField(DataFields.NumberOfResolutionFields).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>Resolution fields defining the time interval between consecutive samples.</summary>
        public List<ResolutionDataField> ResolutionFields { get; set; } = new List<ResolutionDataField>();

        /// <summary>Number of samples in the trace.</summary>
        public int NumberOfSamples
        {
            get => GetActiveField(DataFields.NumberOfSamples).GetValue(OpenProtocolConvert.ToInt32);
            set => GetActiveField(DataFields.NumberOfSamples).SetValue(OpenProtocolConvert.ToString, value);
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

        /// <summary>How many MID 0901 graphs the controller will send. (Revision 3)</summary>
        public int NumberOfTraces
        {
            get => GetActiveField(DataFields.NumberOfTraces).GetValue(OpenProtocolConvert.ToInt32);
            set => GetActiveField(DataFields.NumberOfTraces).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>
        /// Raw binary data portion of the message (everything after the NUL separator).
        /// Populated by <see cref="Parse(byte[])"/>.
        /// </summary>
        public byte[] RawBinaryData { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// Binary trace samples decoded from <see cref="RawBinaryData"/> as big-endian signed 16-bit values.
        /// </summary>
        public List<short> TraceSamples { get; set; } = new List<short>();

        public Mid0900() : this(DEFAULT_REVISION)
        {

        }

        public Mid0900(Header header) : base(header)
        {
        }

        public Mid0900(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        /// <summary>
        /// Parses the ASCII lead via the normal datafield helpers, then locates the NUL (0x00)
        /// separator inside the header-declared body and copies everything after it into
        /// <see cref="RawBinaryData"/>, decoding big-endian Int16 samples into <see cref="TraceSamples"/>.
        /// </summary>
        public override Mid Parse(byte[] package)
        {
            // Parse the ASCII lead (header + fixed/variable text fields) first.
            base.Parse(package);

            int bodyStart = Header.DefaultSize;
            int bodyLength = Header.Length - Header.DefaultSize;
            if (bodyLength <= 0 || package.Length < bodyStart + bodyLength)
                return this;

            // Scan for the NUL separator inside the declared body.
            int nullIndex = -1;
            for (int i = bodyStart; i < bodyStart + bodyLength; i++)
            {
                if (package[i] == 0x00)
                {
                    nullIndex = i;
                    break;
                }
            }

            if (nullIndex < 0 || nullIndex >= bodyStart + bodyLength - 1)
                return this;

            int binaryStart = nullIndex + 1;
            int binaryLength = (bodyStart + bodyLength) - binaryStart;
            if (binaryLength <= 0)
                return this;

            RawBinaryData = new byte[binaryLength];
            Array.Copy(package, binaryStart, RawBinaryData, 0, binaryLength);
            DecodeTraceSamples();
            return this;
        }

        /// <summary>
        /// Parses the ASCII lead fields only. The binary tail cannot be carried by a string, so
        /// <see cref="RawBinaryData"/> / <see cref="TraceSamples"/> are left untouched (by design).
        /// </summary>
        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            ProcessDataFields(package);
            return this;
        }

        /// <summary>
        /// Sets the Volatile field sizes, builds the ASCII body and appends the NUL separator byte.
        /// Packs ONLY the current revision's field list, in wire order.
        /// </summary>
        public override string Pack()
        {
            var revision = Header.StandardizedRevision;
            SetVolatileFieldSizes(revision);

            var builder = new StringBuilder(BuildHeader());
            int prefixIndex = 1;
            builder.Append(Pack(revision, ref prefixIndex));

            // NUL separator between the ASCII lead and the binary trace samples.
            builder.Append('\0');
            return builder.ToString();
        }

        /// <summary>ASCII bytes of <see cref="Pack()"/> with the big-endian sample bytes appended.</summary>
        public override byte[] PackBytes()
        {
            var asciiBytes = ToBytes(Pack());
            var sampleBytes = EncodeTraceSamples();

            var result = new byte[asciiBytes.Length + sampleBytes.Length];
            Array.Copy(asciiBytes, 0, result, 0, asciiBytes.Length);
            Array.Copy(sampleBytes, 0, result, asciiBytes.Length, sampleBytes.Length);
            return result;
        }

        protected override string BuildHeader()
        {
            // Sum ONLY the active revision's full field layout, then add the NUL separator and
            // the 2 x NumberOfSamples binary bytes, before rendering the length prefix. The base
            // implementation sums every revision 1..N, which is wrong for full per-revision layouts.
            Header.Length = Header.DefaultSize;
            if (RevisionsByFields.TryGetValue(Header.StandardizedRevision, out var activeFields))
                foreach (var field in activeFields)
                    Header.Length += (field.HasPrefix ? 2 : 0) + field.Size;

            Header.Length += BinarySeparatorSize + (NumberOfSamples * 2);
            return Header.ToString();
        }

        /// <summary>
        /// Sizes the variable-length sections from the current list contents so the Volatile
        /// data fields and <see cref="Header.Length"/> are correct before packing.
        /// </summary>
        private void SetVolatileFieldSizes(int revision)
        {
            NumberOfPIDs = VariableDataFields.Count;
            var pidsField = GetField(revision, DataFields.VariableDataFields);
            pidsField.SetValue(OpenProtocolConvert.ToString(VariableDataFields));
            pidsField.Size = pidsField.Value.Length;

            NumberOfParameterDataFields = ParameterDataFields.Count;
            var paramField = GetField(revision, DataFields.ParameterDataFields);
            paramField.SetValue(OpenProtocolConvert.ToString(ParameterDataFields));
            paramField.Size = paramField.Value.Length;

            NumberOfResolutionFields = ResolutionFields.Count;
            var resolutionField = GetField(revision, DataFields.ResolutionFields);
            resolutionField.SetValue(PackResolutionFields());
            resolutionField.Size = resolutionField.Value.Length;

            // Re-assert fixed-width numeric fields so Volatile-era space padding cannot leak
            // if a field was ever written with the wrong Size/padding before LayoutField ran.
            TraceType = TraceType;
            TransducerType = TransducerType;
            Unit = Unit;
            if (revision >= 2)
                RequestMid = RequestMid;
            if (revision >= 3)
                NumberOfTraces = NumberOfTraces;

            NumberOfSamples = TraceSamples.Count;
            RepointNumberOfSamples(revision);
        }

        private string PackResolutionFields()
        {
            var builder = new StringBuilder();
            foreach (var field in ResolutionFields)
                builder.Append(field.Pack());

            return builder.ToString();
        }

        /// <summary>
        /// Computes the Volatile field sizes from the header-declared body length and parses the
        /// variable-length PID / parameter / resolution sections in wire order. Only the current
        /// revision's field list is processed, so every wire offset matches the spec layout.
        /// </summary>
        protected override void ProcessDataFields(string package)
        {
            var revision = Header.StandardizedRevision;

            // Let the base class populate the fixed lead fields of the ACTIVE revision.
            base.ProcessDataFields(revision, package);

            // Lay out the volatile region sequentially in wire order: assign each field's Index
            // from the running position and compute its Size, so every offset matches the spec.
            int position = GetField(revision, DataFields.VariableDataFields).Index;

            void LayoutField(DataFields field, int size)
            {
                var f = GetField(revision, field);
                f.Index = position;
                f.Size = size;
                position += size;
            }

            LayoutField(DataFields.VariableDataFields, ComputeVariableSectionSize(package, position, NumberOfPIDs, VariableDataFieldHeaderSize));
            LayoutField(DataFields.TraceType, 2);
            if (revision >= 3)
                LayoutField(DataFields.NumberOfTraces, 2);
            LayoutField(DataFields.TransducerType, 2);
            LayoutField(DataFields.Unit, 3);
            if (revision >= 2)
                LayoutField(DataFields.RequestMid, 4);
            LayoutField(DataFields.NumberOfParameterDataFields, 3);
            int noParams = OpenProtocolConvert.ToInt32(ReReadField(revision, DataFields.NumberOfParameterDataFields, package));
            LayoutField(DataFields.ParameterDataFields, ComputeVariableSectionSize(package, position, noParams, VariableDataFieldHeaderSize));
            LayoutField(DataFields.NumberOfResolutionFields, 3);
            int noRes = OpenProtocolConvert.ToInt32(ReReadField(revision, DataFields.NumberOfResolutionFields, package));
            LayoutField(DataFields.ResolutionFields, ComputeVariableSectionSize(package, position, noRes, ResolutionFieldHeaderSize, lengthOffset: 10));
            LayoutField(DataFields.NumberOfSamples, 5);
            // base populate, so re-read them now that all sizes/indices are final.
            VariableDataFields = VariableDataField.ParseAll(ReReadField(revision, DataFields.VariableDataFields, package)).ToList();
            TraceType = OpenProtocolConvert.ToInt32(ReReadField(revision, DataFields.TraceType, package));
            if (revision >= 3)
                NumberOfTraces = OpenProtocolConvert.ToInt32(ReReadField(revision, DataFields.NumberOfTraces, package));
            TransducerType = OpenProtocolConvert.ToInt32(ReReadField(revision, DataFields.TransducerType, package));
            Unit = OpenProtocolConvert.ToInt32(ReReadField(revision, DataFields.Unit, package));
            if (revision >= 2)
                RequestMid = OpenProtocolConvert.ToInt32(ReReadField(revision, DataFields.RequestMid, package));
            ParameterDataFields = VariableDataField.ParseAll(ReReadField(revision, DataFields.ParameterDataFields, package)).ToList();
            ResolutionFields = ResolutionDataField.ParseAll(ReReadField(revision, DataFields.ResolutionFields, package)).ToList();
            NumberOfSamples = OpenProtocolConvert.ToInt32(ReReadField(revision, DataFields.NumberOfSamples, package));
        }

        /// <summary>Re-reads a field's raw value from the package at its current index/size.</summary>
        private string ReReadField(int revision, DataFields field, string package)
        {
            var dataField = GetField(revision, field);
            dataField.Value = GetValue(dataField, package);
            return dataField.Value;
        }

        /// <summary>
        /// Walks <paramref name="count"/> variable-length records starting at <paramref name="sectionStartIndex"/>
        /// and returns the total wire size of the section. Each record has a fixed header of
        /// <paramref name="recordHeaderSize"/> bytes followed by a Length-prefixed value.
        /// </summary>
        private static int ComputeVariableSectionSize(string package, int sectionStartIndex, int count, int recordHeaderSize, int lengthOffset = 5)
        {
            int position = sectionStartIndex;
            for (int i = 0; i < count; i++)
            {
                int length = ReadInt(package, position + lengthOffset, 3);
                position += recordHeaderSize + length;
            }

            return position - sectionStartIndex;
        }

        private void RepointNumberOfSamples(int revision)
        {
            var resolutionField = GetField(revision, DataFields.ResolutionFields);
            GetField(revision, DataFields.NumberOfSamples).Index = resolutionField.Index + resolutionField.Size;
        }

        private static int ReadInt(string value, int index, int size)
        {
            if (index + size > value.Length)
                return 0;

            return OpenProtocolConvert.ToInt32(value.Substring(index, size));
        }

        /// <summary>Decodes <see cref="RawBinaryData"/> into <see cref="TraceSamples"/> as big-endian signed 16-bit values.</summary>
        private void DecodeTraceSamples()
        {
            TraceSamples = new List<short>();
            int sampleCount = Math.Min(NumberOfSamples, RawBinaryData.Length / 2);
            for (int i = 0; i < sampleCount; i++)
            {
                int offset = i * 2;
                // Manual big-endian decode: (short)((b[0] << 8) | b[1])
                TraceSamples.Add((short)((RawBinaryData[offset] << 8) | RawBinaryData[offset + 1]));
            }
        }

        /// <summary>Encodes <see cref="TraceSamples"/> as big-endian signed 16-bit bytes.</summary>
        private byte[] EncodeTraceSamples()
        {
            var bytes = new byte[TraceSamples.Count * 2];
            for (int i = 0; i < TraceSamples.Count; i++)
            {
                bytes[i * 2] = (byte)(TraceSamples[i] >> 8);
                bytes[i * 2 + 1] = (byte)(TraceSamples[i] & 0xFF);
            }

            return bytes;
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
                        // Spec R 2.21.1, section 5.8.9, Table 139 (MID 900 Data field, revision 1).
                        // Fixed-width numeric fields use Number (zero-padded) even when their
                        // absolute Index is rewritten in ProcessDataFields; only truly variable
                        // sections are Volatile (space padding must not be applied to UI fields).
                        DataField.String(DataFields.ResultDataIdentifier, 20, 10, false),
                        DataField.Timestamp(DataFields.TimeStamp, 30, false),
                        DataField.Number(DataFields.NumberOfPIDs, 49, 3, false),
                        DataField.Volatile(DataFields.VariableDataFields, 52, false),
                        DataField.Number(DataFields.TraceType, 52, 2, false),
                        DataField.Number(DataFields.TransducerType, 52, 2, false),
                        DataField.Number(DataFields.Unit, 52, 3, false),
                        DataField.Number(DataFields.NumberOfParameterDataFields, 52, 3, false),
                        DataField.Volatile(DataFields.ParameterDataFields, 52, false),
                        DataField.Number(DataFields.NumberOfResolutionFields, 52, 3, false),
                        DataField.Volatile(DataFields.ResolutionFields, 52, false),
                        DataField.Number(DataFields.NumberOfSamples, 52, 5, false)
                    }
                },
                {
                    2, new List<DataField>()
                    {
                        // Spec R 2.21.1, section 5.8.9, Table 140 (MID 900 Data field, revision 2).
                        // Rev 2 = Rev 1 + Request MID (UI4) immediately after Unit.
                        DataField.String(DataFields.ResultDataIdentifier, 20, 10, false),
                        DataField.Timestamp(DataFields.TimeStamp, 30, false),
                        DataField.Number(DataFields.NumberOfPIDs, 49, 3, false),
                        DataField.Volatile(DataFields.VariableDataFields, 52, false),
                        DataField.Number(DataFields.TraceType, 52, 2, false),
                        DataField.Number(DataFields.TransducerType, 52, 2, false),
                        DataField.Number(DataFields.Unit, 52, 3, false),
                        DataField.Number(DataFields.RequestMid, 52, 4, false),
                        DataField.Number(DataFields.NumberOfParameterDataFields, 52, 3, false),
                        DataField.Volatile(DataFields.ParameterDataFields, 52, false),
                        DataField.Number(DataFields.NumberOfResolutionFields, 52, 3, false),
                        DataField.Volatile(DataFields.ResolutionFields, 52, false),
                        DataField.Number(DataFields.NumberOfSamples, 52, 5, false)
                    }
                },
                {
                    3, new List<DataField>()
                    {
                        // Spec R 2.21.1, section 5.8.9, Table 141 (MID 900 Data field, revision 3).
                        // Rev 3 = Rev 2 + Object ID (UI4), Object type (UI1), Reference object ID (UI4)
                        // immediately after the Time stamp, and Number of traces (UI2) immediately
                        // after Trace Type.
                        DataField.String(DataFields.ResultDataIdentifier, 20, 10, false),
                        DataField.Timestamp(DataFields.TimeStamp, 30, false),
                        DataField.Number(DataFields.ObjectId, 49, 4, false),
                        DataField.Number(DataFields.ObjectType, 53, 1, false),
                        DataField.Number(DataFields.ReferenceObjectId, 54, 4, false),
                        DataField.Number(DataFields.NumberOfPIDs, 58, 3, false),
                        DataField.Volatile(DataFields.VariableDataFields, 61, false),
                        DataField.Number(DataFields.TraceType, 61, 2, false),
                        DataField.Number(DataFields.NumberOfTraces, 61, 2, false),
                        DataField.Number(DataFields.TransducerType, 61, 2, false),
                        DataField.Number(DataFields.Unit, 61, 3, false),
                        DataField.Number(DataFields.RequestMid, 61, 4, false),
                        DataField.Number(DataFields.NumberOfParameterDataFields, 61, 3, false),
                        DataField.Volatile(DataFields.ParameterDataFields, 61, false),
                        DataField.Number(DataFields.NumberOfResolutionFields, 61, 3, false),
                        DataField.Volatile(DataFields.ResolutionFields, 61, false),
                        DataField.Number(DataFields.NumberOfSamples, 61, 5, false)
                    }
                }
            };
        }

        protected enum DataFields
        {
            ResultDataIdentifier,
            TimeStamp,
            NumberOfPIDs,
            VariableDataFields,
            TraceType,
            NumberOfTraces,
            TransducerType,
            Unit,
            RequestMid,
            NumberOfParameterDataFields,
            ParameterDataFields,
            NumberOfResolutionFields,
            ResolutionFields,
            NumberOfSamples,
            ObjectId,
            ObjectType,
            ReferenceObjectId
        }
    }

    /// <summary>
    /// Represents a single resolution field entry of MID 0900 trace curve data.
    /// <para>
    ///     Wire format: FirstIndex(5) + LastIndex(5) + Length(3) + DataType(2) + Unit(3) + TimeValue(Length).
    ///     Fixed header = 18 bytes, total = 18 + Length.
    /// </para>
    /// </summary>
    public class ResolutionDataField
    {
        /// <summary>Fixed header size: FirstIndex(5) + LastIndex(5) + Length(3) + DataType(2) + Unit(3) = 18.</summary>
        public const int HeaderSize = 18;

        /// <summary>The first index in the trace data where this resolution is valid.</summary>
        public int FirstIndex { get; set; }

        /// <summary>The last index in the trace data where this resolution is valid.</summary>
        public int LastIndex { get; set; }

        /// <summary>Length of the time value.</summary>
        public int Length { get; set; }

        /// <summary>Data type of the time value.</summary>
        public DataTypeDefinition DataType { get; set; }

        /// <summary>Unit of the time value.</summary>
        public DataUnitType Unit { get; set; }

        /// <summary>The time between two consecutive samples.</summary>
        public string TimeValue { get; set; }

        /// <summary>Total bytes this entry occupies on the wire: 18 + Length.</summary>
        public int TotalSize => HeaderSize + Length;

        public string Pack()
        {
            return OpenProtocolConvert.ToString('0', 5, PaddingOrientation.LeftPadded, FirstIndex) +
                   OpenProtocolConvert.ToString('0', 5, PaddingOrientation.LeftPadded, LastIndex) +
                   OpenProtocolConvert.ToString('0', 3, PaddingOrientation.LeftPadded, Length) +
                   OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, (int)DataType) +
                   OpenProtocolConvert.ToString('0', 3, PaddingOrientation.LeftPadded, (int)Unit) +
                   TimeValue;
        }

        public static IEnumerable<ResolutionDataField> ParseAll(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                yield break;

            int position = 0;
            while (position + HeaderSize <= value.Length)
            {
                int length = OpenProtocolConvert.ToInt32(value.Substring(position + 10, 3));
                int totalSize = HeaderSize + length;
                if (position + totalSize > value.Length)
                    yield break;

                yield return new ResolutionDataField()
                {
                    FirstIndex = OpenProtocolConvert.ToInt32(value.Substring(position, 5)),
                    LastIndex = OpenProtocolConvert.ToInt32(value.Substring(position + 5, 5)),
                    Length = length,
                    DataType = (DataTypeDefinition)OpenProtocolConvert.ToInt32(value.Substring(position + 13, 2)),
                    Unit = (DataUnitType)OpenProtocolConvert.ToInt32(value.Substring(position + 15, 3)),
                    TimeValue = value.Substring(position + HeaderSize, length)
                };

                position += totalSize;
            }
        }
    }
}





