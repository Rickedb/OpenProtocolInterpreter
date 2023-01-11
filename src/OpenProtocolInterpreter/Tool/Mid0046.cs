using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Set primary tool request
    /// <para>This message is sent by the integrator in order to set tool data.</para>
    /// <para>Warning 1: this MID requires programming control (see 4.4 Programming control).</para>
    /// <para>Warning 2: the new configuration will not be active until the next controller reboot!</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///             <see cref="Communication.Mid0004"/> Command error, Programming control not granted or 
    ///                                                 Invalid data (value not supported by controller)
    /// </para>
    /// </summary>
    public class Mid0046 : Mid, ITool, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 46;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.PROGRAMMING_CONTROL_NOT_GRANTED, Error.INVALID_DATA };

        public PrimaryTool PrimaryTool
        {
            get => (PrimaryTool)GetField(1,(int)DataFields.PRIMARY_TOOL).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.PRIMARY_TOOL).SetValue(_intConverter.Convert, (int)value);
        }

        public Mid0046() : this(new Header()
        {
            Mid = MID, 
            Revision = LAST_REVISION
        })
        {
        }

        public Mid0046(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="primaryTool">Primary tool. The primary tool is two byte-long and specified by two ASCII digits.</param>
        public Mid0046(PrimaryTool primaryTool) : this()
        {
            PrimaryTool = primaryTool;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.PRIMARY_TOOL, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                }
            };
        }

        public enum DataFields
        {
            PRIMARY_TOOL
        }
    }
}
