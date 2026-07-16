using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// User data download
    /// <para>Used by the integrator to send user data input to the PLC.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0243"/> User data acknowledge</para>
    /// </summary>
    public class Mid0242 : Mid, IPLCUserData, IController, IAcknowledgeable<Mid0243>
    {
        public const int MID = 242;

        [StringDataFieldDefinition(revision: 1, field: 1, Index = 20, HasPrefix = false)]
        public string UserData { get; set; }

        public Mid0242() : base(MID, DEFAULT_REVISION)
        {

        }

        public Mid0242(Header header) : base(header)
        {
        }

        public override string Pack()
        {
            if (UserData.Length > 200)
            {
                UserData = UserData.SafeSubstring(0, 200);
            }

            GetField(revision: 1, field: 1).Size = UserData.Length; //Enforce size of user data
            return base.Pack();
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 1) //UserData
            {
                dataField.Size = Header.Length - dataField.Index;
            }
            base.ProcessDataField(dataField, package);
        }
    }
}
