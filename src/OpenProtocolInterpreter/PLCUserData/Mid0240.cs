using System.Collections.Generic;

namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// User data download
    /// <para>Used by the integrator to send user data input to the PLC.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///         <see cref="Communication.Mid0004"/> Command error, Invalid data, or Controller is not a sync master/station controller
    /// </para>
    /// </summary>
    public class Mid0240 : Mid, IPLCUserData, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 240;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.InvalidData, Error.ControllerIsNotASyncMasterOrStationController };

        public string UserData
        {
            get => GetField(1, DataFields.UserData).Value;
            set => GetField(1, DataFields.UserData).SetValue(value);
        }

        public Mid0240() : base(MID, DEFAULT_REVISION) { }

        public Mid0240(Header header) : base(header)
        {
        }

        public override string Pack()
        {
            var userDataField = GetField(1, DataFields.UserData);
            if (userDataField.Value.Length > 200)
            {
                userDataField.Value = userDataField.Value.Substring(0, 200);
            }

            userDataField.Size = userDataField.Value.Length;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            GetField(1, DataFields.UserData).Size = Header.Length - 20;
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
                        DataField.Volatile(DataFields.UserData, 20, false)
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
