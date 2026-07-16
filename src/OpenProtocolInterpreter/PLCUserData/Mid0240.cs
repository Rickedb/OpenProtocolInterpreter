using System;
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

        [StringDataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 200, HasPrefix = false)]
        public string UserData { get; set; }

        public Mid0240() : base(MID, DEFAULT_REVISION) { }

        public Mid0240(Header header) : base(header)
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
