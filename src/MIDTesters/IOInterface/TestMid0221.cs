using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0221 : MidTester
    {
        [TestMethod]
        public void Mid0221Revision1()
        {
            string package = "00280221            01120021";
            var mid = _midInterpreter.Parse<Mid0221>(package);

            Assert.AreEqual(typeof(Mid0221), mid.GetType());
            Assert.IsNotNull(mid.DigitalInputNumber);
            Assert.IsNotNull(mid.DigitalInputStatus);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0221ByteRevision1()
        {
            string package = "00280221            01120021";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0221>(bytes);

            Assert.AreEqual(typeof(Mid0221), mid.GetType());
            Assert.IsNotNull(mid.DigitalInputNumber);
            Assert.IsNotNull(mid.DigitalInputStatus);

            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
