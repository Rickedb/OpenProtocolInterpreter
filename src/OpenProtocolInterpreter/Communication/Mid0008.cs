using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// MID: Application data message subscription
    /// Description: 
    ///     Start a subscription of data. This message is used for ALL subscription handling.
    ///     When used it substitutes the use of all MID special subscription messages.
    ///     NOTE! The Header Revision field is the revision of the MID 0008 itself NOT the revision of the data
    ///     MID that is wanted to be subscribed for.
    /// 
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted with the MID subscribed for or MID 0004 Command error, 
    ///         MID revision unsupported or Invalid data code and the MID subscribed for
    /// </summary>
    public class Mid0008 : Mid, ICommunication, IIntegrator
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 8;

        public string SubscriptionMid
        {
            get => GetField(1, (int)DataFields.SUBSCRIPTION_MID).Value;
            set => GetField(1, (int)DataFields.SUBSCRIPTION_MID).SetValue(value);
        }
        public int WantedRevision
        {
            get => GetField(1, (int)DataFields.WANTED_REVISION).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.WANTED_REVISION).SetValue(_intConverter.Convert, value);
        }
        public int ExtraDataLength
        {
            get => GetField(1, (int)DataFields.EXTRA_DATA_LENGTH).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.EXTRA_DATA_LENGTH).SetValue(_intConverter.Convert, value);
        }
        public string ExtraData
        {
            get => GetField(1, (int)DataFields.EXTRA_DATA).Value;
            set => GetField(1, (int)DataFields.EXTRA_DATA).SetValue(value);
        }

        public Mid0008() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
        }

        public Mid0008(string subscriptionMid, int wantedRevision, string extraData) : this()
        {
            SubscriptionMid = subscriptionMid;
            WantedRevision = wantedRevision;
            ExtraData = extraData;
            ExtraDataLength = ExtraData.Length;
        }

        public override Mid Parse(string package)
        {
            HeaderData = ProcessHeader(package);
            GetField(1, (int)DataFields.EXTRA_DATA).Size = package.Length - 29;
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
                                new DataField((int)DataFields.SUBSCRIPTION_MID, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.WANTED_REVISION, 24, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.EXTRA_DATA_LENGTH, 27, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.EXTRA_DATA, 29, 0, ' ', DataField.PaddingOrientations.RIGHT_PADDED, false)
                            }
                }
            };
        }

        public enum DataFields
        {
            SUBSCRIPTION_MID,
            WANTED_REVISION,
            EXTRA_DATA_LENGTH,
            EXTRA_DATA
        }
    }
}
