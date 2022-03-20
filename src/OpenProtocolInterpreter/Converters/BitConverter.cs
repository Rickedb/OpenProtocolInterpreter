namespace OpenProtocolInterpreter.Converters
{
    public class BitConverter
    {
        public bool GetBit(byte b, int bitNumber) => (b & (1 << bitNumber - 1)) != 0;

        protected byte SetByte(bool[] values)
        {
            byte result = 0;
            int index = 9 - values.Length;
            foreach (bool b in values)
            {
                if (b)
                    result |= (byte)(1 << (index - 1));

                index++;
            }

            return result;
        }
    }
}
