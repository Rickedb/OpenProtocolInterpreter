﻿using System.Collections.Generic;

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
    public class Mid0240 : Mid, IPLCUserData, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 240;

        public string UserData
        {
            get => GetField(1, (int)DataFields.USER_DATA).Value;
            set => GetField(1, (int)DataFields.USER_DATA).SetValue(value);
        }

        public Mid0240() : base(MID, LAST_REVISION) { }

        public Mid0240(Header header) : base(header)
        {
        }

        public Mid0240(string userData) : this()
        {
            UserData = userData;
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.USER_DATA).Size = UserData.Length;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            GetField(1, (int)DataFields.USER_DATA).Size = package.Length - 20;
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
