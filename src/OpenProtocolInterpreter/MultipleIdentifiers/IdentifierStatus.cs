using System;

namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// Represents an Identifier Status entity
    /// </summary>
    public class IdentifierStatus
    {
        public int IdentifierTypeNumber { get; set; }
        public bool IncludedInWorkOrder { get; set; }
        public StatusInWorkOrder StatusInWorkOrder { get; set; }
        public string ResultPart { get; set; }

        public string Pack()
        {
            return OpenProtocolConvert.ToString('0', 1, DataField.PaddingOrientations.LeftPadded, IdentifierTypeNumber) +
                   OpenProtocolConvert.ToString('0', 2, DataField.PaddingOrientations.LeftPadded, Convert.ToInt32(IncludedInWorkOrder)) +
                   OpenProtocolConvert.ToString('0', 2, DataField.PaddingOrientations.LeftPadded, (int)StatusInWorkOrder) +
                   ResultPart.SafePadRight(25);
        }

        public static IdentifierStatus Parse(string section)
        {
            if (string.IsNullOrEmpty(section))
            {
                return default;
            }

            return new IdentifierStatus()
            {
                IdentifierTypeNumber = OpenProtocolConvert.ToInt32(section.Substring(0, 1)),
                IncludedInWorkOrder = OpenProtocolConvert.ToBoolean(section.Substring(1, 2)),
                StatusInWorkOrder = (StatusInWorkOrder)OpenProtocolConvert.ToInt32(section.Substring(3, 2)),
                ResultPart = section.SafeSubstring(5, 25)
            };
        }
    }
}
