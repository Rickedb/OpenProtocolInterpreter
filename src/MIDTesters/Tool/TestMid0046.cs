using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0046 : MidTester
    {
        [TestMethod]
        public void Mid0046Revision1()
        {
            string package = "00240046001         0102";
            var mid = _midInterpreter.Parse<Mid0046>(package);

            Assert.AreEqual(typeof(Mid0046), mid.GetType());
            Assert.IsNotNull(mid.PrimaryTool);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0046ByteRevision1()
        {
            string package = "00240046001         0102";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0046>(bytes);

            Assert.AreEqual(typeof(Mid0046), mid.GetType());
            Assert.IsNotNull(mid.PrimaryTool);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
