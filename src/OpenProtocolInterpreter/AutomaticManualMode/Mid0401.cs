using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// MID: Automatic/Manual mode
    /// Description: 
    ///     The operation mode in the controller has changed. 
    ///     The message includes the new operational mode of the controller.
    /// Message sent by: Controller
    /// Answer: MID 0402 Automatic/Manual mode acknowledge
    /// </summary>
    public class Mid0401 : Mid, IAutomaticManualMode
    {
        private readonly IValueConverter<bool> _boolConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 401;

        /// <summary>
        /// <para>Automatic Mode = false (0)</para>
        /// <para>Manual Mode = true (1)</para>
        /// </summary>
        public bool ManualAutomaticMode
        {
            get => GetField(1,(int)DataFields.MANUAL_AUTOMATIC_MODE).GetValue(_boolConverter.Convert);
            set => GetField(1,(int)DataFields.MANUAL_AUTOMATIC_MODE).SetValue(_boolConverter.Convert, value);
        }

        public Mid0401(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag)
        {
            _boolConverter = new BoolConverter();
        }

        public Mid0401(bool manualAutomaticMode, int? noAckFlag = 0) : this(noAckFlag)
        {
            ManualAutomaticMode = manualAutomaticMode;
        }

        internal Mid0401(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.MANUAL_AUTOMATIC_MODE, 20, 1, false)
                            }
                }
            };
        }

        public enum DataFields
        {
            MANUAL_AUTOMATIC_MODE
        }
    }
}
