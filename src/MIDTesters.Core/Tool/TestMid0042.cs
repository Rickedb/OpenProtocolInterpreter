using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0042 : MidTester
    {
        [TestMethod]
        public void Mid0042Revision1()
        {
            string package = "00200042            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0042), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0042ByteRevision1()
        {
            string package = "00200042            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0042), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0042Revision2()
        {
            string package = "00300042002         0100420201";
            var mid = _midInterpreter.Parse<Mid0042>(package);

            Assert.AreEqual(typeof(Mid0042), mid.GetType());
            Assert.IsNotNull(mid.ToolNumber);
            Assert.IsNotNull(mid.DisableType);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0042ByteRevision2()
        {
            string package = "00300042002         0100420200";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0042>(bytes);

            Assert.AreEqual(typeof(Mid0042), mid.GetType());
            Assert.IsNotNull(mid.ToolNumber);
            Assert.IsNotNull(mid.DisableType);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
