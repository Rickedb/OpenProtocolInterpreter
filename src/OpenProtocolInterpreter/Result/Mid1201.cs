using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.Result
{
    public class MID_1201 : Mid, IResult
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<IEnumerable<ObjectData>> _objectDataListConverter;
        private readonly IValueConverter<IEnumerable<VariableDataField>> _varDataFieldListConverter;

        private const int LAST_REVISION = 1;
        public const int MID = 1201;

        public MID_1201() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
            _dateConverter = new DateConverter();
            _boolConverter = new BoolConverter();
            _objectDataListConverter = new ObjectDataListConverter(_intConverter, _boolConverter);
            _varDataFieldListConverter = new VariableDataFieldListConverter(_intConverter);
            ObjectDataList = new List<ObjectData>();
            VariableDataFields = new List<VariableDataField>();
        }

        internal MID_1201(IMid nextTemplate) : this()
        {
            NextTemplate = nextTemplate;
        }

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
            get => GetField(1, (int)DataFields.RESULT_DATA_IDENTIFIER).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.RESULT_DATA_IDENTIFIER).SetValue(_intConverter.Convert, value);
        }
        public DateTime Time
        {
            get => GetField(1, (int)DataFields.TIME).GetValue(_dateConverter.Convert);
            set => GetField(1, (int)DataFields.TIME).SetValue(_dateConverter.Convert, value);
        }
        public bool ResultStatus
        {
            get => GetField(1, (int)DataFields.RESULT_STATUS).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.RESULT_STATUS).SetValue(_boolConverter.Convert, value);
        }
        public OperationType OperationType
        {
            get => (OperationType)GetField(1, (int)DataFields.OPERATION_TYPE).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.OPERATION_TYPE).SetValue(_intConverter.Convert, (int)value);
        }
        public int NumberOfObjects
        {
            get => GetField(1, (int)DataFields.NUMBER_OF_OBJECTS).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.NUMBER_OF_OBJECTS).SetValue(_intConverter.Convert, value);
        }
        public int NumberOfDataFields
        {
            get => GetField(1, (int)DataFields.NUMBER_OF_DATA_FIELDS).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.NUMBER_OF_DATA_FIELDS).SetValue(_intConverter.Convert, value);
        }
        public List<ObjectData> ObjectDataList { get; set; }
        public List<VariableDataField> VariableDataFields { get; set; }


        public override string Pack()
        {
            NumberOfObjects = ObjectDataList.Count;
            NumberOfDataFields = VariableDataFields.Count;

            GetField(1, (int)DataFields.OBJECT_DATA).SetValue(_objectDataListConverter.Convert(ObjectDataList));
            GetField(1, (int)DataFields.DATA_FIELD_LIST).SetValue(_varDataFieldListConverter.Convert(VariableDataFields));
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);
                int totalObjectData = _intConverter.Convert(GetValue(GetField(1, (int)DataFields.NUMBER_OF_OBJECTS), package));

                var objectDataField = GetField(1, (int)DataFields.OBJECT_DATA);
                objectDataField.Size = totalObjectData * 5;

                var totalNumberDataField = GetField(1, (int)DataFields.NUMBER_OF_DATA_FIELDS);
                totalNumberDataField.Index = objectDataField.Index + objectDataField.Size;

                var dataFieldListField = GetField(1, (int)DataFields.DATA_FIELD_LIST);
                dataFieldListField.Index = totalNumberDataField.Index + totalNumberDataField.Size;
                dataFieldListField.Size = package.Length - dataFieldListField.Index;

                ObjectDataList = _objectDataListConverter.Convert(objectDataField.Value).ToList();
                VariableDataFields = _varDataFieldListConverter.Convert(dataFieldListField.Value).ToList();
                return this;
            }

            return NextTemplate.Parse(package);
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
                        new DataField((int)DataFields.RESULT_DATA_IDENTIFIER, 26, 10, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                        new DataField((int)DataFields.TIME, 36, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                        new DataField((int)DataFields.RESULT_STATUS, 55, 1, false),
                        new DataField((int)DataFields.OPERATION_TYPE, 56, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                        new DataField((int)DataFields.NUMBER_OF_OBJECTS, 58, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                        new DataField((int)DataFields.OBJECT_DATA, 61, 0, false),
                        new DataField((int)DataFields.NUMBER_OF_DATA_FIELDS, 0, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                        new DataField((int)DataFields.DATA_FIELD_LIST, 0, 0, false)
                    }
                }
            };
        }

        public enum DataFields
        {
            TOTAL_MESSAGES,
            MESSAGE_NUMBER,
            RESULT_DATA_IDENTIFIER,
            TIME,
            RESULT_STATUS,
            OPERATION_TYPE,
            NUMBER_OF_OBJECTS,
            OBJECT_DATA,  // list of data
            NUMBER_OF_DATA_FIELDS,
            DATA_FIELD_LIST
        }
    }
}

