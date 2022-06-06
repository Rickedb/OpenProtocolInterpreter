﻿using OpenProtocolInterpreter.Converters;
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
        private const int LAST_REVISION = 1;
        public const int MID = 301;

        public int ParameterSetId
        {
            get => GetField(1,(int)DataFields.PARAMETER_SET_ID).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.PARAMETER_SET_ID).SetValue(_intConverter.Convert, value);
        }
        public HistogramType HistogramType
        {
            get => (HistogramType)GetField(1,(int)DataFields.HISTOGRAM_TYPE).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.HISTOGRAM_TYPE).SetValue(_intConverter.Convert, (int)value);
        }
        public decimal SigmaHistogram
        {
            get => GetField(1,(int)DataFields.SIGMA_HISTOGRAM).GetValue(_decimalConverter.Convert);
            set => GetField(1,(int)DataFields.SIGMA_HISTOGRAM).SetValue(_decimalConverter.Convert, value);
        }
        public decimal MeanValueHistogram
        {
            get => GetField(1,(int)DataFields.MEAN_VALUE_HISTOGRAM).GetValue(_decimalConverter.Convert);
            set => GetField(1,(int)DataFields.MEAN_VALUE_HISTOGRAM).SetValue(_decimalConverter.Convert, value);
        }
        public decimal ClassRange
        {
            get => GetField(1,(int)DataFields.CLASS_RANGE).GetValue(_decimalConverter.Convert);
            set => GetField(1,(int)DataFields.CLASS_RANGE).SetValue(_decimalConverter.Convert, value);
        }
        public int FirstBar
        {
            get => GetField(1,(int)DataFields.BAR_1).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.BAR_1).SetValue(_intConverter.Convert, value);
        }
        public int SecondBar
        {
            get => GetField(1,(int)DataFields.BAR_2).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.BAR_2).SetValue(_intConverter.Convert, value);
        }
        public int ThirdBar
        {
            get => GetField(1,(int)DataFields.BAR_3).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.BAR_3).SetValue(_intConverter.Convert, value);
        }
        public int FourthBar
        {
            get => GetField(1,(int)DataFields.BAR_4).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.BAR_4).SetValue(_intConverter.Convert, value);
        }
        public int FifthBar
        {
            get => GetField(1,(int)DataFields.BAR_5).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.BAR_5).SetValue(_intConverter.Convert, value);
        }
        public int SixthBar
        {
            get => GetField(1,(int)DataFields.BAR_6).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.BAR_6).SetValue(_intConverter.Convert, value);
        }
        public int SeventhBar
        {
            get => GetField(1,(int)DataFields.BAR_7).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.BAR_7).SetValue(_intConverter.Convert, value);
        }
        public int EighthBar
        {
            get => GetField(1,(int)DataFields.BAR_8).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.BAR_8).SetValue(_intConverter.Convert, value);
        }
        public int NinethBar
        {
            get => GetField(1,(int)DataFields.BAR_9).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.BAR_9).SetValue(_intConverter.Convert, value);
        }

        public Mid0301() : this(new Header()
        {
            Mid = MID, 
            Revision = LAST_REVISION
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
                        new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.HISTOGRAM_TYPE, 25, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.SIGMA_HISTOGRAM, 29, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.MEAN_VALUE_HISTOGRAM, 37, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.CLASS_RANGE, 45, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.BAR_1, 53, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.BAR_2, 59, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.BAR_3, 65, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.BAR_4, 71, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.BAR_5, 77, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.BAR_6, 83, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.BAR_7, 89, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.BAR_8, 95, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.BAR_9, 101, 4, '0', DataField.PaddingOrientations.LEFT_PADDED)
                    }
                }
            };
        }

        public enum DataFields
        {
            PARAMETER_SET_ID,
            HISTOGRAM_TYPE,
            SIGMA_HISTOGRAM,
            /// <summary>
            /// X-BAR
            /// </summary>
            MEAN_VALUE_HISTOGRAM,
            CLASS_RANGE,
            BAR_1,
            BAR_2,
            BAR_3,
            BAR_4,
            BAR_5,
            BAR_6,
            BAR_7,
            BAR_8,
            BAR_9
        }
    }
}
