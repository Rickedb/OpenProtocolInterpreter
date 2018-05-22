namespace OpenProtocolInterpreter.Converters
{
    internal abstract class BitConverter
    {
        protected bool GetBit(byte b, int bitNumber) => (b & (1 << bitNumber - 1)) != 0;

        protected byte SetByte(bool[] values)
        {
            byte result = 0;
            int index = 8 - values.Length;
            foreach (bool b in values)
            {
                if (b)
                    result |= (byte)(1 << (7 - index));

                index++;
            }

            return result;
        }
    }
}
