using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.UserInterface;

namespace MIDTesters.UserInterface
{
    [TestClass]
    public class TestMid0110 : MidTester
    {
        [TestMethod]
        public void Mid0110Revision1()
        {
            string package = "00240110001         TEST";
            var mid = _midInterpreter.Parse<Mid0110>(package);

            Assert.AreEqual(typeof(Mid0110), mid.GetType());
            Assert.IsNotNull(mid.UserText);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0110ByteRevision1()
        {
            string package = "00240110001         TEST";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0110>(bytes);

            Assert.AreEqual(typeof(Mid0110), mid.GetType());
            Assert.IsNotNull(mid.UserText);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
