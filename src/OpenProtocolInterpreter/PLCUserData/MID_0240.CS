using System.Collections.Generic;

namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// MID: User data download
    /// Description: 
    ///     Used by the integrator to send user data input to the PLC.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Invalid data, or Controller is not a sync master/station controller
    /// </summary>
    public class MID_0240 : Mid 
    {
        private const int LAST_REVISION = 1;
        public const int MID = 240;

        public string UserData
        {
            get => RevisionsByFields[1][(int)DataFields.USER_DATA].Value;
            set => RevisionsByFields[1][(int)DataFields.USER_DATA].SetValue(value);
        }

        public MID_0240() : base(MID, LAST_REVISION) { }

        public MID_0240(string userData) : this()
        {
            UserData = userData;
        }

        internal MID_0240(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override string BuildPackage()
        {
            RevisionsByFields[1][(int)DataFields.USER_DATA].Size = 20 + UserData.Length;
            return base.BuildPackage();
        }

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);
                RevisionsByFields[1][(int)DataFields.USER_DATA].Size = HeaderData.Length - 20;
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
