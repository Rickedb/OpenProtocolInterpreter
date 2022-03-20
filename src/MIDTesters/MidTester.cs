using OpenProtocolInterpreter;
using System.Text;

namespace MIDTesters
{
    public abstract class MidTester
    {
        protected readonly MidInterpreter _midInterpreter;

        public MidTester()
        {
            _midInterpreter = new MidInterpreter().UseAllMessages();
        }

        protected byte[] GetAsciiBytes(string package) => Encoding.ASCII.GetBytes(package);
        protected byte[] GetAsciiBytes(byte[] package, int byteLength)
        {
            var asciiInt = (byteLength > 8 ? System.BitConverter.ToInt64(package, 0) : System.BitConverter.ToInt32(package, 0)).ToString().PadLeft(byteLength, '0');
            return Encoding.ASCII.GetBytes(asciiInt);
        }
    }
}
