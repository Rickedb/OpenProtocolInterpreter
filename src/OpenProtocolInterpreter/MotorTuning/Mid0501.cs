using System.Collections.Generic;

namespace OpenProtocolInterpreter.MotorTuning
{
    /// <summary>
    /// Motor tuning result data
    /// <para>Upload the last motor tuning result.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0502"/> Motor tuning result data acknowledge</para>
    /// </summary>
    public class Mid0501 : Mid, IMotorTuning, IController, IAcknowledgeable<Mid0502>
    {
        public const int MID = 501;

        /// <summary>
        /// <para>Motor Tune Failed = false (0)</para>
        /// <para>Motor Tune Success = true (1)</para>
        /// </summary>
        public bool MotorTuneResult
        {
            get => GetField(1, DataFields.MotorTuneResult).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, DataFields.MotorTuneResult).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0501() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0501(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.Boolean(DataFields.MotorTuneResult, 20)
                            }
                }
            };
        }

        protected enum DataFields
        {
            MotorTuneResult
        }
    }
}
