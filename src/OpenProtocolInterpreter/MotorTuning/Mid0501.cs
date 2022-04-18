using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MotorTuning
{
    /// <summary>
    /// Motor tuning result data
    /// <para>Upload the last motor tuning result.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0502"/> Motor tuning result data acknowledge</para>
    /// </summary>
    public class Mid0501 : Mid, IMotorTuning, IController
    {
        private readonly IValueConverter<bool> _boolConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 501;

        /// <summary>
        /// <para>Motor Tune Failed = false (0)</para>
        /// <para>Motor Tune Success = true (1)</para>
        /// </summary>
        public bool MotorTuneResult
        {
            get => GetField(1, (int)DataFields.MOTOR_TUNE_RESULT).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.MOTOR_TUNE_RESULT).SetValue(_boolConverter.Convert, value);
        }

        public Mid0501() : base(MID, LAST_REVISION)
        {
            _boolConverter = new BoolConverter();
        }

        public Mid0501(bool motorTuneResult) : this()
        {
            MotorTuneResult = motorTuneResult;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.MOTOR_TUNE_RESULT, 20, 1)
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
