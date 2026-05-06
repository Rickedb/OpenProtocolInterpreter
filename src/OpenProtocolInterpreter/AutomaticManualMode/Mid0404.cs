using System.Collections.Generic;

namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// Select automatic/manual mode
    /// <para>
    ///     The operating mode is changed. This is a Rexroth/NEXO vendor extension (FW ≥1300).
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted
    /// </para>
    /// </summary>
    public class Mid0404 : Mid, IAutomaticManualMode, IIntegrator, IAcceptableCommand
    {
        public const int MID = 404;

        /// <summary>
        /// <para>Automatic Mode = false (0)</para>
        /// <para>Manual Mode = true (1)</para>
        /// </summary>
        public bool ManualAutomaticMode
        {
            get => GetField(1, DataFields.ManualAutomaticMode).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, DataFields.ManualAutomaticMode).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0404() : this(DEFAULT_REVISION) { }

        public Mid0404(Header header) : base(header)
        {
        }

        public Mid0404(int revision) : this(new Header() { Mid = MID, Revision = revision })
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        DataField.Boolean(DataFields.ManualAutomaticMode, 20, false)
                    }
                }
            };
        }

        protected enum DataFields
        {
            ManualAutomaticMode
        }
    }
}
