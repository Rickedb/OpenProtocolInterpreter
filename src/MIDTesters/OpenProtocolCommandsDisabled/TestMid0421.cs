using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.OpenProtocolCommandsDisabled;

namespace MIDTesters.OpenProtocolCommandsDisabled
{
    [TestClass]
    public class TestMid0421 : MidTester
    {
        [TestMethod]
        public void Mid0421Revision1()
        {
            string package = "00210421   1        1";
            var mid = _midInterpreter.Parse<Mid0421>(package);

            Assert.AreEqual(typeof(Mid0421), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.IsNotNull(mid.DigitalInputStatus);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0421ByteRevision1()
        {
            string package = "00210421   1        1";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0421>(bytes);

            Assert.AreEqual(typeof(Mid0421), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.IsNotNull(mid.DigitalInputStatus);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
