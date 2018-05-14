using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Statistic
{
    /// <summary>
    /// MID: Histogram upload request
    /// Description: 
    ///    Request to upload a histogram from the controller for a certain parameter set.
    ///    The histogram is calculated with all the tightening results currently present in 
    ///    the controller’s memory and within the statistic acceptance window(statistic min and max limits) 
    ///    for the requested parameter set.
    /// Message sent by: Integrator
    /// Answer: MID 0301, Histogram upload reply, or 
    ///         MID 0004 Command error, No histogram available or Invalid data
    /// </summary>
    public class MID_0300 : Mid, IStatistic
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 300;

        public int ParameterSetID
        {
            get => RevisionsByFields[1][(int)DataFields.PARAMETER_SET_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.PARAMETER_SET_ID].SetValue(_intConverter.Convert, value);
        }
        public HistogramType HistogramType
        {
            get => (HistogramType)RevisionsByFields[1][(int)DataFields.HISTOGRAM_TYPE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.HISTOGRAM_TYPE].SetValue(_intConverter.Convert, (int)value);
        }

        public MID_0300() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
        }

        internal MID_0300(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.HISTOGRAM_TYPE, 25, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
                    }
                }
            };
        }      

        public enum DataFields
        {
            PARAMETER_SET_ID,
            HISTOGRAM_TYPE
        }
    }
}
