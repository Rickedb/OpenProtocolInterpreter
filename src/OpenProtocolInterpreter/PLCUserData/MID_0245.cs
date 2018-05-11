using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private const int length = 223;
        public const int MID = 255;
        private const int revision = 1;

        public int Offset { get; set; }
        public string UserData { get; set; }

        public MID_0245() : base(length, MID, revision) { }

        internal MID_0245(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            HeaderData.Length = 23 + UserData.Length;

            string package = BuildHeader();
            package += Offset.ToString().PadLeft(base.RegisteredDataFields[(int)DataFields.OFFSET].Size, '0');
            package += UserData;

            return package;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
            {
                Offset = Convert.ToInt32(package.Substring(base.RegisteredDataFields[(int)DataFields.OFFSET].Index, base.RegisteredDataFields[(int)DataFields.OFFSET].Size));
                UserData = package.Substring(base.RegisteredDataFields[(int)DataFields.USER_DATA].Index);
                return this;
            }

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.OFFSET, 20, 3));
            this.RegisteredDataFields.Add(new DataField((int)DataFields.USER_DATA, 23, 220));
        }

        internal enum DataFields
        {
            OFFSET,
            USER_DATA
        }
    }
}
