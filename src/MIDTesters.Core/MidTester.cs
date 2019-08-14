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
    }
}
