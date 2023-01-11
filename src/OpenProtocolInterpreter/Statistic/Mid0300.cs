using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Statistic
{
    /// <summary>
    /// Histogram upload request
    /// <para>
    ///    Request to upload a histogram from the controller for a certain parameter set.
    ///    The histogram is calculated with all the tightening results currently present in 
    ///    the controller’s memory and within the statistic acceptance window(statistic min and max limits) 
    ///    for the requested parameter set.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Mid0301"/> Histogram upload reply, or 
    ///         <see cref="Communication.Mid0004"/> Command error, No histogram available or Invalid data
    /// </para>
    /// </summary>
    public class Mid0300 : Mid, IStatistic, IIntegrator, IAnswerableBy<Mid0301>, IDeclinableCommand
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 300;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.NO_HISTOGRAM_AVAILABLE, Error.INVALID_DATA };

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

        public Mid0300() : this(new Header()
        {
            Mid = MID, 
            Revision = LAST_REVISION
        })
        {
        }

        public Mid0300(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

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
