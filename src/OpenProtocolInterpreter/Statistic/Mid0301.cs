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

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 3)]
        public int ParameterSetId { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 25, Size = 2)]
        public HistogramType HistogramType { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 3, Index = 29, Size = 6)]
        public decimal SigmaHistogram { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 4, Index = 37, Size = 6)]
        public decimal MeanValueHistogram { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 5, Index = 45, Size = 6)]
        public decimal ClassRange { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 6, Index = 53, Size = 4)]
        public int FirstBar { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 7, Index = 59, Size = 4)]
        public int SecondBar { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 8, Index = 65, Size = 4)]
        public int ThirdBar { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 9, Index = 71, Size = 4)]
        public int FourthBar { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 10, Index = 77, Size = 4)]
        public int FifthBar { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 11, Index = 83, Size = 4)]
        public int SixthBar { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 12, Index = 89, Size = 4)]
        public int SeventhBar { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 13, Index = 95, Size = 4)]
        public int EighthBar { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 14, Index = 101, Size = 4)]
        public int NinethBar { get; set; }

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
    }
}
