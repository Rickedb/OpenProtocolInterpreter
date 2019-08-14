using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    public class TestMid0078 : MidTester
    {
        [TestMethod]
        public void Mid0078AllRevisions()
        {
            string pack = @"00200078            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0078), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0078ByteAllRevisions()
        {
            string pack = @"00200078            ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0078), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
