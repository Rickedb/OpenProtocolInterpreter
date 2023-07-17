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
        public const int MID = 300;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.NoHistogramAvailable, Error.InvalidData };

        public int ParameterSetId
        {
            get => GetField(1,(int)DataFields.ParameterSetId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.ParameterSetId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public HistogramType HistogramType
        {
            get => (HistogramType)GetField(1,(int)DataFields.HistogramType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.HistogramType).SetValue(OpenProtocolConvert.ToString, (int)value);
        }

        public Mid0300() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0300(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.ParameterSetId, 20, 3, '0', PaddingOrientation.LeftPadded),
                        new DataField((int)DataFields.HistogramType, 25, 2, '0', PaddingOrientation.LeftPadded)
                    }
                }
            };
        }      

        protected enum DataFields
        {
            ParameterSetId,
            HistogramType
        }
    }
}
