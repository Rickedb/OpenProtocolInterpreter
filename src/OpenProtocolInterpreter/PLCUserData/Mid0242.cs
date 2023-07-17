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

        public string UserData
        {
            get => GetField(1, (int)DataFields.UserData).Value;
            set => GetField(1, (int)DataFields.UserData).SetValue(value);
        }

        public Mid0242() : base(MID, DEFAULT_REVISION)
        {

        }

        public Mid0242(Header header) : base(header)
        {
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.UserData).Size = UserData.Length;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            GetField(1, (int)DataFields.UserData).Size = Header.Length - 20;
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
                        new DataField((int)DataFields.UserData, 20, 200, ' ', PaddingOrientation.RightPadded, false)
                    }
                }
            };
        }

        internal enum DataFields
        {
            UserData
        }
    }
}
