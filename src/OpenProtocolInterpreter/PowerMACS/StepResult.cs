using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.PowerMACS
{
    public class StepResult
    {
        public string VariableName { get; set; }
        public DataType Type { get; set; }
        public object Value { get; set; }
        public int StepNumber { get; set; }
    }
}
