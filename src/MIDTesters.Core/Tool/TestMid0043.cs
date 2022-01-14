using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0043 : MidTester
    {
        [TestMethod]
        public void Mid0043Revision1()
        {
            string package = "00200043            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0043), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0043ByteRevision1()
        {
            string package = "00200043            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0043), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0043Revision2()
        {
            string package = "00260043002         010042";
            var mid = _midInterpreter.Parse<Mid0043>(package);

            Assert.AreEqual(typeof(Mid0043), mid.GetType());
            Assert.IsNotNull(mid.ToolNumber);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0043ByteRevision2()
        {
            string package = "00260043002         010032";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0043>(bytes);

            Assert.AreEqual(typeof(Mid0043), mid.GetType());
            Assert.IsNotNull(mid.ToolNumber);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
