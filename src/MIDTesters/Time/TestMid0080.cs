using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Time;

namespace MIDTesters.Time
{
    [TestClass]
    public class TestMid0080 : MidTester
    {
        [TestMethod]
        public void Mid0080AllRevisions()
        {
            string pack = @"00200080            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0080), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0080ByteAllRevisions()
        {
            string package = "00200080            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0080), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
