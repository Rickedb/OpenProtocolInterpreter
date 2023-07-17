using System.Collections.Generic;

namespace OpenProtocolInterpreter.Alarm
{

    /// <summary>
    /// Alarm acknowledged on controller
    /// <para>The message is sent by the controller to inform the integrator that the current alarm has been acknowledged.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0075"/> Alarm acknowledged on controller acknowledge</para>
    /// </summary>
    public class Mid0074 : Mid, IAlarm, IController, IAcknowledgeable<Mid0075>
    {
        public const int MID = 74;

        public string ErrorCode
        {
            get => GetField(1, (int)DataFields.ErrorCode).Value;
            set => GetField(1, (int)DataFields.ErrorCode).SetValue(value);
        }

        public Mid0074() : this(DEFAULT_REVISION)
        {

        }

        public Mid0074(Header header) : base(header)
        {

        }

        public Mid0074(int revision) : base(MID, revision)
        {

        }

        public override string Pack()
        {
            RevisionsByFields[1][(int)DataFields.ErrorCode].Size = Header.Revision == 1 ? 4 : 5;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            RevisionsByFields[1][(int)DataFields.ErrorCode].Size = Header.Revision == 1 ? 4 : 5;
            ProcessDataFields(package);
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.ErrorCode, 20, 4, ' ', PaddingOrientation.LeftPadded, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            ErrorCode
        }
    }
}
