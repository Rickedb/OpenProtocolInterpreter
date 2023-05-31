using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Reset digital input function
    /// <para>
    ///     Reset the digital input function with the digital input number. 
    ///     The digital input function numbers are defined in Table 80.
    /// </para>    
    /// <para>
    ///     This MID will only affect the digital input functions of tracking type.
    ///     The digital input functions with the type flank cannot be reset (for example reset the reset 
    ///     batch digital input function will have no effect).
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Invalid data</para>
    /// </summary>
    public class Mid0225 : Mid, IIOInterface, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 225;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.InvalidData };

        public DigitalInputNumber DigitalInputNumber
        {
            get => (DigitalInputNumber)GetField(1,(int)DataFields.DigitalInputNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.DigitalInputNumber).SetValue(OpenProtocolConvert.ToString, (int)value);
        }

        public Mid0225() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0225(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.DigitalInputNumber, 20, 3, '0', PaddingOrientation.LeftPadded, false)
                    }
                }
            };
        }

        protected enum DataFields
        {
            DigitalInputNumber
        }
    }
}
