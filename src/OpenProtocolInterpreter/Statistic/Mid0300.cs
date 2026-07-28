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

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 3)]
        public int ParameterSetId { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 25, Size = 2)]
        public HistogramType HistogramType { get; set; }

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
    }
}
