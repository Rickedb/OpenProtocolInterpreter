using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0217 : MidTester
    {
        [TestMethod]
        public void Mid0217Revision1()
        {
            string package = "00280217   1        01026021";
            var mid = _midInterpreter.Parse<Mid0217>(package);

            Assert.AreEqual(typeof(Mid0217), mid.GetType());
            Assert.IsNotNull(mid.RelayNumber);
            Assert.IsNotNull(mid.RelayStatus);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0217ByteRevision1()
        {
            string package = "00280217   1        01026021";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0217>(bytes);

            Assert.AreEqual(typeof(Mid0217), mid.GetType());
            Assert.IsNotNull(mid.RelayNumber);
            Assert.IsNotNull(mid.RelayStatus);

            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
