using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Represents a Data Field unit's type
    /// </summary>
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public class DataType
    {
        private static readonly List<DataType> _dataTypesDefinition =
        [
            new DataType(1, "UI", 0),
            new DataType(2, "I ", 0),
            new DataType(3, "F ", 0),
            new DataType(4, "S ", 0),
            new DataType(5, "T ", 19),
            new DataType(6, "B ", 1),
            new DataType(7, "H ", 0),
            new DataType(8, "PL1", 0),
            new DataType(9, "PL2", 0),
            new DataType(10, "PL4", 0),
            new DataType(50, "FA", 0),
            new DataType(51, "UA", 0),
            new DataType(52, "IA", 0)
        ];

        private int _valueSent;

        public static List<DataType> DataTypes => _dataTypesDefinition;

        public string ValueSentInTelegram
        {
            get
            {
                return _valueSent.ToString().PadLeft(2, '0');
            }
        }
        public string Type { get; set; }
        public int Length { get; set; }

        private DataType(int valueSent, string type, int length)
        {
            _valueSent = valueSent;
            Type = type;
            Length = length;
        }

        public static implicit operator DataType(string type)
        {
            return _dataTypesDefinition.FirstOrDefault(x=> x == type);
        }

        public static bool operator ==(DataType type, string type2)
        {
            if (string.IsNullOrEmpty(type2)) return false;

            return type.Type.Trim() == type2.Trim();
        }
        public static bool operator !=(DataType type, string type2)
        {
            if (string.IsNullOrEmpty(type2)) return true;

            return type.Type.Trim() != type2.Trim();
        }
    }
}
