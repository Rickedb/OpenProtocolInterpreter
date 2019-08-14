using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0220 : MidTester
    {
        [TestMethod]
        public void Mid0220Revision1()
        {
            string package = "00230220            120";
            var mid = _midInterpreter.Parse<Mid0220>(package);

            Assert.AreEqual(typeof(Mid0220), mid.GetType());
            Assert.IsNotNull(mid.DigitalInputNumber);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0220ByteRevision1()
        {
            string package = "00230220            120";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0220>(bytes);

            Assert.AreEqual(typeof(Mid0220), mid.GetType());
            Assert.IsNotNull(mid.DigitalInputNumber);

            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
