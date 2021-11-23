using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;
using System.Linq;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0040 : MidTester
    {
        [TestMethod]
        public void Mid0040Revisions1To5()
        {
            string package = "00200040004         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0040), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0040ByteRevisions1To5()
        {
            string package = "00200040004         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0040), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0040Revisions6And7()
        {
            string package = "00260040007         010001";
            var mid = _midInterpreter.Parse<Mid0040>(package);

            Assert.AreEqual(typeof(Mid0040), mid.GetType());
            Assert.IsNotNull(mid.ToolNumber);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0040ByteRevisions6And7()
        {
            string package = "00260040007         010001";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0040>(bytes);

            Assert.AreEqual(typeof(Mid0040), mid.GetType());
            Assert.IsNotNull(mid.ToolNumber);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
