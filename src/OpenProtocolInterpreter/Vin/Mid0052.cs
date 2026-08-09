using System;
using System.Collections.Generic;
using System.Text;

namespace OpenProtocolInterpreter.Vin
{
    /// <summary>
    /// Vehicle ID Number
    /// <para>Transmission of the current identifiers of the tightening by the controller to the subscriber.</para>
    /// <para>The tightening result can be stamped with up to four identifiers:</para>
    /// <list type="bullet">
    ///     <item>VIN number (identifier result part 1)</item>
    ///     <item>Identifier result part 2</item>
    ///     <item>Identifier result part 3</item>
    ///     <item>Identifier result part 4</item>
    /// </list>
    /// <para>
    ///     The identifiers are received by the controller from several input sources,
    ///     for example serial, Ethernet, or field bus.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0053"/> Vehicle ID Number acknowledge</para>
    /// </summary>
    public class Mid0052 : Mid, IVin, IController, IAcknowledgeable<Mid0053>
    {
        public const int MID = 52;

        /// <summary>
        /// Note: Only for PowerMACS and rev 000-001, the VIN number can be up to 40 bytes long. Minimum number of bytes is always 25.
        /// </summary>
        [StringDataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 25, HasPrefix = false)]
        [StringDataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 25)]
        public string VinNumber { get; set; }

        [StringDataFieldDefinition(revision: 2, field: 2, Index = 47, Size = 25)]
        public string IdentifierResultPart2 { get; set; }

        [StringDataFieldDefinition(revision: 2, field: 3, Index = 74, Size = 25)]
        public string IdentifierResultPart3 { get; set; }

        [StringDataFieldDefinition(revision: 2, field: 4, Index = 101, Size = 25)]
        public string IdentifierResultPart4 { get; set; }

        public Mid0052() : this(DEFAULT_REVISION)
        {

        }

        public Mid0052(Header header) : base(header)
        {
        }

        public Mid0052(int revision) : base(MID, revision) { }

        protected override string BuildHeader()
        {
            Header.Length = Header.DefaultSize;
            foreach (var dataField in DataFieldsByRevision())
                Header.Length += dataField.TotalSize;

            return Header.ToString();
        }

        public override string Pack()
        {
            if (Header.StandardizedRevision == 1)
                GetField(nameof(VinNumber)).Size = (VinNumber.Length > 25) ? VinNumber.Length : 25;

            var header = BuildHeader();
            var builder = new StringBuilder(Header.Length).Append(header).Append(base.Pack(DataFieldsByRevision()));
            return builder.ToString();
        }

        protected override void ProcessDataFields(ReadOnlySpan<char> package)
            => base.ProcessDataFields(DataFieldsByRevision(), package);

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (Header.StandardizedRevision == 1 && dataField.Field == 1)
                dataField.Size = Header.Length - Header.DefaultSize;

            base.ProcessDataField(dataField, package);
        }

        private IEnumerable<DataField> DataFieldsByRevision()
        {
            foreach (var dataField in RevisionsByFields[Header.StandardizedRevision])
                yield return dataField;
        }
    }
}
