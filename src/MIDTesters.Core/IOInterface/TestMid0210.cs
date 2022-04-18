using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0210 : MidTester
    {
        [TestMethod]
        public void Mid0210Revision1()
        {
            string package = "00200210   1        ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0210), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0210ByteRevision1()
        {
            string package = "00200210   1        ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0210), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
