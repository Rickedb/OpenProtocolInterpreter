using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0214 : MidTester
    {
        [TestMethod]
        public void Mid0214AllRevisions()
        {
            string package = "00220214002         10";
            var mid = _midInterpreter.Parse<Mid0214>(package);

            Assert.AreEqual(typeof(Mid0214), mid.GetType());
            Assert.IsNotNull(mid.DeviceNumber);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0214ByteAllRevisions()
        {
            string package = "00220214002         10";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0214>(bytes);

            Assert.AreEqual(typeof(Mid0214), mid.GetType());
            Assert.IsNotNull(mid.DeviceNumber);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
