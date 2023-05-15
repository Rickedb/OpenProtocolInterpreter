using System;
using System.Collections.Generic;
using System.Linq;

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

        public string VinNumber
        {
            get => GetField(1, (int)DataFields.VIN_NUMBER).Value;
            set => GetField(1, (int)DataFields.VIN_NUMBER).SetValue(value);
        }
        public string IdentifierResultPart2
        {
            get => GetField(2, (int)DataFields.IDENTIFIER_RESULT_PART2).Value;
            set => GetField(2, (int)DataFields.IDENTIFIER_RESULT_PART2).SetValue(value);
        }
        public string IdentifierResultPart3
        {
            get => GetField(2, (int)DataFields.IDENTIFIER_RESULT_PART3).Value;
            set => GetField(2, (int)DataFields.IDENTIFIER_RESULT_PART3).SetValue(value);
        }
        public string IdentifierResultPart4
        {
            get => GetField(2, (int)DataFields.IDENTIFIER_RESULT_PART4).Value;
            set => GetField(2, (int)DataFields.IDENTIFIER_RESULT_PART4).SetValue(value);
        }

        public Mid0052() : this(DEFAULT_REVISION)
        {

        }

        public Mid0052(Header header) : base(header)
        {
        }

        public Mid0052(int revision) : base(MID, revision) { }

        public override string Pack()
        {
            var vinNumberField = GetField(1, (int)DataFields.VIN_NUMBER);
            if (Header.Revision > 1)
                vinNumberField.HasPrefix = true;

            //Can be up to 40 bytes long
            vinNumberField.Size = (VinNumber.Length > 25) ? VinNumber.Length : 25;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            if (Header.Revision > 1)
            {
                var vinNumberField = GetField(1, (int)DataFields.VIN_NUMBER);
                vinNumberField.HasPrefix = true;
                vinNumberField.Size = Header.Length - 103;
                if (vinNumberField.Size > 25)
                {
                    int addedSize = vinNumberField.Size - 25;
                    GetField(2, (int)DataFields.IDENTIFIER_RESULT_PART2).Index += addedSize;
                    GetField(2, (int)DataFields.IDENTIFIER_RESULT_PART3).Index += addedSize;
                    GetField(2, (int)DataFields.IDENTIFIER_RESULT_PART4).Index += addedSize;
                }
            }
            else
                GetField(1, (int)DataFields.VIN_NUMBER).Size = Header.Length - 20;
            ProcessDataFields(package);
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.VIN_NUMBER, 20, 25, ' ', DataField.PaddingOrientations.RIGHT_PADDED, false)
                            }
                },
                {
                    2, new List<DataField>()
                            {
                                new DataField((int)DataFields.IDENTIFIER_RESULT_PART2, 47, 25, ' '),
                                new DataField((int)DataFields.IDENTIFIER_RESULT_PART3, 74, 25, ' '),
                                new DataField((int)DataFields.IDENTIFIER_RESULT_PART4, 101, 25, ' ')
                            }
                }
            };
        }

        protected enum DataFields
        {
            VIN_NUMBER,
            IDENTIFIER_RESULT_PART2,
            IDENTIFIER_RESULT_PART3,
            IDENTIFIER_RESULT_PART4,
        }
    }
}
