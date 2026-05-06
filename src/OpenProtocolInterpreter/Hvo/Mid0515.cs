using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Hvo
{
    /// <summary>
    /// Set HVO signal
    /// <para>
    ///     Command to set the HVO (Hand-guided Visual Output) lamp signals.
    ///     Revision 1: Controls 4 individual lamp signals.
    ///     Revision 2: Controls a numbered light with a status value.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0515 : Mid, IHvo, IIntegrator
    {
        public const int MID = 515;

        /// <summary>
        /// Revision 1: Lamp 1 signal value (0-9).
        /// </summary>
        public int Lamp1
        {
            get => GetField(1, DataFields.Lamp1).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Lamp1).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>
        /// Revision 1: Lamp 2 signal value (0-9).
        /// </summary>
        public int Lamp2
        {
            get => GetField(1, DataFields.Lamp2).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Lamp2).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>
        /// Revision 1: Lamp 3 signal value (0-9).
        /// </summary>
        public int Lamp3
        {
            get => GetField(1, DataFields.Lamp3).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Lamp3).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>
        /// Revision 1: Lamp 4 signal value (0-9).
        /// </summary>
        public int Lamp4
        {
            get => GetField(1, DataFields.Lamp4).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Lamp4).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>
        /// Revision 2: Light number (1-999).
        /// </summary>
        public int LightNumber
        {
            get => GetField(2, DataFields.LightNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.LightNumber).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>
        /// Revision 2: Light status value (1-999).
        /// </summary>
        public int LightStatus
        {
            get => GetField(2, DataFields.LightStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.LightStatus).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0515() : this(DEFAULT_REVISION) { }

        public Mid0515(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        public Mid0515(Header header) : base(header) { }

        /// <summary>
        /// Revision 2 is a replacement format, not additive. Only process the current revision's fields.
        /// </summary>
        protected override void ProcessDataFields(string package)
        {
            ProcessDataFields(Header.StandardizedRevision, package);
        }

        public override string Pack()
        {
            if (!RevisionsByFields.Any())
                return BuildHeader();

            int revision = Header.StandardizedRevision;
            if (RevisionsByFields.TryGetValue(revision, out var dataFields))
            {
                Header.Length = Header.DefaultSize;
                foreach (var dataField in dataFields)
                    Header.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
            }

            var builder = new StringBuilder(Header.ToString());
            int prefixIndex = 1;
            builder.Append(Pack(revision, ref prefixIndex));
            return builder.ToString();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        DataField.Number(DataFields.Lamp1, 20, 1),
                        DataField.Number(DataFields.Lamp2, 23, 1),
                        DataField.Number(DataFields.Lamp3, 26, 1),
                        DataField.Number(DataFields.Lamp4, 29, 1)
                    }
                },
                {
                    2, new List<DataField>()
                    {
                        DataField.Number(DataFields.LightNumber, 20, 3),
                        DataField.Number(DataFields.LightStatus, 25, 3)
                    }
                }
            };
        }

        protected enum DataFields
        {
            Lamp1,
            Lamp2,
            Lamp3,
            Lamp4,
            LightNumber,
            LightStatus
        }
    }
}
