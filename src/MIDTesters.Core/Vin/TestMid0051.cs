using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Vin;

namespace MIDTesters.Vin
{
    [TestClass]
    public class TestMid0051 : MidTester
    {
        [TestMethod]
        public void Mid0051AllRevisions()
        {
            string package = "002000510010        ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0051), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0051ByteAllRevisions()
        {
            string package = "002000510010        ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0051), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
