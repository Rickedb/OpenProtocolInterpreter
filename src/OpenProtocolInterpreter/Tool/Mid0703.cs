using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Set calibration value request with generic data
    /// <para>
    ///     This message is sent by the integrator in order to set the calibration value of the tool.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///             <see cref="Communication.Mid0004"/> Command error, with code Calibration failed
    /// </para>
    /// </summary>
    public class Mid0703 : Mid, ITool, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 703;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.CalibrationFailed };

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 4)]
        public int ToolNumber { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 26, Size = 2, HasPrefix = false)]
        public int NumberOfCalibrationParameters { get; set; }

        [VariableDataFieldCollectionDefinition(revision: 1, field: 3, Index = 28, Size = 0, HasPrefix = false)]
        public List<VariableDataField> CalibrationParameters { get; set; }

        public Mid0703() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0703(Header header) : base(header)
        {
            CalibrationParameters = [];
        }

        public override string Pack()
        {
            NumberOfCalibrationParameters = CalibrationParameters?.Count ?? 0; //Enforce list size even if modified
            GetField(revision: 1, field: 3).Size = CalibrationParameters?.Sum(x => x.TotalSize) ?? 0; //Enforce size of variable data fields
            return base.Pack();
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 3) //CalibrationParameters
            {
                dataField.Size = Header.Length - dataField.Index;
            }
            base.ProcessDataField(dataField, package);
        }
    }
}
