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
    public class Mid0501 : Mid, IMotorTuning, IController, IAcknowledgeable<Mid0502>
    {
        private readonly IValueConverter<bool> _boolConverter;
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

        public Mid0501() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0501(Header header) : base(header)
        {
            _boolConverter = new BoolConverter();
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

        protected enum DataFields
        {
            MOTOR_TUNE_RESULT
        }
    }
}
