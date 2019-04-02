using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PowerMACS;

namespace MIDTesters.PowerMACS
{
    [TestClass]
    public class TestMid0109 : MidTester
    {
        [TestMethod]
        public void Mid0109AllRevisions()
        {
            string package = "00200109002         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0109), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0109ByteAllRevisions()
        {
            string package = "00200109002         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0109), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
