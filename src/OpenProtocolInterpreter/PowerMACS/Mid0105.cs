using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// Last PowerMACS tightening result data subscribe
    /// <para>
    ///    Set the subscription for the rundowns result. The result of this command will be the transmission of
    ///    the rundown result after the tightening is performed(push function).
    /// </para>
    /// <para>
    ///    This telegram is also used for a PowerMACS 4000 system running a press instead of a spindle.A
    ///    press system only supports revision 4 and higher of the telegram and will answer with <see cref="Communication.Mid0004"/>,
    ///    MID revision unsupported if a subscription is made with a lower revision.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///         <see cref="Communication.Mid0004"/> Command error, Subscription already exists or MID revision unsupported
    /// </para>
    /// </summary>
    public class Mid0105 : Mid, IPowerMACS, IIntegrator
    {
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 4;
        public const int MID = 105;

        public int DataNumberSystem
        {
            get => GetField(2,(int)DataFields.DATA_NUMBER_SYSTEM).GetValue(_intConverter.Convert);
            set => GetField(2,(int)DataFields.DATA_NUMBER_SYSTEM).SetValue(_intConverter.Convert, value);
        }
        public bool SendOnlyNewData
        {
            get => GetField(3,(int)DataFields.SEND_ONLY_NEW_DATA).GetValue(_boolConverter.Convert);
            set => GetField(3,(int)DataFields.SEND_ONLY_NEW_DATA).SetValue(_boolConverter.Convert, value);
        }

        public Mid0105() : this(LAST_REVISION)
        {

        }

        public Mid0105(int revision = LAST_REVISION, int? noAckFlag = 0) : base(MID, revision, noAckFlag)
        {
            _boolConverter = new BoolConverter();
            _intConverter = new Int32Converter();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                },
                {
                    2, new List<DataField>()
                            {
                                new DataField((int)DataFields.DATA_NUMBER_SYSTEM, 20, 10, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                            }
                },
                {
                    3, new List<DataField>()
                            {
                                new DataField((int)DataFields.SEND_ONLY_NEW_DATA, 30, 1, false)
                            }
                },
                {
                    4, new List<DataField>()
                },
            };
        }

        public enum DataFields
        {
            DATA_NUMBER_SYSTEM,
            SEND_ONLY_NEW_DATA
        }
    }
}
