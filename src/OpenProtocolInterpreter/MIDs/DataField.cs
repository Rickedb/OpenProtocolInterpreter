namespace OpenProtocolInterpreter.MIDs
{
    public class DataField
    {
        public int Field { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
        public object Value
        {
            get;
            set;

        }

        public DataField(int field, int index, int size)
        {
            this.createObject(field, index, size, null);
        }

        public DataField(int field, string index, int size)
        {
            this.createObject(field, System.Convert.ToInt32(index), size, null);
        }

        public DataField(int field, string index, int size, object value)
        {
            this.createObject(field, System.Convert.ToInt32(index), size, value);
        }

        public string getIndex()
        {
            return this.Index.ToString().PadLeft(2, '0');
        }

        public string getPaddedLeftValue()
        {
            return this.getPaddedLeftValue('0');
        }

        public string getPaddedLeftValue(char character)
        {
            return this.Value.ToString().PadLeft(this.Size, character);
        }

        public string getPaddedRightValue()
        {
            return this.getPaddedRightValue('0');
        }

        public string getPaddedRightValue(char character)
        {
            return this.Value.ToString().PadRight(this.Size, character);
        }

        private void createObject(int field, int index, int size, object value)
        {
            this.Field = field;
            this.Index = index;
            this.Size = size;
            this.Value = value;
        }
    }
}
