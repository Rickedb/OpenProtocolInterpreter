using System.Collections.Generic;

namespace OpenProtocolInterpreter.MIDs
{
    public class DataType
    {
        private static List<DataType> dataTypesDefinition;
        private int _valueSent;

        public string ValueSentInTelegram
        {
            get
            {
                return _valueSent.ToString().PadLeft(2, '0');
            }
        }
        public string Type { get; set; }
        public int Length { get; set; }

        public DataType(int valueSent, string type, int length)
        {
            this._valueSent = valueSent;
            this.Type = type;
            this.Length = length;
        }

        public static List<DataType> DataTypes
        {
            get
            {
                if (dataTypesDefinition == null)
                    buildUpDataTypes();

                return dataTypesDefinition;
            }
        }

        private static void buildUpDataTypes()
        {
            dataTypesDefinition = new List<DataType>();
            dataTypesDefinition.AddRange(new DataType[]
            {
                new DataType(1, "UI", 0),
                new DataType(2, "I", 0),
                new DataType(3, "F", 0),
                new DataType(4, "S", 0),
                new DataType(5, "T", 19),
                new DataType(6, "B", 1),
                new DataType(7, "H", 0),
                new DataType(8, "PL1", 0),
                new DataType(9, "PL2", 0),
                new DataType(10, "PL4", 0),
                new DataType(50, "FA", 0),
                new DataType(51, "UA", 0),
                new DataType(52, "IA", 0)
            });
        }
    }
}
