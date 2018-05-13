using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.IOInterface
{
    public class DigitalInput
    {
        private List<DataField> fields;
        public DigitalInputNumbers Number { get; set; }
        public bool Status { get; set; }

        public DigitalInput()
        {
            fields = new List<DataField>();
            registerDatafields();
        }

        public string buildPackage()
        {
            string pkg = string.Empty;
            pkg += ((int)Number).ToString().PadLeft(3, '0');
            pkg += Convert.ToInt32(Status).ToString();
            return pkg;
        }

        public IEnumerable<DigitalInput> getDigitalInputsFromPackage(string package)
        {
            List<DigitalInput> digIns = new List<DigitalInput>();
            for (int i = 0; i < package.Length; i += 4)
                digIns.Add(getDigIn(package.Substring(i, i + 4)));
            return digIns;
        }

        private DigitalInput getDigIn(string package)
        {
            DigitalInput obj = new DigitalInput();
            obj.Number = (DigitalInputNumbers)Convert.ToInt32(package.Substring(fields[(int)DataFields.DIGITAL_INPUT_NUMBER].Index, fields[(int)DataFields.DIGITAL_INPUT_NUMBER].Size));
            obj.Status = Convert.ToBoolean(Convert.ToInt32(package.Substring(fields[(int)DataFields.DIGITAL_INPUT_STATUS].Index, fields[(int)DataFields.DIGITAL_INPUT_STATUS].Size)));
            return obj;
        }

        private void registerDatafields()
        {
            fields.AddRange(
                new DataField[]
                {
                            new DataField((int)DataFields.DIGITAL_INPUT_NUMBER, 0, 3),
                            new DataField((int)DataFields.DIGITAL_INPUT_STATUS, 2, 1)
                });
        }

        public enum DataFields
        {
            DIGITAL_INPUT_NUMBER,
            DIGITAL_INPUT_STATUS
        }

        
    }
}
