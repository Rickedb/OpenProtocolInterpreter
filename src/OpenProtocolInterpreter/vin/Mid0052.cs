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
    public class Mid0052 : Mid, IVin, IController
    {
        private const int LAST_REVISION = 2;
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

        public Mid0052() : this(LAST_REVISION)
        {

        }

        public Mid0052(int revision = LAST_REVISION) : base(MID, revision) { }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="vinNumber">The VIN number is 25 bytes long and is specified by 25 ASCII characters. 
        /// <para>
        /// Note! Only for PowerMACS and rev 000-001, the VIN number can be up to 40 bytes long.
        /// Minimum number of bytes is always 25.
        /// </para>
        /// </param>
        /// <param name="revision">Revision number (default = 1)</param>
        public Mid0052(string vinNumber, int revision = 1) : this(revision)
        {
            VinNumber = vinNumber;
        }

        /// <summary>
        /// Revision 2 Constructor
        /// </summary>
        /// <param name="vinNumber">The VIN number is 25 bytes long and is specified by 25 ASCII characters. 
        /// <para>
        /// Note! Only for PowerMACS and rev 000-001, the VIN number can be up to 40 bytes long.
        /// Minimum number of bytes is always 25.
        /// </para>
        /// </param>
        /// <param name="identifierResultPart2">The identifier result part 2 is 25 bytes long and is specified by 25 ASCII characters</param>
        /// <param name="identifierResultPart3">The identifier result part 3 is 25 bytes long and is specified by 25 ASCII characters</param>
        /// <param name="identifierResultPart4">The identifier result part 4 is 25 bytes long and is specified by 25 ASCII characters</param>
        /// <param name="revision">Revision number (default = 2)</param>
        public Mid0052(string vinNumber, string identifierResultPart2, string identifierResultPart3,
            string identifierResultPart4, int revision = 2) : this(vinNumber, revision)
        {
            IdentifierResultPart2 = identifierResultPart2;
            IdentifierResultPart3 = identifierResultPart3;
            IdentifierResultPart4 = identifierResultPart4;
        }

        public override string Pack()
        {
            var vinNumberField = GetField(1, (int)DataFields.VIN_NUMBER);
            if (HeaderData.Revision > 1)
                vinNumberField.HasPrefix = true;

            //Can be up to 40 bytes long
            vinNumberField.Size = (VinNumber.Length > 25) ? VinNumber.Length : 25;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            HeaderData = ProcessHeader(package);
            if (HeaderData.Revision > 1)
            {
                var vinNumberField = GetField(1, (int)DataFields.VIN_NUMBER);
                vinNumberField.HasPrefix = true;
                vinNumberField.Size = package.Length - 103;
                if (vinNumberField.Size > 25)
                {
                    int addedSize = vinNumberField.Size - 25;
                    GetField(2, (int)DataFields.IDENTIFIER_RESULT_PART2).Index += addedSize;
                    GetField(2, (int)DataFields.IDENTIFIER_RESULT_PART3).Index += addedSize;
                    GetField(2, (int)DataFields.IDENTIFIER_RESULT_PART4).Index += addedSize;
                }
            }
            else
                GetField(1, (int)DataFields.VIN_NUMBER).Size = package.Length - 20;
            ProcessDataFields(package);
            return this;
        }

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            List<string> failed = new List<string>();

            if (HeaderData.Revision == 1)
            {
                if (VinNumber.Length > 45)
                    failed.Add(new ArgumentOutOfRangeException(nameof(VinNumber), "Max of 45 characters").Message);
            }
            else
            {
                if (VinNumber.Length > 25)
                    failed.Add(new ArgumentOutOfRangeException(nameof(VinNumber), "Max of 25 characters").Message);
                if (IdentifierResultPart2.Length > 25)
                    failed.Add(new ArgumentOutOfRangeException(nameof(IdentifierResultPart2), "Max of 25 characters").Message);
                if (IdentifierResultPart3.Length > 25)
                    failed.Add(new ArgumentOutOfRangeException(nameof(IdentifierResultPart3), "Max of 25 characters").Message);
                if (IdentifierResultPart4.Length > 25)
                    failed.Add(new ArgumentOutOfRangeException(nameof(IdentifierResultPart4), "Max of 25 characters").Message);
            }

            errors = failed;
            return errors.Any();
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

        public enum DataFields
        {
            VIN_NUMBER,
            IDENTIFIER_RESULT_PART2,
            IDENTIFIER_RESULT_PART3,
            IDENTIFIER_RESULT_PART4,
        }
    }
}
