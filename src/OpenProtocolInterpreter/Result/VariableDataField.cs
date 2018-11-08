using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Result
{
    public class VariableDataField
    {
        public int ParameterId { get; set; }
        public int Length { get; set; }
        public int DataType { get; set; }
        public int Unit { get; set; }
        public int StepNumber { get; set; }
        public string RealValue { get; set; }

    }
}
