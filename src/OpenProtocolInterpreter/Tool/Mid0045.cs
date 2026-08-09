using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Set calibration value request
    /// <para>
    ///     This message is sent by the integrator in order to set the calibration value of the tool.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///             <see cref="Communication.Mid0004"/> Command error, Calibration failed
    /// </para>
    /// </summary>
    public class Mid0045 : Mid, ITool, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 45;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.CalibrationFailed };

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 1)]
        public CalibrationUnit CalibrationValueUnit { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 2, Index = 23, Size = 6)]
        public decimal CalibrationValue { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 3, Index = 31, Size = 2)]
        public int ChannelNumber { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 3, field: 4, Index = 35, Size = 10, DecimalPoints = 4)]
        public decimal ExtendedCalibrationValue { get; set; }

        [Int32DataFieldDefinition(revision: 3, field: 5, Index = 47, Size = 1)]
        public int TransducerNumber { get; set; }

        public Mid0045() : this(DEFAULT_REVISION)
        {
        }

        public Mid0045(Header header) : base(header)
        {
        }

        public Mid0045(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }
    }
}
