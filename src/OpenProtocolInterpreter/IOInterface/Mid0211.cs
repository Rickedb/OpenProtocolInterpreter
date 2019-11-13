using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Status externally monitored inputs
    /// Description: 
    ///    Status for the eight externally monitored digital inputs. This message is sent to the subscriber every
    ///    time the status of at least one of the inputs has changed.
    /// Message sent by: Controller
    /// Answer: MID 0212 Status externally monitored inputs acknowledge
    /// </summary>
    public class Mid0211 : Mid, IIOInterface, IController
    {
        private readonly IValueConverter<bool> _boolConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 211;
        
        public bool StatusDigInOne
        {
            get => GetField(1,(int)DataFields.STATUS_DIG_IN_1).GetValue(_boolConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_DIG_IN_1).SetValue(_boolConverter.Convert, value);
        }
        public bool StatusDigInTwo
        {
            get => GetField(1,(int)DataFields.STATUS_DIG_IN_2).GetValue(_boolConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_DIG_IN_2).SetValue(_boolConverter.Convert, value);
        }
        public bool StatusDigInThree
        {
            get => GetField(1,(int)DataFields.STATUS_DIG_IN_3).GetValue(_boolConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_DIG_IN_3).SetValue(_boolConverter.Convert, value);
        }
        public bool StatusDigInFour
        {
            get => GetField(1,(int)DataFields.STATUS_DIG_IN_4).GetValue(_boolConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_DIG_IN_4).SetValue(_boolConverter.Convert, value);
        }
        public bool StatusDigInFive
        {
            get => GetField(1,(int)DataFields.STATUS_DIG_IN_5).GetValue(_boolConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_DIG_IN_5).SetValue(_boolConverter.Convert, value);
        }
        public bool StatusDigInSix
        {
            get => GetField(1,(int)DataFields.STATUS_DIG_IN_6).GetValue(_boolConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_DIG_IN_6).SetValue(_boolConverter.Convert, value);
        }
        public bool StatusDigInSeven
        {
            get => GetField(1,(int)DataFields.STATUS_DIG_IN_7).GetValue(_boolConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_DIG_IN_7).SetValue(_boolConverter.Convert, value);
        }
        public bool StatusDigInEight
        {
            get => GetField(1,(int)DataFields.STATUS_DIG_IN_8).GetValue(_boolConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_DIG_IN_8).SetValue(_boolConverter.Convert, value);
        }

        public Mid0211() : this(0)
        {

        }

        public Mid0211(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag)
        {
            _boolConverter = new BoolConverter();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.STATUS_DIG_IN_1, 20, 1, false),
                        new DataField((int)DataFields.STATUS_DIG_IN_2, 21, 1, false),
                        new DataField((int)DataFields.STATUS_DIG_IN_3, 22, 1, false),
                        new DataField((int)DataFields.STATUS_DIG_IN_4, 23, 1, false),
                        new DataField((int)DataFields.STATUS_DIG_IN_5, 24, 1, false),
                        new DataField((int)DataFields.STATUS_DIG_IN_6, 25, 1, false),
                        new DataField((int)DataFields.STATUS_DIG_IN_7, 26, 1, false),
                        new DataField((int)DataFields.STATUS_DIG_IN_8, 27, 1, false)
                    }
                }
            };
        }

        public enum DataFields
        {
            STATUS_DIG_IN_1,
            STATUS_DIG_IN_2,
            STATUS_DIG_IN_3,
            STATUS_DIG_IN_4,
            STATUS_DIG_IN_5,
            STATUS_DIG_IN_6,
            STATUS_DIG_IN_7,
            STATUS_DIG_IN_8
        }
    }
}
