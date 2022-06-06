﻿using System.Collections.Generic;
using System.Linq;
using OpenProtocolInterpreter.Converters;

namespace OpenProtocolInterpreter.Result
{
    /// <summary>
    /// Operation result object data
    /// <para>
    ///     This message contains the cycle data for one object, both data for the whole process and data related to 
    ///     the different steps in the process.The user defined values are preconfigured in the controller via the 
    ///     configuration tool. The message uses the Variable Parameter pattern for transmission of the values.
    /// </para>
    /// <para>
    ///     Note: Only values that exist in the result will be sent.So the actual data received may vary between 
    ///     the cycles if the settings differ between different programs.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>
    ///     Answer: <see cref="Mid1203"/> Operation result data acknowledge or 
    ///             <see cref="Communication.Mid0005"/> with <see cref="Mid1202"/> in the data field.
    /// </para>
    ///         
    ///         If the sequence number acknowledge functionality is used there is no need for these acknowledges.
    /// </summary>
    public class Mid1202 : Mid, IResult, IController
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<IEnumerable<VariableDataField>> _variableDataFieldListConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 1202;

        public int TotalNumberOfMessages
        {
            get => GetField(1, (int)DataFields.TOTAL_MESSAGES).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.TOTAL_MESSAGES).SetValue(_intConverter.Convert, value);
        }
        public int MessageNumber
        {
            get => GetField(1, (int)DataFields.MESSAGE_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.MESSAGE_NUMBER).SetValue(_intConverter.Convert, value);
        }
        public int ResultDataIdentifier
        {
            get => GetField(1, (int)DataFields.RESULT_DATA_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.RESULT_DATA_ID).SetValue(_intConverter.Convert, value);
        }
        public int ObjectId
        {
            get => GetField(1, (int)DataFields.OBJECT_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.OBJECT_ID).SetValue(_intConverter.Convert, value);
        }
        public int NumberOfDataFields
        {
            get => GetField(1, (int)DataFields.NUMBER_DATA_FIELDS).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.NUMBER_DATA_FIELDS).SetValue(_intConverter.Convert, value);
        }

        public List<VariableDataField> VariableDataFields { get; set; }

        public Mid1202() : this(new Header()
        {
            Mid = MID,
            Revision = LAST_REVISION
        })
        {
        }

        public Mid1202(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            _variableDataFieldListConverter = new VariableDataFieldListConverter(_intConverter);
            VariableDataFields = new List<VariableDataField>();
        }

        public override string Pack()
        {
            NumberOfDataFields = VariableDataFields.Count;
            GetField(1, (int)DataFields.VARIABLE_DATA_FIELDS).SetValue(_variableDataFieldListConverter.Convert(VariableDataFields));
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            var variableDataField = GetField(1, (int)DataFields.VARIABLE_DATA_FIELDS);
            variableDataField.Size = package.Length - variableDataField.Index;
            ProcessDataFields(package);

            VariableDataFields = _variableDataFieldListConverter.Convert(variableDataField.Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.TOTAL_MESSAGES, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                        new DataField((int)DataFields.MESSAGE_NUMBER, 23, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                        new DataField((int)DataFields.RESULT_DATA_ID, 26, 10, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                        new DataField((int)DataFields.OBJECT_ID, 36, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                        new DataField((int)DataFields.NUMBER_DATA_FIELDS, 40, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                        new DataField((int)DataFields.VARIABLE_DATA_FIELDS, 43, 0, false) //defined at runtime
                    }
                }
            };
        }

        public enum DataFields
        {
            TOTAL_MESSAGES,
            MESSAGE_NUMBER,
            RESULT_DATA_ID,
            OBJECT_ID,
            NUMBER_DATA_FIELDS,
            VARIABLE_DATA_FIELDS
        }
    }
}
