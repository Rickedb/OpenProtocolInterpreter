using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Vin
{
    /// <summary>
    /// MID: Vehicle ID Number
    /// Description: 
    ///     Transmission of the current identifiers of the tightening by the controller to the subscriber.
    ///     The tightening result can be stamped with up to four identifiers:
    ///         - VIN number(identifier result part 1)
    ///         - Identifier result part 2
    ///         - Identifier result part 3
    ///         - Identifier result part 4
    ///     The identifiers are received by the controller from several input sources,
    ///     for example serial, Ethernet, or field bus.
    /// Message sent by: Controller
    /// Answer: MID 0053 Vehicle ID Number acknowledge
    /// </summary>
    public class MID_0052 : Mid, IVin
    {
        private const int LAST_REVISION = 2;
        public const int MID = 52;

        public string VinNumber
        {
            get => RevisionsByFields[1][(int)DataFields.VIN_NUMBER].Value;
            set => RevisionsByFields[1][(int)DataFields.VIN_NUMBER].SetValue(value);
        }
        public string IdentifierResultPart2
        {
            get => RevisionsByFields[2][(int)DataFields.IDENTIFIER_RESULT_PART2].Value;
            set => RevisionsByFields[2][(int)DataFields.IDENTIFIER_RESULT_PART2].SetValue(value);
        }
        public string IdentifierResultPart3
        {
            get => RevisionsByFields[2][(int)DataFields.IDENTIFIER_RESULT_PART3].Value;
            set => RevisionsByFields[2][(int)DataFields.IDENTIFIER_RESULT_PART3].SetValue(value);
        }
        public string IdentifierResultPart4
        {
            get => RevisionsByFields[2][(int)DataFields.IDENTIFIER_RESULT_PART4].Value;
            set => RevisionsByFields[2][(int)DataFields.IDENTIFIER_RESULT_PART4].SetValue(value);
        }

        public MID_0052(int revision = LAST_REVISION) : base(MID, revision) { }

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
        public MID_0052(string vinNumber, int revision = 1) : this()
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
        public MID_0052(string vinNumber, string identifierResultPart2, string identifierResultPart3,
            string identifierResultPart4, int revision = 2) : this(vinNumber, revision)
        {
            IdentifierResultPart2 = identifierResultPart2;
            IdentifierResultPart3 = identifierResultPart3;
            IdentifierResultPart4 = identifierResultPart4;
        }

        internal MID_0052(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override string Pack()
        {
            if (HeaderData.Revision > 1)
                RevisionsByFields[1][(int)DataFields.VIN_NUMBER].HasPrefix = true;
            else //Can be up to 40 bytes long
                RevisionsByFields[1][(int)DataFields.VIN_NUMBER].Size = (VinNumber.Length > 25) ? VinNumber.Length : 25;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);
                if (HeaderData.Revision > 1)
                    RevisionsByFields[1][(int)DataFields.VIN_NUMBER].HasPrefix = true;
                else
                    RevisionsByFields[1][(int)DataFields.VIN_NUMBER].Size = package.Length - 20;
                ProcessDataFields(package);
                return this;
            }

            return NextTemplate.Parse(package);
        }

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            List<string> failed = new List<string>();

            if(HeaderData.Revision == 1)
            {
                if(VinNumber.Length > 45)
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
