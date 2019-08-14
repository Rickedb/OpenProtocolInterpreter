using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0224 : MidTester
    {
        [TestMethod]
        public void Mid0224Revision1()
        {
            string package = "00230224            065";
            var mid = _midInterpreter.Parse<Mid0224>(package);

            Assert.AreEqual(typeof(Mid0224), mid.GetType());
            Assert.IsNotNull(mid.DigitalInputNumber);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0224ByteRevision1()
        {
            string package = "00230224            065";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0224>(bytes);

            Assert.AreEqual(typeof(Mid0224), mid.GetType());
            Assert.IsNotNull(mid.DigitalInputNumber);

            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
