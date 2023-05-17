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
        public const int MID = 6;

        public string RequestedMid
        {
            get => GetField(1, (int)DataFields.RequestedMid).Value;
            set => GetField(1, (int)DataFields.RequestedMid).SetValue(value);
        }
        public int WantedRevision
        {
            get => GetField(1, (int)DataFields.WantedRevision).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.WantedRevision).SetValue(_intConverter.Convert, value);
        }
        public int ExtraDataLength
        {
            get => GetField(1, (int)DataFields.ExtraDataLength).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.ExtraDataLength).SetValue(_intConverter.Convert, value);
        }
        public string ExtraData
        {
            get => GetField(1, (int)DataFields.ExtraData).Value;
            set => GetField(1, (int)DataFields.ExtraData).SetValue(value);
        }

        public Mid0006() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {
            
        }

        public Mid0006(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            GetField(1, (int)DataFields.ExtraData).Size = Header.Length - 29;
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
                                new DataField((int)DataFields.RequestedMid, 20, 4, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.WantedRevision, 24, 3, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.ExtraDataLength, 27, 2, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.ExtraData, 29, 0, ' ', DataField.PaddingOrientations.RightPadded, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            RequestedMid,
            WantedRevision,
            ExtraDataLength,
            ExtraData
        }
    }
}