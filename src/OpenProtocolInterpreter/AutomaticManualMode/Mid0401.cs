using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// Automatic/Manual mode
    /// <para>
    ///     The operation mode in the controller has changed. 
    ///     The message includes the new operational mode of the controller.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0402"/> Automatic/Manual mode acknowledge</para>
    /// </summary>
    public class Mid0401 : Mid, IAutomaticManualMode, IController, IAcknowledgeable<Mid0402>
    {
        private readonly IValueConverter<bool> _boolConverter;
        public const int MID = 401;

        /// <summary>
        /// <para>Automatic Mode = false (0)</para>
        /// <para>Manual Mode = true (1)</para>
        /// </summary>
        public bool ManualAutomaticMode
        {
            get => GetField(1, (int)DataFields.MANUAL_AUTOMATIC_MODE).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.MANUAL_AUTOMATIC_MODE).SetValue(_boolConverter.Convert, value);
        }

        public Mid0401() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION,
        })
        {

        }

        public Mid0401(Header header) : base(header)
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
                                new DataField((int)DataFields.MANUAL_AUTOMATIC_MODE, 20, 1, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            MANUAL_AUTOMATIC_MODE
        }
    }
}
