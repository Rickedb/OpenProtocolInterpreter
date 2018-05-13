using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    public class Relay
    {
        private List<DataField> fields;
        public RelayNumbers Number { get; set; }
        public bool Status { get; set; }

        public Relay()
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

        public IEnumerable<Relay> getRelaysFromPackage(string package)
        {
            List<Relay> relays = new List<Relay>();
            for (int i = 0; i < package.Length; i += 4)
                relays.Add(getRelay(package.Substring(i, i + 4)));
            return relays;
        }

        internal Relay getRelay(string package)
        {
            Relay obj = new Relay();
            obj.Number = (RelayNumbers)Convert.ToInt32(package.Substring(fields[(int)DataFields.RELAY_NUMBER].Index, fields[(int)DataFields.RELAY_NUMBER].Size));
            obj.Status = Convert.ToBoolean(Convert.ToInt32(package.Substring(fields[(int)DataFields.RELAY_STATUS].Index, fields[(int)DataFields.RELAY_STATUS].Size)));
            return obj;
        }

        private void registerDatafields()
        {
            fields.AddRange(
                new DataField[]
                {
                            new DataField((int)DataFields.RELAY_NUMBER, 0, 3),
                            new DataField((int)DataFields.RELAY_STATUS, 2, 1)
                });
        }

        public enum DataFields
        {
            RELAY_NUMBER,
            RELAY_STATUS
        }

        
    }
}
