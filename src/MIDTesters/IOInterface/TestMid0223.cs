using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0223 : MidTester
    {
        [TestMethod]
        public void Mid0223Revision1()
        {
            string package = "00230223            066";
            var mid = _midInterpreter.Parse<Mid0223>(package);

            Assert.AreEqual(typeof(Mid0223), mid.GetType());
            Assert.IsNotNull(mid.DigitalInputNumber);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0223ByteRevision1()
        {
            string package = "00230223            066";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0223>(bytes);

            Assert.AreEqual(typeof(Mid0223), mid.GetType());
            Assert.IsNotNull(mid.DigitalInputNumber);

            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
