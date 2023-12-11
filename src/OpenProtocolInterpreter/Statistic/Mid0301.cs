using System.Collections.Generic;

namespace OpenProtocolInterpreter.Statistic
{
    /// <summary>
    /// Histogram upload reply
    /// <para>
    ///    Histogram upload reply for the requested parameter set and for the requested histogram type. The
    ///    histogram uploaded is made of 9 bars according to Figure 22 Histogram example.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0301 : Mid, IStatistic, IController
    {
        public const int MID = 301;

        public int ParameterSetId
        {
            get => GetField(1, DataFields.ParameterSetId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.ParameterSetId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public HistogramType HistogramType
        {
            get => (HistogramType)GetField(1, DataFields.HistogramType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.HistogramType).SetValue(OpenProtocolConvert.ToString, value);
        }
        public decimal SigmaHistogram
        {
            get => GetField(1, DataFields.SigmaHistogram).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1, DataFields.SigmaHistogram).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal MeanValueHistogram
        {
            get => GetField(1, DataFields.MeanValueHistogram).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1, DataFields.MeanValueHistogram).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal ClassRange
        {
            get => GetField(1, DataFields.ClassRange).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1, DataFields.ClassRange).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public int FirstBar
        {
            get => GetField(1, DataFields.Bar1).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Bar1).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int SecondBar
        {
            get => GetField(1, DataFields.Bar2).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Bar2).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int ThirdBar
        {
            get => GetField(1, DataFields.Bar3).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Bar3).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int FourthBar
        {
            get => GetField(1, DataFields.Bar4).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Bar4).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int FifthBar
        {
            get => GetField(1, DataFields.Bar5).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Bar5).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int SixthBar
        {
            get => GetField(1, DataFields.Bar6).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Bar6).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int SeventhBar
        {
            get => GetField(1, DataFields.Bar7).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Bar7).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int EighthBar
        {
            get => GetField(1, DataFields.Bar8).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Bar8).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int NinethBar
        {
            get => GetField(1, DataFields.Bar9).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Bar9).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0301() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0301(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        DataField.Number(DataFields.ParameterSetId, 20, 3),
                        DataField.Number(DataFields.HistogramType, 25, 2),
                        DataField.Number(DataFields.SigmaHistogram, 29, 6),
                        DataField.Number(DataFields.MeanValueHistogram, 37, 6),
                        DataField.Number(DataFields.ClassRange, 45, 6),
                        DataField.Number(DataFields.Bar1, 53, 4),
                        DataField.Number(DataFields.Bar2, 59, 4),
                        DataField.Number(DataFields.Bar3, 65, 4),
                        DataField.Number(DataFields.Bar4, 71, 4),
                        DataField.Number(DataFields.Bar5, 77, 4),
                        DataField.Number(DataFields.Bar6, 83, 4),
                        DataField.Number(DataFields.Bar7, 89, 4),
                        DataField.Number(DataFields.Bar8, 95, 4),
                        DataField.Number(DataFields.Bar9, 101, 4)
                    }
                }
            };
        }

        protected enum DataFields
        {
            ParameterSetId,
            HistogramType,
            SigmaHistogram,
            /// <summary>
            /// X-BAR
            /// </summary>
            MeanValueHistogram,
            ClassRange,
            Bar1,
            Bar2,
            Bar3,
            Bar4,
            Bar5,
            Bar6,
            Bar7,
            Bar8,
            Bar9
        }
    }
}
