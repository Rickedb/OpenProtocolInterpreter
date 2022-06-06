﻿using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// Application Communication negative acknowledge
    /// <para>
    ///     This message is used by the controller when a request, command or subscription for any reason has 
    ///     not been performed. 
    ///     The data field contains the message ID of the message request that failed as well as an error code.
    ///     It can also be used by the integrator to acknowledge received subscribed data/events upload and will
    ///     then do all the special subscription data acknowledges obsolete.
    /// </para>
    /// <para>
    ///     When using the communication acknowledgement of MID 0007 and <see cref="Mid0006"/> together with sequence 
    ///     numbering this is an application level message only.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0004 : Mid, ICommunication, IController
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 4;

        public int FailedMid
        {
            get => GetField(1, (int)DataFields.MID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.MID).SetValue(_intConverter.Convert, value);
        }
        public Error ErrorCode
        {
            get => (Error)GetField(1, (int)DataFields.ERROR_CODE).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.ERROR_CODE).SetValue(_intConverter.Convert, (int)value);
        }

        public Mid0004() : this(new Header()
        {
            Mid = MID,
            Revision = LAST_REVISION
        })
        {

        }

        public Mid0004(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="failedMid">Failed Mid. Range: 0000-9999</param>
        /// <param name="errorCode"></param>
        public Mid0004(int failedMid, Error errorCode) : this()
        {
            FailedMid = failedMid;
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            List<string> failed = new List<string>();
            if (FailedMid < 1 || FailedMid > 9999)
                failed.Add(new ArgumentOutOfRangeException(nameof(FailedMid), "Range: 0000-9999").Message);

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
                                new DataField((int)DataFields.MID, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.ERROR_CODE, 24, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                            }
                }
            };
        }


        public enum DataFields
        {
            MID,
            ERROR_CODE
        }
    }
}
