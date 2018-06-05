using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0040 : MidTester
    {
        [TestMethod]
        public void Mid0040AllRevisions()
        {
            string package = "00200040004         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0040), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
