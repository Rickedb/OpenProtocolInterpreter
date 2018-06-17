using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    /// <summary>
    /// MID: Open Protocol commands disabled
    /// Description: 
    ///     Upload the status of the Open Protocol commands disable digital input. 
    ///     The data upload consists of one byte delivering the digital input status. 
    ///     The status is uploaded each time the “Open Protocol commands disable” digital 
    ///     input changes (push function).
    /// Message sent by: Controller
    /// Answer: MID 0422 Open Protocol commands disabled acknowledge
    /// </summary>
    public class Mid0421 : Mid, IOpenProtocolCommandsDisabled
    {
        private readonly IValueConverter<bool> _boolConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 421;
        
        public bool DigitalInputStatus
        {
            get => GetField(1,(int)DataFields.DIGITAL_INPUT_STATUS).GetValue(_boolConverter.Convert);
            set => GetField(1,(int)DataFields.DIGITAL_INPUT_STATUS).SetValue(_boolConverter.Convert, value);
        }

        public Mid0421(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag)
        {
            _boolConverter = new BoolConverter();
        }

        public Mid0421(bool digitalInputStatus, int? noAckFlag = 0) : this(noAckFlag)
        {
            DigitalInputStatus = digitalInputStatus;
        }

        internal Mid0421(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.DIGITAL_INPUT_STATUS, 20, 1, false)
                            }
                }
            };
        }

        public enum DataFields
        {
            DIGITAL_INPUT_STATUS
        }
    }
}
