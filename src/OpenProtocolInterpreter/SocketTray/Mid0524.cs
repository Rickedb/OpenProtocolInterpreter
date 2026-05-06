using System.Collections.Generic;

namespace OpenProtocolInterpreter.SocketTray
{
    /// <summary>
    /// Socket tray selection
    /// <para>
    ///     Send socket position selections to the controller.
    ///     Each of the 8 socket positions is represented by a single digit value.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0524 : Mid, ISocketTray, IIntegrator
    {
        public const int MID = 524;

        public int Socket1
        {
            get => GetField(1, DataFields.Socket1).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Socket1).SetValue(OpenProtocolConvert.ToString, value);
        }

        public int Socket2
        {
            get => GetField(1, DataFields.Socket2).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Socket2).SetValue(OpenProtocolConvert.ToString, value);
        }

        public int Socket3
        {
            get => GetField(1, DataFields.Socket3).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Socket3).SetValue(OpenProtocolConvert.ToString, value);
        }

        public int Socket4
        {
            get => GetField(1, DataFields.Socket4).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Socket4).SetValue(OpenProtocolConvert.ToString, value);
        }

        public int Socket5
        {
            get => GetField(1, DataFields.Socket5).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Socket5).SetValue(OpenProtocolConvert.ToString, value);
        }

        public int Socket6
        {
            get => GetField(1, DataFields.Socket6).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Socket6).SetValue(OpenProtocolConvert.ToString, value);
        }

        public int Socket7
        {
            get => GetField(1, DataFields.Socket7).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Socket7).SetValue(OpenProtocolConvert.ToString, value);
        }

        public int Socket8
        {
            get => GetField(1, DataFields.Socket8).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Socket8).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0524() : this(DEFAULT_REVISION) { }

        public Mid0524(Header header) : base(header) { }

        public Mid0524(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        DataField.Number(DataFields.Socket1, 20, 1),
                        DataField.Number(DataFields.Socket2, 23, 1),
                        DataField.Number(DataFields.Socket3, 26, 1),
                        DataField.Number(DataFields.Socket4, 29, 1),
                        DataField.Number(DataFields.Socket5, 32, 1),
                        DataField.Number(DataFields.Socket6, 35, 1),
                        DataField.Number(DataFields.Socket7, 38, 1),
                        DataField.Number(DataFields.Socket8, 41, 1)
                    }
                }
            };
        }

        protected enum DataFields
        {
            Socket1,
            Socket2,
            Socket3,
            Socket4,
            Socket5,
            Socket6,
            Socket7,
            Socket8
        }
    }
}
