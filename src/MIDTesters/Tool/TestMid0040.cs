using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;
using System.Linq;

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

            Assert.AreEqual(typeof(Mid0040), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0040ByteAllRevisions()
        {
            string package = "00200040004         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0040), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
