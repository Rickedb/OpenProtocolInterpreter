using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.AutomaticManualMode;

namespace MIDTesters.AutomaticManualMode
{
    [TestClass]
    public class TestMid0402 : MidTester
    {
        [TestMethod]
        public void Mid0402Revision1()
        {
            string package = "00200402            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0402), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0402ByteRevision1()
        {
            string package = "00200402            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0402), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
