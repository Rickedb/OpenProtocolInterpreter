namespace OpenProtocolInterpreter.MIDs
{
    public class DataField
    {
        private char paddingChar;
        public int Field { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
        public object Value { get; set; }

        public DataField(int field, int index, int size)
        {
            this.createObject(field, index, size, null);
        }

        public DataField(int field, string index, int size)
        {
            this.createObject(field, System.Convert.ToInt32(index), size, null);
        }

        public DataField(int field, int index, int size, char paddingChar)
        {
            this.paddingChar = paddingChar;
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

        public void setBoolean(bool value)
        {
            this.Value = System.Convert.ToInt32(value);
        }

        public void setPaddedLeftValue(object value)
        {
            if (value == null)
                value = string.Empty;
            this.setPaddedLeftValue(value, this.paddingChar);
        }

        public void setPaddedRightValue(object value)
        {
            if (value == null)
                value = string.Empty;
            this.setPaddedRightValue(value, this.paddingChar);
        }

        public void setPaddedLeftValue(object value, char character)
        {
            if (value == null)
                value = string.Empty;
            this.Value = value.ToString().PadLeft(this.Size, character);
        }

        public void setPaddedRightValue(object value, char character)
        {
            if (value == null)
                value = string.Empty;
            this.Value = value.ToString().PadRight(this.Size, character);
        }

        public System.DateTime ToDateTime()
        {
            System.DateTime convertedValue = System.DateTime.MinValue;
            if (this.Value != null)
            {
                var date = this.Value.ToString();
                convertedValue = System.Convert.ToDateTime(date.Substring(0, 10) + " " + date.Substring(11, 8));
            }
            return convertedValue;
        }

        public int ToInt32()
        {
            int convertedValue = 0;
            if (this.Value != null)
                int.TryParse(this.Value.ToString(), out convertedValue);
            return convertedValue;
        }

        public bool ToBoolean()
        {
            bool convertedValue = false;
            if (this.Value != null)
                convertedValue = System.Convert.ToBoolean(this.ToInt32());
            return convertedValue;
        }

        public float ToFloat()
        {
            float convertedValue = 0;
            if (this.Value != null)
                convertedValue = float.Parse(this.Value.ToString().Replace('.', ','));
            return convertedValue;
        }

        public override string ToString()
        {
            string convertedValue = string.Empty;
            if (this.Value != null)
                convertedValue = this.Value.ToString();
            return convertedValue;
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
