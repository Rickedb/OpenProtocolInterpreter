﻿using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Reset Parameter set batch counter
    /// <para>This message gives the possibility to reset the batch counter of the running parameter set, at run time.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///     <see cref="Communication.Mid0004"/> Command error, Invalid data, or Parameter set not running
    /// </para>
    /// </summary>
    public class Mid0020 : Mid, IParameterSet, IIntegrator
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 20;

        public int ParameterSetId
        {
            get => GetField(1, (int)DataFields.PARAMETER_SET_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.PARAMETER_SET_ID).SetValue(_intConverter.Convert, value);
        }

        public Mid0020() : this(new Header()
        {
            Mid = MID,
            Revision = LAST_REVISION
        })
        {
        }

        public Mid0020(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        public Mid0020(int parameterSetId) : this() => ParameterSetId = parameterSetId;

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                            }
                }
            };
        }

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            errors = Enumerable.Empty<string>();
            if (ParameterSetId < 0 || ParameterSetId > 999)
                errors = new List<string>() { new ArgumentOutOfRangeException(nameof(ParameterSetId), "Range: 000-999").Message };
            return errors.Any();
        }

        public enum DataFields
        {
            PARAMETER_SET_ID
        }
    }
}
