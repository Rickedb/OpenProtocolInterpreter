using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0047 : MidTester
    {
        [TestMethod]
        public void Mid0047Revision1()
        {
            string package = "00240047001         0103";
            var mid = _midInterpreter.Parse<Mid0047>(package);

            Assert.AreEqual(typeof(Mid0047), mid.GetType());
            Assert.IsNotNull(mid.PairingHandlingType);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0047ByteRevision1()
        {
            string package = "00240047001         0103";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0047>(bytes);

            Assert.AreEqual(typeof(Mid0047), mid.GetType());
            Assert.IsNotNull(mid.PairingHandlingType);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
