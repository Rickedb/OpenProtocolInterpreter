using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    public class TestMid0092 : MidTester
    {
        [TestMethod]
        public void Mid0092AllRevisions()
        {
            string pack = @"00200092            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0092), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0092ByteAllRevisions()
        {
            string package = @"00200092            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0092), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
