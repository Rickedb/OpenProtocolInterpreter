using OpenProtocolInterpreter;

namespace MIDTesters
{
    public abstract class MidTester
    {
        protected readonly MidInterpreter _midInterpreter;

        public MidTester()
        {
            _midInterpreter = new MidInterpreter();
        }
    }
}
