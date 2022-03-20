using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0048 : MidTester
    {
        [TestMethod]
        public void Mid0048Revision1()
        {
            string package = "00450048001         0107022017-12-01:20:12:45";
            var mid = _midInterpreter.Parse<Mid0048>(package);

            Assert.AreEqual(typeof(Mid0048), mid.GetType());
            Assert.IsNotNull(mid.PairingStatus);
            Assert.IsNotNull(mid.TimeStamp);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0048ByteRevision1()
        {
            string package = "00450048001         0107022017-12-01:20:12:45";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0048>(bytes);

            Assert.AreEqual(typeof(Mid0048), mid.GetType());
            Assert.IsNotNull(mid.PairingStatus);
            Assert.IsNotNull(mid.TimeStamp);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
