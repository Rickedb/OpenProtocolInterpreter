using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Select Parameter set, Dynamic Job Included
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error, Dynamic Job cannot be created, non-existing pset
    /// </para>
    /// </summary>
    public class Mid2504 : Mid, IParameterSet, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 2504;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.PARAMETER_SET_ID_NOT_PRESENT };

        public int ParameterSetId
        {
            get => GetField(1,(int)DataFields.PARAMETER_SET_ID).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.PARAMETER_SET_ID).SetValue(_intConverter.Convert, value);
        }

        public Mid2504() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid2504(Header header) : base(header)
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
                                new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                            }
                }
            };
        }

        public enum DataFields
        {
            PARAMETER_SET_ID
        }
    }
}
