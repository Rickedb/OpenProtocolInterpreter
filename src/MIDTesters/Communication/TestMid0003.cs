using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;

namespace MIDTesters.Communication
{
    [TestClass]
    public class TestMid0003 : MidTester
    {
        [TestMethod]
        public void Mid0003Revision1()
        {
            string pack = @"00200003001         ";
            var mid = _midInterpreter.Parse<Mid0003>(pack);

            Assert.AreEqual(typeof(Mid0003), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
