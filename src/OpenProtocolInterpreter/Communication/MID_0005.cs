using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// MID: Application Communication positive acknowledge
    /// Description: 
    ///     This message is used by the controller to confirm that the latest command, request or subscription sent
    ///     by the integrator was accepted.The data field contains the MID of the request accepted if the special
    ///     MIDs for request or subscription are used.
    ///     It can also be used by the integrator to acknowledge received subscribed data/events upload and will
    ///     then do all the special subscription data acknowledges obsolete.
    ///     When using the communication acknowledgement of MID 9997 and MID 9998 together with
    ///     sequence numbering this is an application level message only.
    ///     When using the GENERIC subscription MIDs 0008 and 0009 the data field contains the MID of
    ///     the subscribed MID.
    /// 
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0005 : MID, ICommunication
    {
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 5;
        private const int LAST_REVISION = 1;

        public int MidAccepted { get; set; }

        public MID_0005() : base(MID, LAST_REVISION) => _intConverter = new Int32Converter();

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="midAccepted">Mid accepted</param>
        public MID_0005(int midAccepted) : this() => MidAccepted = midAccepted;
        
        internal MID_0005(IMID nextTemplate) : this() => NextTemplate = nextTemplate;

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            List<string> failed = new List<string>();
            if (MidAccepted < 1 || MidAccepted > 9999)
                failed.Add(new ArgumentOutOfRangeException(nameof(MidAccepted), "Range: 0000-9999").Message);

            errors = failed;
            return failed.Count > 0;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.MID_ACCEPTED, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                            }
                }
            };
        }

        public enum DataFields
        {
            MID_ACCEPTED
        }
    }
}
