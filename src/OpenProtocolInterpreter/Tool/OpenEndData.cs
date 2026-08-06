using System;
using System.Reflection;

namespace OpenProtocolInterpreter.Tool
{
    public class OpenEndData
    {
        public bool UseOpenEnd { get; set; }
        public TighteningDirection TighteningDirection { get; set; }
        public MotorRotation MotorRotation { get; set; }

        public OpenEndData()
        {

        }

        public OpenEndData(bool useOpenEnd, TighteningDirection tighteningDirection, MotorRotation motorRotation)
        {
            UseOpenEnd = useOpenEnd;
            TighteningDirection = tighteningDirection;
            MotorRotation = motorRotation;
        }

        public string Pack()
        {
            return OpenProtocolConvert.ToString(UseOpenEnd) +
                    OpenProtocolConvert.ToString((int)TighteningDirection) +
                    OpenProtocolConvert.ToString((int)MotorRotation);
        }

        public static OpenEndData Parse(string value)
            => Parse(value.AsSpan());

        public static OpenEndData Parse(ReadOnlySpan<char> value)
        {
            return new OpenEndData()
            {
                UseOpenEnd = OpenProtocolConvert.ToBoolean(value.Slice(0, 1)),
                TighteningDirection = (TighteningDirection)OpenProtocolConvert.ToInt32(value.Slice(1, 1)),
                MotorRotation = (MotorRotation)OpenProtocolConvert.ToInt32(value.Slice(2, 1)),
            };
        }
    }

    public class OpenEndDataDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public OpenEndDataDefinitionAttribute(int revision) : base(revision)
        {

        }
        public OpenEndDataDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return new DataField<OpenEndData>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = PackOpenEndData,
                DefaultParser = ParseOpenEndData
            }.Bind(owner, propertyInfo);
        }

        private string PackOpenEndData(char paddingChar, int size, PaddingOrientation orientation, OpenEndData openEndData)
            => openEndData.Pack();

        private OpenEndData ParseOpenEndData(string value)
            => OpenEndData.Parse(value);
    }
}
