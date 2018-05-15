using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MotorTuning
{
    /// <summary>
    /// MID: Motor tuning result data
    /// Description: 
    ///     Upload the last motor tuning result.
    /// Message sent by: Controller
    /// Answer: MID 0502 Motor tuning result data acknowledge
    /// </summary>
    public class MID_0501 : Mid, IMotorTuning
    {
        private readonly IValueConverter<bool> _boolConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 501;

        /// <summary>
        /// <para>Motor Tune Failed = false (0)</para>
        /// <para>Motor Tune Success = true (1)</para>
        /// </summary>
        public bool MotorTuneResult { get; set; }

        public MID_0501(int? noAckFlag = 1) : base(MID, LAST_REVISION, noAckFlag) { }

        public MID_0501(bool motorTuneResult, int? noAckFlag = 1) : this(noAckFlag)
        {
            MotorTuneResult = motorTuneResult;
        }

        internal MID_0501(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.MOTOR_TUNE_RESULT, 20, 1, false)
                            }
                }
            };
        }

        public enum DataFields
        {
            MOTOR_TUNE_RESULT
        }
    }
}
