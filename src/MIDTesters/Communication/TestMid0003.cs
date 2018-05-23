using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;

namespace MIDTesters.Communication
{
    [TestClass]
    public class TestMid0003 : MidTester
    {
        [TestMethod]
        public void Revision1()
        {
            string pack = @"00200003001         ";
            var mid = _midInterpreter.Parse<MID_0003>(pack);

            Assert.AreEqual(typeof(MID_0003), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
