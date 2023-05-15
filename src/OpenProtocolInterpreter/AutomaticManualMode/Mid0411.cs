using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// AutoDisable settings reply
    /// <para>
    ///     Information about the setting of AutoDisable tightening in the controller. Also contains information about the currently running batch.
    ///     The settings are reserved for single parameter sets with batch and are not available while running Job.
    /// </para> 
    /// <para>
    ///     Power Macs use:
    ///     “OKs to disable station” is a parameter in Tools Talk PowerMACS and specifies the number of cycles with status OK or OKR that may be run while in Automatic mode before the station is automatically disabled. It is sent as two ASCII digits, a 0 means the function is not in use.
    ///     “Current Batch” is two ASCII digits representing the number of OK cycles that have been run in the current batch.If the value is 0 no batch is running at the moment.
    /// </para>
    /// <para>
    ///     Power Focus use:
    ///     The “Current Batch” contains at which batch counter value/tightening the parameter set batch was
    ///     locked/finished if “batch count” and “lock at batch ok” parameters in Tools Talk PF was used,
    ///     otherwise it will contain 0 indicating function not used.If “lock at batch ok” parameter was not used
    ///     the “Current Batch” is just current.
    /// </para>
    /// <para>
    ///     The “Auto Disable” contains the parameter sets batch size if “batch count” and “lock at batch ok”
    ///     parameters was used indicating that Auto Disable function is used.If “batch count” or “lock at batch
    ///     ok” was not used the “Auto Disable” is 0.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0411 : Mid, IAutomaticManualMode, IController
    {
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 411;

        public int AutoDisableSetting
        {
            get => GetField(1, (int)DataFields.AUTO_DISABLE_SETTING).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.AUTO_DISABLE_SETTING).SetValue(_intConverter.Convert, value);
        }
        public int CurrentBatch
        {
            get => GetField(1, (int)DataFields.CURRENT_BATCH).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.CURRENT_BATCH).SetValue(_intConverter.Convert, value);
        }

        public Mid0411() : this(new Header()
        {
            Mid= MID,
            Revision = DEFAULT_REVISION
        })
        {
            
        }

        public Mid0411(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.AUTO_DISABLE_SETTING, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.CURRENT_BATCH, 22, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            AUTO_DISABLE_SETTING,
            CURRENT_BATCH
        }
    }
}
