using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Select Parameter set
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///     <see cref="Communication.Mid0004"/> Command error, Parameter set can not be set
    /// </para>
    /// </summary>
    public class Mid0018 : Mid, IParameterSet, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 18;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.ParameterSetCannotBeSet };

        public int ParameterSetId
        {
            get => GetField(1,(int)DataFields.ParameterSetId).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.ParameterSetId).SetValue(_intConverter.Convert, value);
        }

        public Mid0018() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0018(Header header) : base(header)
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
                                new DataField((int)DataFields.ParameterSetId, 20, 3, '0', DataField.PaddingOrientations.LeftPadded, false)
                            }
                }
            };
        }


        protected enum DataFields
        {
            ParameterSetId
        }
    }
}
