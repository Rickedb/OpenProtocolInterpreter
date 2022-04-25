using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;

namespace MIDTesters
{
    [TestClass]
    public class TestMidHeader : MidTester
    {
        
        [TestMethod]
        public void TestRevisionEmpty()
        {
            var package = "00200001            ";
            var mid = _midInterpreter.Parse<Mid0001>(package);

            Assert.AreEqual(typeof(Mid0001), mid.GetType());
            Assert.AreEqual(1, mid.Header.Revision);
        }

        [TestMethod]
        public void TestRevisionZero()
        {
            var package = "00200001000         ";
            var mid = _midInterpreter.Parse<Mid0001>(package);

            Assert.AreEqual(typeof(Mid0001), mid.GetType());
            Assert.AreEqual(1, mid.Header.Revision);
        }
    }
}
