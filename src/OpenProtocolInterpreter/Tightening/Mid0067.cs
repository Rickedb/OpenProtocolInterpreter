using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// This message contains a list of tightening results stored in the controller. The result list is sorted ascendingly on result index, and contains a brief summary of each result.
    /// <para><see cref="Communication.Mid0006"/> Application Data Message Request shall be used for fetching this message</para>
    /// <para>For full results data, request upload of <see cref="Mid1201"/></para>
    /// </summary>
    public class Mid0067 : Mid, ITightening, IController, IApplicationDataMessageRequest
    {
        public const int MID = 67;

        public int NumberOfResults
        {
            get => GetField(1, DataFields.NumberOfResults).GetValue(OpenProtocolConvert.ToInt32);
            private set => GetField(1, DataFields.NumberOfResults).SetValue(OpenProtocolConvert.ToString, value);
        }

        public List<TighteningSummary> ResultData { get; set; }

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

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.Number(DataFields.NumberOfResults, 20, 3, false),
                                DataField.Volatile(DataFields.ResultData, 23, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            NumberOfResults,
            ResultData
        }
    }
}
