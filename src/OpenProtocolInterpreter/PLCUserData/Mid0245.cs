using System.Collections.Generic;

namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// User data download with offset
    /// <para>
    ///     Used by the integrator to send user data input to the PLC. 
    ///     The difference compared to <see cref="Mid0240"/> User data download is that with this MID it is possible
    ///     to specify an offset for the data written in the PLC. This makes it possible to have more than 
    ///     one device writing user data to the PLC on different data areas.
    /// </para>
    /// <para>
    ///     The available address range in the PLC is still 13 000 – 13 099, i.e. 100 bytes. The offset parameter in
    ///     this MID specify the start address for the data in the PLC, i.e.the start address is 13 000 + Offset.
    ///     Since the highest address is still 13 099 this means the number of data bytes to send will be limited by
    ///     the offset. The maximum size of the user data will be (100 – offset) bytes, or 2 * (100 – offset) ASCII
    ///     characters in the telegram.
    /// </para>
    /// <para>
    ///     Only data that is sent in the user data field will be written to the PLC, the remaining data will 
    ///     be untouched.
    /// </para>
    /// <para>
    ///     This means for example that if the offset is 10 and the user data is 1234 the bytes with
    ///     address 13010 and 13011 will be updated (to 0x12 and 0x34) and the rest of the area will be
    ///     unchanged.
    /// </para>    
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///             <see cref="Communication.Mid0004"/> Command error, Invalid data, or
    ///                 Controller is not a sync master/station controller or
    ///                 MID revision not supported.
    /// </para>
    /// </summary>
    public class Mid0245 : Mid, IPLCUserData, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 245;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[]
        {
            Error.InvalidData,
            Error.ControllerIsNotASyncMasterOrStationController,
            Error.MidRevisionUnsupported
        };

        public int Offset
        {
            get => GetField(1, DataFields.Offset).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Offset).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string UserData
        {
            get => GetField(1, DataFields.UserData).Value;
            set => GetField(1, DataFields.UserData).SetValue(value);
        }

        public Mid0245() : this(DEFAULT_REVISION)
        {
        }

        public Mid0245(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        public Mid0245(Header header) : base(header)
        {

        }

        public override string Pack()
        {
            var userDataField = GetField(1, DataFields.UserData);
            if (string.IsNullOrEmpty(userDataField.Value))
            {
                userDataField.Value = "  ";
            }
            else if (userDataField.Value.Length > 200)
            {
                userDataField.Value = userDataField.Value.Substring(0, 200);
            }

            userDataField.Size = userDataField.Value.Length;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            GetField(1, DataFields.UserData).Size = Header.Length - 23;
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
                        DataField.Number(DataFields.Offset, 20, 3, false),
                        DataField.Volatile(DataFields.UserData, 23, false)
                    }
                }
            };
        }

        internal enum DataFields
        {
            Offset,
            UserData
        }
    }
}
