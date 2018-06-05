using System.Collections.Generic;

namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// MID: User data download
    /// Description: 
    ///     Used by the integrator to send user data input to the PLC.
    /// Message sent by: Controller
    /// Answer: MID 0243 User data acknowledge
    /// </summary>
    public class MID_0242 : Mid, IPLCUserData
    {
        private const int LAST_REVISION = 1;
        public const int MID = 242;

        public string UserData
        {
            get => GetField(1,(int)DataFields.USER_DATA).Value;
            set => GetField(1,(int)DataFields.USER_DATA).SetValue(value);
        }

        public MID_0242(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag) { }

        public MID_0242(string userData, int? noAckFlag = 0) : this(noAckFlag)
        {
            UserData = userData;
        }

        internal MID_0242(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

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
                GetField(1,(int)DataFields.USER_DATA).Size = HeaderData.Length - 20;
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
                        new DataField((int)DataFields.USER_DATA, 20, 200, ' ', DataField.PaddingOrientations.RIGHT_PADDED, false)
                    }
                }
            };
        }

        internal enum DataFields
        {
            USER_DATA
        }
    }
}
