using OpenProtocolInterpreter.Converters;
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
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<decimal> _decimalConverter;
        public const int MID = 301;

        public int ParameterSetId
        {
            get => GetField(1,(int)DataFields.ParameterSetId).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.ParameterSetId).SetValue(_intConverter.Convert, value);
        }
        public HistogramType HistogramType
        {
            get => (HistogramType)GetField(1,(int)DataFields.HistogramType).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.HistogramType).SetValue(_intConverter.Convert, (int)value);
        }
        public decimal SigmaHistogram
        {
            get => GetField(1,(int)DataFields.SigmaHistogram).GetValue(_decimalConverter.Convert);
            set => GetField(1,(int)DataFields.SigmaHistogram).SetValue(_decimalConverter.Convert, value);
        }
        public decimal MeanValueHistogram
        {
            get => GetField(1,(int)DataFields.MeanValueHistogram).GetValue(_decimalConverter.Convert);
            set => GetField(1,(int)DataFields.MeanValueHistogram).SetValue(_decimalConverter.Convert, value);
        }
        public decimal ClassRange
        {
            get => GetField(1,(int)DataFields.ClassRange).GetValue(_decimalConverter.Convert);
            set => GetField(1,(int)DataFields.ClassRange).SetValue(_decimalConverter.Convert, value);
        }
        public int FirstBar
        {
            get => GetField(1,(int)DataFields.Bar1).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.Bar1).SetValue(_intConverter.Convert, value);
        }
        public int SecondBar
        {
            get => GetField(1,(int)DataFields.Bar2).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.Bar2).SetValue(_intConverter.Convert, value);
        }
        public int ThirdBar
        {
            get => GetField(1,(int)DataFields.Bar3).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.Bar3).SetValue(_intConverter.Convert, value);
        }
        public int FourthBar
        {
            get => GetField(1,(int)DataFields.Bar4).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.Bar4).SetValue(_intConverter.Convert, value);
        }
        public int FifthBar
        {
            get => GetField(1,(int)DataFields.Bar5).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.Bar5).SetValue(_intConverter.Convert, value);
        }
        public int SixthBar
        {
            get => GetField(1,(int)DataFields.Bar6).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.Bar6).SetValue(_intConverter.Convert, value);
        }
        public int SeventhBar
        {
            get => GetField(1,(int)DataFields.Bar7).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.Bar7).SetValue(_intConverter.Convert, value);
        }
        public int EighthBar
        {
            get => GetField(1,(int)DataFields.Bar8).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.Bar8).SetValue(_intConverter.Convert, value);
        }
        public int NinethBar
        {
            get => GetField(1,(int)DataFields.Bar9).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.Bar9).SetValue(_intConverter.Convert, value);
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
            _intConverter = new Int32Converter();
            _decimalConverter = new DecimalTrucatedConverter(2);
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.ParameterSetId, 20, 3, '0', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.HistogramType, 25, 2, '0', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.SigmaHistogram, 29, 6, '0', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.MeanValueHistogram, 37, 6, '0', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.ClassRange, 45, 6, '0', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.Bar1, 53, 4, '0', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.Bar2, 59, 4, '0', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.Bar3, 65, 4, '0', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.Bar4, 71, 4, '0', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.Bar5, 77, 4, '0', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.Bar6, 83, 4, '0', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.Bar7, 89, 4, '0', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.Bar8, 95, 4, '0', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.Bar9, 101, 4, '0', DataField.PaddingOrientations.LeftPadded)
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
