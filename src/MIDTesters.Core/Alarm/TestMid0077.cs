using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    public class TestMid0077 : MidTester
    {
        [TestMethod]
        public void Mid0077AllRevisions()
        {
            string pack = @"00200077            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0077), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0077ByteAllRevisions()
        {
            string pack = @"00200077            ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0077), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
