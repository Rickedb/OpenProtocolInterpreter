using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// Application Communication positive acknowledge
    /// <para>
    ///     Do a request for data. This message is used for ALL request handling.
    ///     When used it substitutes the use of all MID special request messages.
    /// </para>    
    /// <para>
    ///     NOTE! The Header Revision field is the revision of the <see cref="Mid0006"/> itself NOT 
    ///     the revision of the data MID that is wanted to be uploaded.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: MID Requested for or <see cref="Mid0004"/> Command error. Error described at each MID description.</para>
    /// </summary>
    public class Mid0006 : Mid, ICommunication, IIntegrator
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 6;

        public string RequestedMid
        {
            get => GetField(1, (int)DataFields.REQUESTED_MID).Value;
            set => GetField(1, (int)DataFields.REQUESTED_MID).SetValue(value);
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

        public Mid0006() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
        }

        public Mid0006(string requestedMid, int wantedRevision, string extraData) : this()
        {
            RequestedMid = requestedMid;
            WantedRevision = wantedRevision;
            ExtraData = extraData;
            ExtraDataLength = ExtraData.Length;
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
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
                                new DataField((int)DataFields.REQUESTED_MID, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.WANTED_REVISION, 24, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.EXTRA_DATA_LENGTH, 27, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.EXTRA_DATA, 29, 0, ' ', DataField.PaddingOrientations.RIGHT_PADDED, false)
                            }
                }
            };
        }

        public enum DataFields
        {
            REQUESTED_MID,
            WANTED_REVISION,
            EXTRA_DATA_LENGTH,
            EXTRA_DATA
        }
    }
}