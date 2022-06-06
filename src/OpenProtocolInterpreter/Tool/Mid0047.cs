﻿using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Tool Pairing handling
    /// <para>
    ///     This message is sent by the integrator in order to Pair tools, to abort ongoing pairing, 
    ///     to Abort/Disconnect established connection and request for pairing status of the IRC-B or IRC-W tool types.
    ///     At pairing handling type, Start Pairing and Pairing Abort or Disconnect the controller must take program control 
    ///     and release when finished. MID 0048 will be uploaded during the pairing process at each change of the pairing stage.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: </para>
    /// <para><see cref="Communication.Mid0005"/> Command accepted at pairing status ACCEPTED</para>
    /// <para><see cref="Communication.Mid0004"/> Command error. See error codes. </para>
    /// <para><see cref="Mid0048"/> Pairing status during the pairing process</para>
    /// </summary>
    public class Mid0047 : Mid, ITool, IIntegrator
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 47;
        
        public PairingHandlingType PairingHandlingType
        {
            get => (PairingHandlingType)GetField(1,(int)DataFields.PAIRING_HANDLING_TYPE).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.PAIRING_HANDLING_TYPE).SetValue(_intConverter.Convert, (int)value);
        }

        public Mid0047() : this(new Header()
        {
            Mid = MID, 
            Revision = LAST_REVISION
        })
        {
        }

        public Mid0047(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.PAIRING_HANDLING_TYPE, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                }
            };
        }

        public enum DataFields
        {
            PAIRING_HANDLING_TYPE
        }
    }
}
