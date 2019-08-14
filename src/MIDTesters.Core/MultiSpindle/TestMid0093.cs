using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    public class TestMid0093 : MidTester
    {
        [TestMethod]
        public void Mid0093AllRevisions()
        {
            string pack = @"00200093            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0093), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0093ByteAllRevisions()
        {
            string package = @"00200093            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0093), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
