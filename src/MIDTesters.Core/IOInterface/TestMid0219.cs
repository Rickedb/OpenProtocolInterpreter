using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0219 : MidTester
    {
        [TestMethod]
        public void Mid0219Revision1()
        {
            string package = "00230219            102";
            var mid = _midInterpreter.Parse<Mid0219>(package);

            Assert.AreEqual(typeof(Mid0219), mid.GetType());
            Assert.IsNotNull(mid.RelayNumber);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0219ByteRevision1()
        {
            string package = "00230219            102";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0219>(bytes);

            Assert.AreEqual(typeof(Mid0219), mid.GetType());
            Assert.IsNotNull(mid.RelayNumber);

            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
