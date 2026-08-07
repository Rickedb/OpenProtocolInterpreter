using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Tightening Result List Upload
    /// <para>This message contains a list of tightening results stored in the controller. The result list is sorted ascendingly on result index, and contains a brief summary of each result.</para>
    /// <para><see cref="Communication.Mid0006"/> shall be used for fetching this message</para>
    /// <para>For full results data, request upload of <see cref="Result.Mid1201"/></para>
    /// </summary>
    public class Mid0067 : Mid, ITightening, IController
    {
        public const int MID = 67;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 2, HasPrefix = false)]
        public int NumberOfResults { get; set; }

        [ResultDataCollectionDefinition(revision: 1, field: 2, Index = 22, Size = 0, HasPrefix = false)]
        public List<ResultData> Results { get; set; } = new List<ResultData>();

        public Mid0067() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0067(Header header) : base(header)
        {
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 2) //Results
            {
                dataField.Size = NumberOfResults * 30;
            }

            base.ProcessDataField(dataField, package);
        }

        public override string Pack()
        {
            NumberOfResults = Results?.Count ?? 0; //Enforce list size even if modified
            GetField(nameof(Results)).Size = NumberOfResults * 30;
            return base.Pack();
        }
    }

    public class Mid0067ExtraData : ExtraData, IExtraDataRequest
    {
        public override int Mid => Mid0067.MID;

        [Int64DataFieldDefinition(revision: 1, field: 1, Index = 0, Size = 10, HasPrefix = false)]
        public long StartIndex { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 10, Size = 3, HasPrefix = false)]
        public int Count { get; set; }
    }
}
