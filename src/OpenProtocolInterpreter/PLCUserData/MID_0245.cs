using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// MID: User data download with offset
    /// Description: 
    ///     Used by the integrator to send user data input to the PLC. 
    ///     The difference compared to MID 0240 User data download is that with this MID it is possible
    ///     to specify an offset for the data written in the PLC. This makes it possible to have more than 
    ///     one device writing user data to the PLC on different data areas.
    ///     
    ///     The available address range in the PLC is still 13 000 – 13 099, i.e. 100 bytes. The offset parameter in
    ///     this MID specify the start address for the data in the PLC, i.e.the start address is 13 000 + Offset.
    ///     Since the highest address is still 13 099 this means the number of data bytes to send will be limited by
    ///     the offset. The maximum size of the user data will be (100 – offset) bytes, or 2 * (100 – offset) ASCII
    ///     characters in the telegram.
    ///     Only data that is sent in the user data field will be written to the PLC, the remaining data will 
    ///     be untouched.
    ///     This means for example that if the offset is 10 and the user data is 1234 the bytes with
    ///     address 13010 and 13011 will be updated (to 0x12 and 0x34) and the rest of the area will be
    ///     unchanged.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    /// MID 0004 Command error, Invalid data, or
    /// Controller is not a sync master/station controller or
    /// MID revision not supported.
    /// </summary>
    public class MID_0245 : Mid, IPLCUserData
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 245;

        public int Offset
        {
            get => GetField(1,(int)DataFields.USER_DATA).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.USER_DATA).SetValue(_intConverter.Convert, value);
        }
        public string UserData
        {
            get => GetField(1,(int)DataFields.USER_DATA).Value;
            set => GetField(1,(int)DataFields.USER_DATA).SetValue(value);
        }

        public MID_0245() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
        }

        public MID_0245(int offset, string userData) : this()
        {
            Offset = offset;
            UserData = userData;
        }

        internal MID_0245(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        

        public override string Pack()
        {
            GetField(1,(int)DataFields.USER_DATA).Size = 20 + UserData.Length;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);
                GetField(1,(int)DataFields.USER_DATA).Size = HeaderData.Length - 22;
                ProcessDataFields(package);
                return this;
            }

            return NextTemplate.Parse(package);
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.OFFSET, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                        new DataField((int)DataFields.USER_DATA, 23, 200, ' ', DataField.PaddingOrientations.RIGHT_PADDED, false)
                    }
                }
            };
        }

        internal enum DataFields
        {
            OFFSET,
            USER_DATA
        }
    }
}
