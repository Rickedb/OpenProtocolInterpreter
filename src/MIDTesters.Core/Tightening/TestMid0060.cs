using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tightening;

namespace MIDTesters.Tightening
{
    [TestClass]
    public class TestMid0060 : MidTester
    {
        [TestMethod]
        public void Mid0060AllRevisions()
        {
            string package = "00200060998         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0060), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0060ByteAllRevisions()
        {
            string package = "00200060998         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0060), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
